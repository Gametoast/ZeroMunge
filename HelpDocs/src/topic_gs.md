## Getting Started

This page will guide you through the basics of using Zero Munge.

- [**Preamble**](#preamble-understanding-the-munge-process)
- [**How to use it**](#alright-so-how-do-i-use-it-)
- [**Adding munge scripts to the File List**](#adding-munge-scripts-to-the-file-list)
- [**Further notes**](#further-notes)

### Preamble: Understanding the munge process

The first thing you need to understand is that VisualMunge does not munge things; it executes batch scripts that execute the necessary logic to turn raw assets into LVL files. The flow of how it works is this: 

1. In VisualMunge, the user selects what should be munged (sides/worlds/etc.). The user then clicks 'Munge'.
2. VisualMunge sequentially executes the munge.bat scripts for each item that the user selected.
3. Each munge.bat script calls the appropriate compiler executables out of `BF2_ModTools\ToolsFL` (like `scriptmunge.exe` for Lua scripts or `texturemunge.exe` for TGA textures) to convert the raw assets into compiled files, which are put in the appropriate munge directory (like `data_***\_BUILD\Sides\REP\Munged\PC`). In most cases, the munge.bat script then calls `levelpack.exe`, which packs those compiled files into a single LVL file that is able to be read by the game.

At its core, Zero Munge essentially does the same thing that VisualMunge does - except you're given far more control over what you want to munge. How so? You're able to specify all the individual munge.bat scripts to execute, and optionally Zero Munge will also copy over the LVL file(s) associated with each munge.bat script to the correct folder in your project's addon directory.

### Alright, so how do I use it?

Using Zero Munge is fairly easy - to munge something, all you do is add the desired munge.bat scripts to the File List and press 'Run':

1. Add munge scripts to the File List. (See section: [**Adding munge scripts to the File List**](#adding-munge-scripts-to-the-file-list))
2. Click the 'Run' button to have Zero Munge sequentially execute each file in the File List and optionally copy the associated LVL files to your project's addon directory.

Examples of munge scripts:

- REP side: `data_***\_BUILD\Sides\REP\munge.bat`
- Your world: `data_***\_BUILD\Worlds\***\munge.bat` (see section: [**Further notes**](#further-notes))
- Common: `data_***\_BUILD\Common\munge.bat`
- Addme script: `data_***\addme\mungeAddme.bat`
- Sounds: `data_***\_BUILD\Sound\munge.bat` (see section: [**Further notes**](#further-notes))

See the next section for all the different methods with which you can add munge scripts to the File List.

### Adding munge scripts to the File List

#### Method #1

As of v1.1.0-beta, you can use the [**Easy File Picker**](topic_ui_easyfilepicker.html) to get a hierarchical overview of a project directory and select which items you want to add to the File List. 

To use the Easy File Picker, click the 'Easy File Picker' button in the main window - a pop-up will open where you'll browse for your project's directory (e.g. `BF2_ModTools\data_***`), hit OK, and Zero Munge will scan the directory for all munge.bat scripts. These munge.bat scripts will be displayed as a hierarchy (much like how a project directory is laid out) from which you will be able to select which files to add to the File List.

#### Method #2

The "rawest" method of adding munge scripts to the File List is with the 'Add Files' button. You simply click the button, browse for a munge.bat script, and click open - the file will then be added to the File List.

For example, if you wanted to add the munge.bat script for the CIS side, you'd click 'Add Files', browse to `data_***\_BUILD\Sides\CIS`, select the munge.bat file, and click 'Open' - the munge script for the CIS side would then be added to the File List.

#### Method #3

You can click the 'Add Folders' button to select folders containing munge.bat scripts to add. This is almost identical to [**Method #2**](#method-2), except you're selecting folders instead of individual munge.bat scripts. The benefit to this is that you can easily select multiple folders each containing a munge.bat script and all of those folders' munge.bat scripts will be added.

For example, if you wanted to add the munge.bat scripts for the CIS and REP sides in one action, you'd click 'Add Folders', browse to `data_***\_BUILD\Sides`, select the CIS and REP folders, and click 'Open' - the munge.bat scripts for the CIS and REP sides would then be added to the File List.

#### Method #4

To add a project's typical munge.bat files to the File List, you can do so by clicking the 'Add Project' button, which will prompt you to select a project directory (e.g. `BF2_ModTools\data_***`) whose typical munge.bat files should be added to the File List. The following files, if found, will be added:

- Common: `data_***\_BUILD\Common\munge.bat`  
- ALL side: `data_***\_BUILD\Sides\ALL\munge.bat`
- CIS side: `data_***\_BUILD\Sides\CIS\munge.bat`
- IMP side: `data_***\_BUILD\Sides\IMP\munge.bat`
- REP side: `data_***\_BUILD\Sides\REP\munge.bat`
- TUR side: `data_***\_BUILD\Sides\TUR\munge.bat`
- Your world (based on `***` in `data_***`): `data_***\_BUILD\World\***\munge.bat`
- Addme: `data_***\addme\mungeAddme.bat`

### Further notes

- For custom worlds, you will probably have to fix your world's munge.bat script in order to munge it. As of v1.1.0-beta, you can easily do this by selecting [**Fix World Munge File**](topic_menu_tools.html) from the 'Tools' menu - a pop-up will open where you'll browse for your world's folder (either in `data_***\_BUILD\Worlds` or in `data_***\Worlds`), hit OK, and it'll fix it for you. Alternatively you can fix it manually by opening the munge.bat script in a text editor like Notepad and changing `YAV` to your world's map ID (e.g. `ABC`). Please also note that you only have to do this once for a world's munge script.
- By default, the sound munge.bat script munges all sound folders specified in `data_***\soundmunge.bat`. Also by default, Zero Munge doesn't automatically detect the outputted LVL files for sound munging, but optionally you can manually edit the Munged Files field for the sound munge.bat file to list the sound LVLs.
- If you don't want a file to be executed when you click 'Run', uncheck the 'Process' field in that file's row.
- If you don't want a file's LVL file(s) to be automatically copied over after the file is executed, uncheck the 'Copy' field in that file's row.

### Related Pages

- [**Menu: Tools**](topic_menu_tools.html)
- [**User Interface**](topic_ui.html)
- [**User Interface: File List**](topic_ui_filelist.html)
- [**User Interface: Easy File Picker**](topic_ui_easyfilepicker.html)