![Zero Munge](images/app_banner.jpg)

**Zero Munge v1.0.0-beta**  
**Copyright © 2018 Aaron Gilbert. All rights reserved.**    
[**View project on GitHub**](https://github.com/marth8880/ZeroMunge)

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