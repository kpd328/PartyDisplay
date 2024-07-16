#include "pch.h"
//#include "DolphinAccessor.h"
#ifdef __linux__
#include "LinuxDolphinProcess.h"
#elif _WIN32
#include "WindowsDolphinProcess.h"
#elif __APPLE__
#include "MacDolphinProcess.h"
#endif

#include <cstring>
#include <memory>

#include "CommonTypes.h"
#include "CommonUtils.h"
#include "MemoryCommon.h"
#include "IDolphinProcess.h"

namespace PartyDisplayProcess {
    public ref class DolphinAccessor {
    public:
        enum class DolphinStatus {
            hooked,
            notRunning,
            noEmu,
            unHooked
        };

        static void init();
        static void free();
        static void hook();
        static void unHook();
        static bool readFromRAM(u32 offset, char* buffer, size_t size, bool withBSwap);
        static bool writeToRAM(u32 offset, const char* buffer, size_t size, bool withBSwap);
        static int getPID();
        static u64 getEmuRAMAddressStart();
        static DolphinStatus getStatus();
        static bool isARAMAccessible();
        static u64 getARAMAddressStart();
        static bool isMEM2Present();
        static size_t getRAMTotalSize();
        static Common::MemOperationReturnCode readEntireRAM(char* buffer);
        static System::String^ getFormattedValueFromMemory(u32 ramIndex, Common::MemType memType, size_t memSize, Common::MemBase memBase, bool memIsUnsigned);
        static bool isValidConsoleAddress(u32 address);

    private:
        static IDolphinProcess* m_instance = nullptr;
        static DolphinStatus m_status = DolphinStatus::unHooked;
    };

    void DolphinAccessor::init() {
        Common::UpdateMemoryValues();
        if (m_instance == nullptr) {
#ifdef __linux__
            m_instance = new LinuxDolphinProcess();
#elif _WIN32
            m_instance = new WindowsDolphinProcess();
#elif __APPLE__
            m_instance = new MacDolphinProcess();
#endif
        }
    }

    void DolphinAccessor::free() {
        delete m_instance;
    }

    void DolphinAccessor::hook() {
        init();
        if (!m_instance->findPID()) {
            m_status = DolphinStatus::notRunning;
        } else if (!m_instance->obtainEmuRAMInformations()) {
            m_status = DolphinStatus::noEmu;
        } else {
            m_status = DolphinStatus::hooked;
        }
    }

    void DolphinAccessor::unHook() {
        delete m_instance;
        m_instance = nullptr;
        m_status = DolphinStatus::unHooked;
    }

    DolphinAccessor::DolphinStatus DolphinAccessor::getStatus() {
        return m_status;
    }

    bool DolphinAccessor::readFromRAM(const u32 offset, char* buffer, const size_t size,
        const bool withBSwap) {
        return m_instance ? m_instance->readFromRAM(offset, buffer, size, withBSwap) : false;
    }

    bool DolphinAccessor::writeToRAM(const u32 offset, const char* buffer, const size_t size,
        const bool withBSwap) {
        return m_instance ? m_instance->writeToRAM(offset, buffer, size, withBSwap) : false;
    }

    int DolphinAccessor::getPID() {
        return m_instance ? m_instance->getPID() : -1;
    }

    u64 DolphinAccessor::getEmuRAMAddressStart() {
        return m_instance ? m_instance->getEmuRAMAddressStart() : 0;
    }

    bool DolphinAccessor::isARAMAccessible() {
        return m_instance ? m_instance->isARAMAccessible() : false;
    }

    u64 DolphinAccessor::getARAMAddressStart() {
        return m_instance ? m_instance->getARAMAddressStart() : 0;
    }

    bool DolphinAccessor::isMEM2Present() {
        return m_instance ? m_instance->isMEM2Present() : false;
    }

    bool DolphinAccessor::isValidConsoleAddress(const u32 address) {
        if (getStatus() != DolphinStatus::hooked)
            return false;

        if (address >= Common::MEM1_START && address < Common::GetMEM1End())
            return true;

        if (isMEM2Present() && (address >= Common::MEM2_START && address < Common::GetMEM2End()))
            return true;

        if (isARAMAccessible() && (address >= Common::ARAM_START && address < Common::ARAM_END))
            return true;

        return false;
    }

    size_t DolphinAccessor::getRAMTotalSize() {
        if (isMEM2Present()) {
            return Common::GetMEM1SizeReal() + Common::GetMEM2SizeReal();
        }
        if (isARAMAccessible()) {
            return Common::GetMEM1SizeReal() + Common::ARAM_SIZE;
        }

        return Common::GetMEM1SizeReal();
    }

    Common::MemOperationReturnCode DolphinAccessor::readEntireRAM(char* buffer) {
        // MEM2, if enabled, is read right after MEM1 in the buffer so both regions are contigous
        if (isMEM2Present()) {
            if (!PartyDisplayProcess::DolphinAccessor::readFromRAM(
                Common::dolphinAddrToOffset(Common::MEM1_START, false), buffer,
                Common::GetMEM1SizeReal(), false))
                return Common::MemOperationReturnCode::operationFailed;

            // Read Wii extra RAM
            if (!PartyDisplayProcess::DolphinAccessor::readFromRAM(
                Common::dolphinAddrToOffset(Common::MEM2_START, false),
                buffer + Common::GetMEM1SizeReal(), Common::GetMEM2SizeReal(), false))
                return Common::MemOperationReturnCode::operationFailed;
        } else if (isARAMAccessible()) {
            // read ARAM
            if (!PartyDisplayProcess::DolphinAccessor::readFromRAM(
                Common::dolphinAddrToOffset(Common::ARAM_START, true), buffer, Common::ARAM_SIZE,
                false))
                return Common::MemOperationReturnCode::operationFailed;

            // Read GameCube and Wii basic RAM
            if (!PartyDisplayProcess::DolphinAccessor::readFromRAM(
                Common::dolphinAddrToOffset(Common::MEM1_START, true), buffer + Common::ARAM_SIZE,
                Common::GetMEM1SizeReal(), false))
                return Common::MemOperationReturnCode::operationFailed;
        } else {
            if (!PartyDisplayProcess::DolphinAccessor::readFromRAM(
                Common::dolphinAddrToOffset(Common::MEM1_START, false), buffer,
                Common::GetMEM1SizeReal(), false))
                return Common::MemOperationReturnCode::operationFailed;
        }

        return Common::MemOperationReturnCode::OK;
    }

    System::String^ DolphinAccessor::getFormattedValueFromMemory(const u32 ramIndex,
        Common::MemType memType, size_t memSize,
        Common::MemBase memBase,
        bool memIsUnsigned) {
        std::unique_ptr<char[]> buffer(new char[memSize]);
        readFromRAM(ramIndex, buffer.get(), memSize, false);
        return gcnew System::String(Common::formatMemoryToString(buffer.get(), memType, memSize, memBase, memIsUnsigned,
            Common::shouldBeBSwappedForType(memType)).c_str());
    }
}  // namespace DolphinComm