using static PartyDisplay.Lib.Data.Region;

namespace PartyDisplay.Lib.Data.Store;

public sealed class Games {
    public static Game[] Templates => [
        new(name: "Mario Party 2", code: "mp2", icon: "/img/title/mp2.png", availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 4", code: "mp4", icon: "/img/title/mp4.png", availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 5", code: "mp5", icon: "/img/title/mp5.png", availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 6", code: "mp6", icon: "/img/title/mp6.png", availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 7", code: "mp7", icon: "/img/title/mp7.png", availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 8", code: "mp8", icon: "/img/title/mp8.png", availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
    ];
    
    public static Game[] List => [
        new(name: "Mario Party 2", id: "NAZE", code: "mp2", icon: "/img/title/mp2.png", region: NTSC, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 2", id: "NAZJ", code: "mp2", icon: "/img/title/mp2.png", region: NTSC_J, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 2", id: "NAZP", code: "mp2", icon: "/img/title/mp2.png", region: PAL, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 4", id: "GMPE01", code: "mp4", icon: "/img/title/mp4.png", region: NTSC, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 4", id: "GMPJ01", code: "mp4", icon: "/img/title/mp4.png", region: NTSC_J, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 4", id: "GMPP01", code: "mp4", icon: "/img/title/mp4.png", region: PAL, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 5", id: "GP5E01", code: "mp5", icon: "/img/title/mp5.png", region: NTSC, availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 5", id: "GP5J01", code: "mp5", icon: "/img/title/mp5.png", region: NTSC_J, availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 5", id: "GP5P01", code: "mp5", icon: "/img/title/mp5.png", region: PAL, availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 5", id: "GP5W01", code: "mp5", icon: "/img/title/mp5.png", region: NTSC_K, availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 6", id: "GP6E01", code: "mp6", icon: "/img/title/mp6.png", region: NTSC, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 6", id: "GP6J01", code: "mp6", icon: "/img/title/mp6.png", region: NTSC_J, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 6", id: "GP6P01", code: "mp6", icon: "/img/title/mp6.png", region: PAL, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 7", id: "GP7E01", code: "mp7", icon: "/img/title/mp7.png", region: NTSC, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 7", id: "GP7J01", code: "mp7", icon: "/img/title/mp7.png", region: NTSC_J, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 7", id: "GP7P01", code: "mp7", icon: "/img/title/mp7.png", region: PAL, availableRegions: [NTSC, NTSC_J, PAL]),
        new(name: "Mario Party 8", id: "RM8E01", code: "mp8", icon: "/img/title/mp8.png", region: NTSC, availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 8", id: "RM8J01", code: "mp8", icon: "/img/title/mp8.png", region: NTSC_J, availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 8", id: "RM8P01", code: "mp8", icon: "/img/title/mp8.png", region: PAL, availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
        new(name: "Mario Party 8", id: "RM8K01", code: "mp8", icon: "/img/title/mp8.png", region: NTSC_K, availableRegions: [NTSC, NTSC_J, PAL, NTSC_K]),
    ];
}