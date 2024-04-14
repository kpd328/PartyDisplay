namespace PartyDisplay.Link {
    public interface IDolphinProcess {
        public int PID { get; }
        public ulong EmuRAMAddressStart { get; }
        public ulong EmuARAMAddressStart { get; }
        public ulong MEM2AddressStart { get; }
        public bool ARAMAccessible { get; }
        public bool MEM2Present { get; }

        public bool FindPID();
        public bool ObtainEmuRAMInformations();
        public bool ReadFromRAM(uint offset, byte[] buffer, nuint size, bool withBSwap);
        public bool WriteToRAM(uint offset, byte[] buffer, nuint size, bool withBSwap);
        public ulong GetMEM1ToMEM2Distance() => MEM2Present ? MEM2AddressStart - EmuRAMAddressStart : 0;
    }
}
