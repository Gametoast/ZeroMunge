![Zero Munge](app_banner.jpg)

[![Build Status](https://travis-ci.org/marth8880/ZeroMunge.svg?branch=master&maxAge=300)](https://travis-ci.org/marth8880/ZeroMunge)
[![Issues](https://img.shields.io/github/issues/marth8880/ZeroMunge.svg?maxAge=60)](https://github.com/marth8880/ZeroMunge/issues)
[![License](https://img.shields.io/badge/License-BSD%203--Clause-blue.svg?label=license)](https://opensource.org/licenses/BSD-3-Clause)  
[![Release](https://img.shields.io/github/release/marth8880/ZeroMunge.svg?label=latest%20release&maxAge=300)](https://github.com/marth8880/ZeroMunge/releases/latest)
![Downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/latest/total.svg?maxAge=60)



## What it is

The goal of Zero Munge is to act as a robust replacement for VisualMunge, the automated build tool provided with the SWBF2 mod tools.  

It is written in Visual C# for [.NET Framework 4](https://www.microsoft.com/en-us/download/details.aspx?id=17718).

## What it does

At its core, Zero Munge goes through a user-specified list of munge.bat files and executes each one at a time and copies the associated LVL files to the appropriate staging directory.  

Zero Munge includes the following features.

- Execute a list of batch files in order
- Toggle whether or not certain files will be executed
- Log each file's output in real-time (with timestamps) to a log window and log file
- Auto-detect the munge.bat file inside a selected folder and add it to the file list
- Add typical munge.bat files (common, sides, world, etc.) for an entire project to the file list
- For each file, copy the associated LVL file(s) to another directory
- Ability to check for updates and point user to latest release's download page
- Save and load different "presets" of the file list's contents
- Automatically saves the file list on application exit
- Automatically loads the last-saved file list on application startup

## How to use it

### Preamble: Understanding the munge process

The first thing you need to understand is that VisualMunge does not munge things, it executes batch scripts that execute the necessary logic to turn raw assets into LVL files. The flow of how it works is this: 

1. In VisualMunge, the user selects what should be munged (sides/worlds/etc.). The user then clicks 'Munge'.
2. VisualMunge sequentially executes the munge.bat scripts for each item that the user selected.
3. Each munge.bat script calls the appropriate compiler executables out of `BF2_ModTools\ToolsFL` (like `scriptmunge.exe` for Lua scripts or `texturemunge.exe` for TGA textures) to convert the raw assets into compiled files, which are put in the appropriate munge directory (like `data_***\_BUILD\Sides\REP\Munged\PC`). In most cases, the munge.bat script then calls `levelpack.exe`, which packs those compiled files into a single LVL file that is able to be read by the game.

At its core, Zero Munge essentially does the same thing that VisualMunge does - except you're given far more control over what they want to munge. How so? You're able to specify all the individual munge.bat scripts to execute, and optionally Zero Munge will also copy over the LVL file(s) associated with each munge.bat script to the correct folder in your project's addon directory.

### Alright, so how do I use it?

Using Zero Munge is fairly easy - to munge something, all you do is add the desired munge.bat scripts to the File List and press 'Run':

1. Click 'Add Files' button to browse for and add munge.bat scripts to the File List.
2. Click 'Run' button to have Zero Munge sequentially execute each file in the File List and optionally copy the associated LVL files to your project's addon directory.

Alternatively, you can click the 'Add Folders' button to select folders containing munge.bat scripts to add. For example, if you wanted to add the munge.bat scripts for the CIS and REP sides in one action, you'd click 'Add Folders', browse to `data_***\_BUILD\Sides`, select the CIS and REP folders, and click 'Open' - the munge.bat scripts for the CIS and REP sides would then be added to the File List.

Examples of munge.bat scripts:

- REP side: `data_***\_BUILD\Sides\REP\munge.bat`
- * Your world: `data_***\_BUILD\Worlds\***\munge.bat` (see note below)
- Common: `data_***\_BUILD\Common\munge.bat`
- Addme script: `data_***\addme\mungeAddme.bat`
- ** Sounds: `data_***\_BUILD\Sound\munge.bat` (see note below)

* Note: You will probably have to manually edit your world's munge.bat script in order to munge it. All you have to do is open the script in a text editor like Notepad and change `YAV` to your world's map ID (e.g. `ABC`).

** Note: By default, the sound munge.bat script munges all sound folders specified in `data_***\soundmunge.bat`. Also by default, Zero Munge doesn't automatically detect the outputted LVL files for sound munging, but optionally you can manually edit the Munged Files field for the sound munge.bat file to list the sound LVLs.

### Quickly adding typical munge.bat scripts to the File List

Yes there is! You can click the 'Add Project' button, which will prompt you to select a project directory (e.g. `BF2_ModTools\data_***`) whose typical munge.bat files should be added to the File List. The following files, if found, will be added:

- Common: `data_***\_BUILD\Common\munge.bat`  
- ALL side: `data_***\_BUILD\Sides\ALL\munge.bat`
- CIS side: `data_***\_BUILD\Sides\CIS\munge.bat`
- IMP side: `data_***\_BUILD\Sides\IMP\munge.bat`
- REP side: `data_***\_BUILD\Sides\REP\munge.bat`
- TUR side: `data_***\_BUILD\Sides\TUR\munge.bat`
- Your world (based on `***` in `data_***`): `data_***\_BUILD\World\***\munge.bat`
- Addme: `data_***\addme\mungeAddme.bat`

### Further notes

- If you don't want a file to be executed when you click 'Run', uncheck the 'Process' field in that file's row.
- If you don't want a file's LVL file(s) to be automatically copied over after the file is executed, uncheck the 'Copy' field in that file's row.

## Downloads

[![ZeroMunge-latest-release](https://img.shields.io/github/release/marth8880/ZeroMunge.svg?label=latest%20release&maxAge=300)](https://github.com/marth8880/ZeroMunge/releases/latest)
[![ZeroMunge-latest-downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/latest/total.svg?maxAge=60)](https://github.com/marth8880/ZeroMunge/releases/latest)  
[![ZeroMunge-r146-release](https://img.shields.io/badge/old%20release-r146-lightgrey.svg)](https://github.com/marth8880/ZeroMunge/releases/r146)
![ZeroMunge-r146-downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/r146/total.svg?maxAge=300)  
[![ZeroMunge-r113-release](https://img.shields.io/badge/old%20release-r113-lightgrey.svg)](https://github.com/marth8880/ZeroMunge/releases/r113)
![ZeroMunge-r113-downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/r113/total.svg?maxAge=300)  
[![ZeroMunge-r89-release](https://img.shields.io/badge/old%20release-r89-lightgrey.svg)](https://github.com/marth8880/ZeroMunge/releases/r89)
![ZeroMunge-r89-downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/r89/total.svg?maxAge=300)  
[![ZeroMunge-r78-release](https://img.shields.io/badge/old%20release-r78-lightgrey.svg)](https://github.com/marth8880/ZeroMunge/releases/r78)
![ZeroMunge-r78-downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/r78/total.svg?maxAge=300)  
[![ZeroMunge-r42-release](https://img.shields.io/badge/old%20release-r42-lightgrey.svg)](https://github.com/marth8880/ZeroMunge/releases/r42)
![ZeroMunge-r42-downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/r42/total.svg?maxAge=300)  
[![ZeroMunge-r35-release](https://img.shields.io/badge/old%20release-r35-lightgrey.svg)](https://github.com/marth8880/ZeroMunge/releases/r35)
![ZeroMunge-r35-downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/r35/total.svg?maxAge=300)  
[![ZeroMunge-r31-release](https://img.shields.io/badge/old%20release-r31-lightgrey.svg)](https://github.com/marth8880/ZeroMunge/releases/r31)
![ZeroMunge-r31-downloads](https://img.shields.io/github/downloads/marth8880/ZeroMunge/r31/total.svg?maxAge=300)  
