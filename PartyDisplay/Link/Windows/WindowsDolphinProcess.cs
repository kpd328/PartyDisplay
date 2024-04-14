using System.Diagnostics;
using System.Linq;

namespace PartyDisplay.Link.Windows {
    public class WindowsDolphinProcess:IDolphinProcess {
        public int PID { get; private set; }
        public ulong EmuRAMAddressStart { get; private set; }
        public ulong EmuARAMAddressStart { get; private set; }
        public ulong MEM2AddressStart { get; private set; }
        public bool ARAMAccessible { get; private set; }
        public bool MEM2Present { get; private set; }
        private nint DolphinHandle { get; set; }

        public bool FindPID() {
            Process? dolphin = Process.GetProcessesByName("Dolphin.exe").FirstOrDefault();

            if(dolphin == null) {
                PID = -1;
                return false;
            } else {
                PID = dolphin.Id;
                DolphinHandle = dolphin.Handle;
                return true;
            }
        }

        public bool ObtainEmuRAMInformations() {
            throw new System.NotImplementedException();
        }

        public bool ReadFromRAM(uint offset, byte[] buffer, nuint size, bool withBSwap) {
            throw new System.NotImplementedException();
        }

        public bool WriteToRAM(uint offset, byte[] buffer, nuint size, bool withBSwap) {
            throw new System.NotImplementedException();
        }
    }
}
