#pragma once

#include <cstddef>

#include "CommonTypes.h"

namespace PartyDisplayProcess {
	class IDolphinProcess {
	public:
		IDolphinProcess() = default;
		virtual ~IDolphinProcess() = default;

		IDolphinProcess(const IDolphinProcess&) = delete;
		IDolphinProcess(IDolphinProcess&&) = delete;
		IDolphinProcess& operator=(const IDolphinProcess&) = delete;
		IDolphinProcess& operator=(IDolphinProcess&&) = delete;

		virtual bool findPID() = 0;
		virtual bool obtainEmuRAMInformations() = 0;
		virtual bool readFromRAM(u32 offset, char* buffer, size_t size, bool withBSwap) = 0;
		virtual bool writeToRAM(u32 offset, const char* buffer, size_t size, bool withBSwap) = 0;

		int getPID() const { return m_PID; };
		u64 getEmuRAMAddressStart() const { return m_emuRAMAddressStart; };
		bool isMEM2Present() const { return m_MEM2Present; };
		bool isARAMAccessible() const { return m_ARAMAccessible; };
		u64 getARAMAddressStart() const { return m_emuARAMAdressStart; };
		u64 getMEM2AddressStart() const { return m_MEM2AddressStart; };
		u64 getMEM1ToMEM2Distance() const {
			if (!m_MEM2Present)
				return 0;
			return m_MEM2AddressStart - m_emuRAMAddressStart;
		};

	protected:
		int m_PID = -1;
		u64 m_emuRAMAddressStart = 0;
		u64 m_emuARAMAdressStart = 0;
		u64 m_MEM2AddressStart = 0;
		bool m_ARAMAccessible = false;
		bool m_MEM2Present = false;
	};
}