# Changelog

All notable changes to Zero Munge will be documented in this file. Numbers enclosed in parentheses (#1) refer to [GitHub issues](https://github.com/marth8880/ZeroMunge/issues).

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/).

## [v1.0.0-beta] - 2018-06-27

### Added

- On application exit, the file list is automatically saved; with this functionality comes a user preference to disable it (#19)
- On application startup, the last-loaded file list is automatically loaded; with this functionality comes a user preference to disable it (#14)
- Buttons in the tray icon context menu to start and abort execution of the file list (#28)
- User preference to specify the Output Log's maximum line count (#26)
- Pre-exit prompt to save dirty file list if auto-save is disabled (#29)
- "Open Recent" sub-menu that lists the last 10 recently-opened files (#24)

### Changed

- Vastly improved Output Log performance by having it only update once every N milliseconds, and added a user preference to specify N
- When a (checkbox) setting that is a dependent of other settings is unticked, those dependent settings are also unticked
- All log messages that refer to file paths and directories now wrap the paths in quotes
- In the About window, replaced the "Frayed Wires Studios" link with a link to open a dialog listing all of the third-party software that is used in Zero Munge (#30)
- Application DLLs are now stored in and loaded from `ZeroMunge\lib`
- "Report a Bug" and "Provide a Suggestion" menu links now take the user to the correct issue template form for each 

### Fixed

- Exception thrown when application checks for updates while minimized
- When user starts a new file list out of the File menu, the file list's current contents aren't cleared (#20)
- Exception thrown when loading save file that contains empty file list (#22)
- Main window's title doesn't reflect the current file when a save file is opened (#27)
- File List isn't marked as dirty when rows are removed
- Various logic issues with save flow

## [r146] - 2018-03-26

### Added

- When an update is available, the build num/date, download link, and release notes are printed to the Output Log on application load
- If GameDirectory is unset, user is prompted on application load to set it (#15)
- Menu items to check for updates, report bugs, provide suggestions, view all open issues, and view changelog/license/readme files (#17)
- User preference to toggle whether application should check for updates on startup

### Changed

- Output Log now updates at a timed interval when a job is running, fixing its performance issues
- 'Remove' button now removes all selected rows instead of only the last-selected row (#13)
- User can now target any executable when setting GameDirectory

### Fixed

- Stray sub-REQs are added to the Munged Files list for side REQs (#4)
- Copy/Cut/Paste/Select All/Delete key combos in Munged Files Edit window don't do anything (#7)
- Out-of-date tooltip text for 'Check for updates' link (#9)
- Exception thrown when attempting to commit an empty Munged Files list (#5)
- Exception thrown when a job finishes that contains an empty Munged Files list (#6)
- 'Add Files...' button updates the selected row instead of always inserting a new row (#11)
- 'Remove All' button doesn't always remove all rows from the file list (#12)
- Exception thrown when attempting to save a file list with an empty row (#16)
- Exception thrown when update URL domain can't be resolved during update check