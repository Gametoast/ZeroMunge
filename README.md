#Overview
##What it is
The goal of this tool is to act as a robust replacement for VisualMunge (the automation tool provided with the SWBF2 mod tools).  

It is written in Visual C# for [.NET Framework 4.5.2](https://www.microsoft.com/en-us/download/details.aspx?id=42642).

##What it does
At its core, this tool goes through a user-specified list of munge.bat files and executes each one after the previous is finished.  

This tool can be used to do the following things. Completed features are **bolded**.
* **Execute a list of batch files recursively**
* **Toggle whether or not certain files will be executed**
* **Log each file's output in real-time (with timestamps)**
* **Clear the contents of the output log / copy its contents to the clipboard / save its contents to a file**
* **Auto-detect the munge.bat file inside a selected folder and add it to the file list**
* **Add the common munge.bat files for an entire project to the file list**
* For each file, copy the associated LVL file to another directory
* Save and load different "presets" of the file list's contents and toggle values