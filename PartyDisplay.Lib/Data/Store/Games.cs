using static PartyDisplay.Lib.Data.Region;

namespace PartyDisplay.Lib.Data.Store;

public sealed class Games {
    public static Game[] List => [
        new(name: "Mario Party 2", code: "mp2", icon: "/img/title/mp2.png", availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 4", code: "mp4", icon: "/img/title/mp4.png", availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 5", code: "mp5", icon: "/img/title/mp5.png", availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 6", code: "mp6", icon: "/img/title/mp6.png", availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 7", code: "mp7", icon: "/img/title/mp7.png", availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 8", code: "mp8", icon: "/img/title/mp8.png", availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
    ];
}