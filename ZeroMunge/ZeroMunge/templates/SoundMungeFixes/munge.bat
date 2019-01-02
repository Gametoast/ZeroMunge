@REM WARNING: enabledelayedexpansion means ! is a special character,
@REM   which means it isn't available for use as the mungeapp recursive
@REM   wildcard character.  Use the alternate $ instead.
@setlocal enabledelayedexpansion

@set MUNGE_ROOT_DIR=..\..
@if not "%1"=="" set MUNGE_PLATFORM=%1
@if %MUNGE_PLATFORM%x==x set MUNGE_PLATFORM=PC
REM @if "%MUNGE_BIN_DIR%"=="" (
	@set MUNGE_BIN_DIR=%CD%\%MUNGE_ROOT_DIR%\..\ToolsFL\Bin
	@set PATH=%CD%\..\..\..\ToolsFL\Bin;%PATH%
REM	@echo MUNGE_BIN_DIR=!MUNGE_BIN_DIR!
REM )

@rem convert to lower case
@if %MUNGE_PLATFORM%==PC   set MUNGE_PLATFORM=pc
@if %MUNGE_PLATFORM%==XBOX set MUNGE_PLATFORM=xbox
@if %MUNGE_PLATFORM%==PS2  set MUNGE_PLATFORM=ps2

@set MUNGE_DIR=MUNGED\%MUNGE_PLATFORM%

@set LOCAL_MUNGE_LOG="%CD%\%MUNGE_PLATFORM%_MungeLog.txt"
@if "%MUNGE_LOG%"=="" (
	@set MUNGE_LOG=%LOCAL_MUNGE_LOG%
	@if exist %LOCAL_MUNGE_LOG% ( del %LOCAL_MUNGE_LOG% )
)
@rem echo ********************************************************************* >> %MUNGE_LOG%
@rem echo Sound\munge.bat %MUNGE_PLATFORM% >> %MUNGE_LOG%
@rem echo MUNGE_BIN_DIR=%MUNGE_BIN_DIR% >> %MUNGE_LOG%
@rem echo ********************************************************************* >> %MUNGE_LOG%

@cd ..\..

@if not exist _LVL_%MUNGE_PLATFORM% mkdir _LVL_%MUNGE_PLATFORM%
@if not exist _LVL_%MUNGE_PLATFORM%\Sound mkdir _LVL_%MUNGE_PLATFORM%\Sound

@if /i %MUNGE_PLATFORM%==pc @set BANKOPT=-template

@call soundmunge.bat %MUNGE_PLATFORM%
@if %SOUNDCLEANLVL%x==1x @del /S /Q _BUILD\sound\*.lvl & @call soundmunge.bat %MUNGE_PLATFORM%

@if /i not "%SOUNDLVL%"=="" (
	@for %%A in (%SOUNDLVL%) do @if /i "%%A"=="global" @goto buildglobalbank
	@goto skipglobalbank
)
:buildglobalbank
@rem Build a global sound bank...
@set BANKLIST=
@for /R %%A in (*.sfx) do @set BANKLIST=!BANKLIST! %%A
@if %SOUNDLOG%x==1x ( @set SOUNDOPT=-verbose & @set SOUNDLOGOUT=%LOGDIR%\SoundBankLog.txt ) else ( @set SOUNDOPT= & @set SOUNDLOGOUT=NUL )

@if not %MUNGE_PLATFORM%==pc goto skipglobalbank
@echo Munging common.bnk, this could take a while...
@soundflmunge -platform %MUNGE_PLATFORM% -banklistinput %BANKLIST% -bankoutput _LVL_%MUNGE_PLATFORM%\Sound\common.bnk -checkdate -resample -compact nowarning -checkid noabort -relativepath %SOUNDOPT% 2>>%MUNGE_LOG% 1>>%SOUNDLOGOUT%

:skipglobalbank

@cd _BUILD\Sound

@REM If the munge log was created locally and has anything in it, view it
@if not %MUNGE_LOG%x==%LOCAL_MUNGE_LOG%x goto skip_mungelog
@set FILE_CONTENTS_TEST=
@if exist %MUNGE_LOG% for /f %%i in (%MUNGE_LOG:"=%) do @set FILE_CONTENTS_TEST=%%i

:skip_mungelog

@rem convert to upper case
@if %MUNGE_PLATFORM%==pc   set MUNGE_PLATFORM=PC
@if %MUNGE_PLATFORM%==xbox set MUNGE_PLATFORM=XBOX
@if %MUNGE_PLATFORM%==ps2  set MUNGE_PLATFORM=PS2

@endlocal
