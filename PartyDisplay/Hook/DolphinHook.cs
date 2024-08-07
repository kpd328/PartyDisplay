using Common;
using PartyDisplayProcess;
using System;
using System.Data;

namespace PartyDisplay.Hook {
    public class DolphinHook {
        public static string LoadedGame() {
            if(DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.hooked) {
                string _r;
                if(ByteLookup(0) == 0) {
                    //Virtual Console Game
                    _r = DolphinAccessor.getFormattedValueFromMemory(0x3180, MemType.type_string, 4, MemBase.base_none, false);
                } else {
                    _r = DolphinAccessor.getFormattedValueFromMemory(0, MemType.type_string, 6, MemBase.base_none, false);
                }
                return _r;
            } else {
                return "No Game Loaded";
            }
        }

        public static sbyte ByteLookup(uint index) {
            if(DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.hooked) {
                unsafe {
                    sbyte _out;
                    if(DolphinAccessor.readFromRAM(index, &_out, sizeof(sbyte), false)) {
                        return _out;
                    } else {
                        throw new Exception("Memory not found.");
                    }
                }
                
            } else {
                throw new DataException("Dolphin not found.");
            }
        }

        public static short HwordLookup(uint index) {
            if(DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.hooked) {
                unsafe {
                    short _out;
                    if(DolphinAccessor.readFromRAM(index, (sbyte*)&_out, sizeof(short), true)) {
                        return _out;
                    } else {
                        throw new Exception("Memory not found.");
                    }
                }
            } else {
                throw new DataException("Dolphin not found.");
            }
        }
    }
}
