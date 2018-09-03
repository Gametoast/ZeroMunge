![Zero Munge](images/app_banner.jpg)

**Zero Munge v1.1.0-beta**  
**Copyright © 2018 Aaron Gilbert. All rights reserved.**    
[**View project on GitHub**](https://github.com/marth8880/ZeroMunge)

## What it is

The goal of Zero Munge is to act as a robust replacement for VisualMunge, the automated build tool provided with the SWBF2 mod tools.  

It is written in Visual C# for [**.NET Framework 4**](https://www.microsoft.com/en-us/download/details.aspx?id=17718).

## What it does

At its core, Zero Munge goes through a user-specified list of munge.bat files and executes each one at a time and copies the associated LVL files to the appropriate staging directory.  

Zero Munge includes the following features.

- Sequentially execute a list of munge scripts and any other batch scripts
- Toggle whether or not certain scripts in the list will be executed ([**GO**](topic_ui_filelist.html))
- Log each script's output in real-time (with timestamps) to a log window and log file
- Various methods of adding munge scripts to the file list ([**GO**](topic_gs.html#adding-munge-scripts-to-the-file-list))
- Automatically copy each file's associated LVL file(s) to the appropriate directory
- Easily create the munge folders/scripts for a side or world ([**GO**](topic_cmd_tools.html))
- Apply the sound munge fix to a project directory ([**GO**](topic_cmd_tools.html))
- Visual interface for modifying which sound folders get munged when sound is munged ([**GO**](topic_cmd_tools.html))
- Save and load different "presets" of the file list's contents
- Auto-save and auto-load functionality for save files
- Automatically check for updates and point user to latest release's download page

## Help sections

Click on a link below to view the help information for that topic.

- [**Getting Started**](topic_gs.html)
- [**User Interface**](topic_ui.html)
- [**Commands**](topic_cmd.html)