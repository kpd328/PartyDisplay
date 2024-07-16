using Common;
using PartyDisplayProcess;
using System;
using System.Data;

namespace PartyDisplay.Hook {
    public class DolphinHook {

        public static string LoadedGame() {
            if(DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.hooked) {
                return DolphinAccessor.getFormattedValueFromMemory(0, MemType.type_string, 6*sizeof(byte), MemBase.base_none, false);
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
    }
}
