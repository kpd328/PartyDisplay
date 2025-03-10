using System.Diagnostics;
using System.Text;
using Reloaded.Memory;

namespace PartyDisplay.Dolphin;

public class Memory {
    private static readonly Lazy<Memory> _lazy = new Lazy<Memory>(() => new Memory());
    public static Memory Access => _lazy.Value;

    private global::Dolphin.Memory.Access.Dolphin _dolphin;
    private ExternalMemory _memory;

    private const long BaseAddress = 0x8000_0000;
    private const long VirtualConsoleCode = 0x8000_3180;
    private const int CodeLength = 6;
    private const int VirtualConsoleCodeLength = 4;

    private Memory() {
        var process = Process.GetProcessesByName("Dolphin").FirstOrDefault();
        if (process is not null) {
            _dolphin = new(process);
            _memory = new(process);
        } else {
            throw new FileNotFoundException("Process Dolphin not currently running.");
        }
    }

    public string LoadedGame() {
        try {
            if (SearchByte(BaseAddress) == 0) {
                //This is a Virtual Console Game
                return SearchString(VirtualConsoleCode, VirtualConsoleCodeLength);
            } else {
                return SearchString(BaseAddress, CodeLength);
            }
        } catch (Exception e) {
            throw new FileNotFoundException("No Game Is Loaded", e);
        }
    }

    public byte SearchByte(long address) {
        if (_dolphin.TryGetAddress(address, out UIntPtr real)) {
            return _memory.Read<byte>(real);
        }

        throw new ArgumentOutOfRangeException(nameof(address));
    }
    
    public sbyte SearchSByte(long address) {
        if (_dolphin.TryGetAddress(address, out UIntPtr real)) {
            return _memory.Read<sbyte>(real);
        }

        throw new ArgumentOutOfRangeException(nameof(address));
    }

    public short SearchHword(long address) {
        if (_dolphin.TryGetAddress(address, out UIntPtr real)) {
            return _memory.Read<short>(real);
        }
        
        throw new ArgumentOutOfRangeException(nameof(address));
    }

    public string SearchString(long address, int length) {
        if (_dolphin.TryGetAddress(address, out UIntPtr real)) {
            return new ASCIIEncoding().GetString(_memory.ReadRaw(real, length));
        }
        
        throw new ArgumentOutOfRangeException(nameof(address));
    }
}