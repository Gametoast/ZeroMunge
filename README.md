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

- Sequentially execute a list of munge scripts and any other batch scripts
- Toggle whether or not certain scripts in the list will be executed
- Log each script's output in real-time (with timestamps) to a log window and log file
- Various methods of adding munge scripts to the file list
- Automatically copy each file's associated LVL file(s) to the appropriate directory
- Easily create the munge folders/scripts for a side or world
- Apply the sound munge fix to a project directory
- Visual interface for modifying which sound folders get munged when sound is munged
- Save and load different "presets" of the file list's contents
- Auto-save and auto-load functionality for save files
- Automatically check for updates and point user to latest release's download page

## How to use it

Please see the [Getting Started](https://github.com/marth8880/ZeroMunge/wiki/Getting-Started) page.