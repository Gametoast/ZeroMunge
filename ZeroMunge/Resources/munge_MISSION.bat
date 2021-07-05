@echo off
REM WARNING: enabledelayedexpansion means ! is a special character,
REM   which means it isn't available for use as the mungeapp recursive
REM   wildcard character.  Use the alternate $ instead.
REM  Expected to be run from _BUILD\Common\
setlocal enabledelayedexpansion

set MUNGE_ROOT_DIR=..\..
if not "%1"=="" set MUNGE_PLATFORM=%1
if %MUNGE_PLATFORM%x==x set MUNGE_PLATFORM=PC
if %MUNGE_LANGDIR%x==x set MUNGE_LANGDIR=ENG
if "%MUNGE_BIN_DIR%"=="" (
	set MUNGE_BIN_DIR=%CD%\%MUNGE_ROOT_DIR%\..\ToolsFL\Bin
	set "PATH=%CD%\..\..\..\ToolsFL\Bin;%PATH%"
	echo MUNGE_BIN_DIR=!MUNGE_BIN_DIR!
)

set MUNGE_ARGS=-checkdate -continue -platform %MUNGE_PLATFORM%
set SHADER_MUNGE_ARGS=-continue -platform %MUNGE_PLATFORM%
set MUNGE_DIR=MUNGED\%MUNGE_PLATFORM%
set OUTPUT_DIR=%MUNGE_ROOT_DIR%\_LVL_%MUNGE_PLATFORM%

set LOCAL_MUNGE_LOG="%CD%\%MUNGE_PLATFORM%_MungeLog.txt"
if "%MUNGE_LOG%"=="" (
	set MUNGE_LOG=%LOCAL_MUNGE_LOG%
	if exist %LOCAL_MUNGE_LOG% ( del %LOCAL_MUNGE_LOG% )
)


REM ===== Handle files in Common\
set SOURCE_SUBDIR=Common
set SOURCE_DIR=
if not %MUNGE_OVERRIDE_DIR%x==x (
	for %%a in (%MUNGE_OVERRIDE_DIR%) do @set SOURCE_DIR=!SOURCE_DIR! %MUNGE_ROOT_DIR%\%%a\%SOURCE_SUBDIR%
)
set SOURCE_DIR=%SOURCE_DIR% %MUNGE_ROOT_DIR%\%SOURCE_SUBDIR%

REM copy common binary format data from source root \Common
if not exist MUNGED mkdir MUNGED
if not exist %MUNGE_DIR% mkdir %MUNGE_DIR%
echo Copying premunged files from MUNGED...
if exist %MUNGE_ROOT_DIR%\%SOURCE_SUBDIR%\MUNGED xcopy %MUNGE_ROOT_DIR%\%SOURCE_SUBDIR%\MUNGED\*.* %MUNGE_DIR% /D /Q /Y
echo Copying premunged files from %MUNGE_DIR%...
if exist %MUNGE_ROOT_DIR%\%SOURCE_SUBDIR%\%MUNGE_DIR% xcopy %MUNGE_ROOT_DIR%\%SOURCE_SUBDIR%\%MUNGE_DIR%\*.* %MUNGE_DIR% /D /Q /Y

REM @echo on

scriptmunge -inputfile $*.lua %MUNGE_ARGS% -sourcedir %SOURCE_DIR% -outputdir %MUNGE_DIR% 2>>%MUNGE_LOG%
configmunge -inputfile $*.mcfg %MUNGE_ARGS% -sourcedir %SOURCE_DIR% -outputdir %MUNGE_DIR% -hashstrings 2>>%MUNGE_LOG%
@move /y configmunge.log configmunge_mcfg.log

REM ===== Build LVL files

if not exist %MUNGE_ROOT_DIR%\_LVL_%MUNGE_PLATFORM% mkdir %MUNGE_ROOT_DIR%\_LVL_%MUNGE_PLATFORM%
if not exist %MUNGE_ROOT_DIR%\_LVL_%MUNGE_PLATFORM%\COMMON mkdir %MUNGE_ROOT_DIR%\_LVL_%MUNGE_PLATFORM%\COMMON
rem if not exist %MUNGE_ROOT_DIR%\_LVL_%MUNGE_PLATFORM%\COMMON\%MUNGE_LANGDIR% mkdir %MUNGE_ROOT_DIR%\_LVL_%MUNGE_PLATFORM%\COMMON\%MUNGE_LANGDIR%

@echo on
levelpack -inputfile MISSION\*.req -common %MUNGE_DIR%\core.files %MUNGE_DIR%\common.files %MUNGE_DIR%\ingame.files %MUNGE_ARGS% -sourcedir %SOURCE_DIR% -inputdir %MUNGE_DIR% -outputdir %MUNGE_DIR% 2>>%MUNGE_LOG%
@move /y levelpack.log levelpack_missions.log
levelpack -inputfile MISSION.req %MUNGE_ARGS% -sourcedir %SOURCE_DIR% -inputdir %MUNGE_DIR% -outputdir %OUTPUT_DIR% 2>>%MUNGE_LOG%
@move /y levelpack.log levelpack_mission.log
@echo off

call munge_fpm.bat %MUNGE_PLATFORM%

@set BAT_PATH=%~p0
@set WORLD_NAME=%BAT_PATH:~-18,3%

@REM If the munge log was created locally and has anything in it, view it
@if not %MUNGE_LOG%x==%LOCAL_MUNGE_LOG%x goto skip_mungelog
@set FILE_CONTENTS_TEST=
@if exist %MUNGE_LOG% for /f %%i in (%MUNGE_LOG:"=%) do @set FILE_CONTENTS_TEST=%%i
@if not "%FILE_CONTENTS_TEST%"=="" ( Notepad.exe %MUNGE_LOG% ) else ( if exist %MUNGE_LOG% (del %MUNGE_LOG%) )

:skip_mungelog
endlocal
