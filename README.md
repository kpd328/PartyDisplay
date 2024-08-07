# PartyDisplay

A game state data display for Mario Party games playable on the Dolphin Emulator. Perfect for streaming Mario Party games with an overlay that shows up to date and accurate information for viewers.

![In-use screenshot of a Mario Party 5 game with the PartyDisplay overlay on the left side of the screen](https://github.com/user-attachments/assets/5c67ffeb-1066-48ac-adbf-730cf6f00dc8)

## Features

* **Individual Transperent Player Windows** - perfect for custom streaming layouts.
* **Custom Player Names** - for identifying which player is which character.
* **Item Display** - displays item icons for keeping track of exactly what item(s) each player has.
* **Bonus Stars Tracker** - keeps track of each game's bonus star criteria to easy see who is in the lead for each star.

## Todo List/Roadmap
* [ ] Find final Mario Party 2 addresses needed to complete implementation
  * Player ranking for each of the 4 players
* [ ] Gather test assets for Mario Party 8
* [ ] Create custom assets for entire project
  * Current assets are very lo-res for this day and age
* [ ] Fix flickering data bug present in all tested games sans Mario Party 5 (How did I get the first one right and mess up the rest?)
* [ ] Test other regions
* [ ] Fix hook closing crash
  * Closing Dolphin or ending emulation before closing PartyDisplay crashes party display, this needs to be more graceful
* [ ] Create build pipeline for distribution
* [ ] **Stretch:** Reimplement Dolphin Hook code to be crossplatform (more for Linux then MacOS, don't have access to a MacOS device to build/test).

## Game Compatibility

| Game | NTSC | NTSC-J | NTSC-K | PAL | Notes |
| --- | --- | --- | --- | --- | --- |
| Mario Party 2 (Virtual Console) | <ul><li>- [ ] NAZE</li></ul> | <ul><li>- [ ] NAZJ</li></ul> | N/A | <ul><li>- [ ] NAZJ</li></ul> | Implementation is untested, missing player rankings |
| Mario Party 4 (GC) | <ul><li>- [x] GMPE01</li></ul> | <ul><li>- [ ] GMPJ01</li></ul> | N/A | <ul><li>- [ ] GMPP01</li></ul> | Only tested on NTSC, has a weird data flickering bug |
| Mario Party 5 (GC) | <ul><li>- [x] GP5E01</li></ul> | <ul><li>- [ ] GP5J01</li></ul> | <ul><li>- [ ] GP5W01</li></ul> | <ul><li>- [ ] GP5P01</li></ul> | Only tested on NTSC |
| Mario Party 6 (GC) | <ul><li>- [x] GP6E01</li></ul> | <ul><li>- [ ] GP6J01</li></ul> | N/A | <ul><li>- [ ] GP6P01</li></ul> | Only tested on NTSC, has a weird data flickering bug |
| Mario Party 7 (GC) | <ul><li>- [x] GP7E01</li></ul> | <ul><li>- [ ] GP7J01</li></ul> | N/A | <ul><li>- [ ] GP7P01</li></ul> | Only tested on NTSC, has a weird data flickering bug |
| Mario Party 8 (Wii) | <ul><li>- [ ] RM8E01</li></ul> | <ul><li>- [ ] RM8J01</li></ul> | <ul><li>- [ ] RM8K01</li></ul> | <ul><li>- [ ] RM8P01</li></ul> | Implementation is untested, missing assets |

## Build

Built using .NET 8 and Avalonia 11.

Adapts Dolphin hooking functions from [aldelaro5/dolphin-memory-engine](https://github.com/aldelaro5/dolphin-memory-engine), liscened under [MIT](https://github.com/aldelaro5/dolphin-memory-engine/blob/master/LICENSE).

At current time, this project only works on Windows (some of the source from Dolphin Memory Engine was ported to C++/CLI for .NET interop, which at current time is Windows only). If translated to another framework that actually has crossplatform, the rest of the app is set up for Linux and MacOS compatibility (including the non CLI part of the C++ library, just need to import the Linux and MacOS implementations). Some ideas include native C++ and PInvoke, or translating the whole DME library to unsafe C# (PInvoke'ing Win32.dll when needed).
