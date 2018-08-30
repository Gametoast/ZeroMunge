@rem Save the starting directory
@for /F %%A in ('cd') do @set STARTDIR=%%A

@if %1x==x goto nomungedir
@if %2x==x goto nosourcedir
@if %3x==x goto nooverridedir
@if %4x==x goto noplatform
@if %5x==x goto nomungelogdir
@if %6x==x goto noleveldir
@if %7x==x goto nolevelsrcdir
@if %8x==x goto nolevelfile

@rem Setup directories
@set MUNGEDIR=%STARTDIR%\%1
@set SOURCEDIR=%STARTDIR%\%2
@set PLATFORMDIR=%STARTDIR%\%3
@set LOGDIR=%STARTDIR%\%5
@set LEVELDIR=%STARTDIR%\%6
@set LEVELFILEREQ=%8%.req
@set LEVELFILELVL=%MUNGEDIR%\%8%.lvl
@set CHECKDATE=-checkdate
@set CHECKID=-checkid
@if %SOUNDNODATECHECK%x==1x @set CHECKDATE=

@rem Build up a list of directories for level pack to search for source files
@Setlocal enabledelayedexpansion 
@set LEVELSRCDIR=
@set PATH="%CD%"\..\ToolsFL\Bin;%PATH%

@rem Should we munge this level ?
@if /i not "%SOUNDLVL%"=="" (
	@for %%A in (%SOUNDLVL%) do @if /i "%%A"=="%8" @goto mungeit
	@goto exit
)
:mungeit

@if "%MUNGE_LOG%"=="" set MUNGE_LOG=%LOGDIR%\%4%_MungeLog.txt

@if not EXIST %SOURCEDIR% (
	@echo Unable to munge %SOURCEDIR% as it doesn't exist! 1>> %MUNGE_LOG%  
	@goto exit 
)

@REM goto nodebug
@echo Current Directory           = %CD%
@echo Sound level filter          = %SOUNDLVL%
@echo Munge output directory      = %MUNGEDIR%
@echo Source directory            = %SOURCEDIR%
@echo Platform override directory = %PLATFORMDIR%
@echo Selected platform           = %4
@echo Munge logs directory        = %LOGDIR%
@echo Level file output directory = %LEVELDIR%
@echo Final req file              = %LEVELFILEREQ%
@echo Output level file           = %LEVELFILELVL%
@echo Additional stream options   = %STREAMOPT%
@REM pause
:nodebug

@if EXIST %MUNGEDIR% goto skipcreatemungedir
@mkdir %MUNGEDIR%
:skipcreatemungedir

@cd %SOURCEDIR%

@rem Munge configuration files
@rem *.snd - sound library
@rem *.mus - dynamic music configuration
@rem *.ffx - foley effects
@rem *.tsr - sound regions
@configmunge -inputfile *.snd *.mus *.ffx *.tsr -platform %4 -sourcedir %PLATFORMDIR% %SOURCEDIR% -outputdir %MUNGEDIR% -hashstrings %CHECKDATE% -continue 2>>%MUNGE_LOG% 

@if %SOUNDLOG%x==1x ( @set SOUNDOPT=-verbose & @set SOUNDLOGOUT=%LOGDIR%\SoundBankLog.txt ) else ( @set SOUNDOPT= & @set SOUNDLOGOUT=NUL )

@rem Munge sound banks
@for /R %%A in (*.sfx) do @echo Munging %%~nA%%~xA & @soundflmunge -platform %4 -banklistinput %%A -bankoutput %MUNGEDIR%\ %CHECKDATE% -resample %CHECKID% noabort %SOUNDOPT% %BANKOPT% 2>>%MUNGE_LOG% 1>>%SOUNDLOGOUT%
@for /R %%A in (*.asfx) do @echo Munging %%~nA%%~xA & @soundflmunge -platform %4 -banklistinput %%A -bankoutput %MUNGEDIR%\ %CHECKDATE% -resample -checkid noabort %SOUNDOPT% 2>>%MUNGE_LOG% 1>>%SOUNDLOGOUT%

@rem Munge streams

@rem Localization
@rem Setup the extension of localized stream files (if it's english we'll just use the default extension)
@set LANGVERSION=
@rem @for /F %%A in (%MUNGE_LANGVERSION%) do @set LANGVERSION=%%~A
@set LANGVERSION=%MUNGE_LANGVERSION%
@if /i %LANGVERSION%x==Englishx ( @set LOCALIZEEXT= ) else ( @set LOCALIZEEXT=stm_%LANGVERSION% )

@rem make the directory for language-specific stuff if it doesn't exist - H8 h8 h8!
@if EXIST %MUNGEDIR%\%LANGVERSION% goto skipcreatelangdir
@echo Creating dir %MUNGEDIR%\%LANGVERSION%\
@mkdir %MUNGEDIR%\%LANGVERSION%
:skipcreatelangdir

@rem Munge localized stream files
@if /i not %MUNGESTREAMS%x==0x @if /i not %LANGVERSION%x==Englishx @for /R %%A in (*.%LOCALIZEEXT%) do @echo Munging %%~nA%%~xA to %MUNGEDIR%\%LANGVERSION%\ & soundflmunge -platform %4 -banklistinput %%A -bankoutput %MUNGEDIR%\%LANGVERSION%\%%~nA.str -stream %CHECKDATE% -resample %CHECKID% noabort %SOUNDOPT% %STREAMOPT% 2>>%MUNGE_LOG% 1>>%SOUNDLOGOUT%

@set MUNGE2SUBSTREAMS=0
@if /i %4==XBOX @set MUNGE2SUBSTREAMS=1
@if /i %4==PC   @set MUNGE2SUBSTREAMS=1

@rem Build up a list of 1 substream streams to munge, 
@rem Filtering the localize streams and if on xbox 4 channel streams 
@set MUNGESUBSTREAM1=
@if /i not %MUNGESTREAMS%x==0x @for /R %%A in (*.stm) do @if /i %%~xA==.stm ( @if not EXIST %%~dA%%~pA%%~nA.%LOCALIZEEXT% ( @if /i %MUNGE2SUBSTREAMS%==1 ( @if not EXIST %%~dA%%~pA%%~nA.st4 @set MUNGESUBSTREAM1=!MUNGESUBSTREAM1! %%A ) else ( @set MUNGESUBSTREAM1=!MUNGESUBSTREAM1! %%A ) ) )

@rem Munge 1 substream streams
@if /i not %MUNGESTREAMS%x==0x @for %%A in (%MUNGESUBSTREAM1%) do @echo Munging %%~nA%%~xA & soundflmunge -platform %4 -banklistinput %%A -bankoutput %MUNGEDIR%\ -stream %CHECKDATE% -resample %CHECKID% noabort %SOUNDOPT% %STREAMOPT% 2>>%MUNGE_LOG% 1>>%SOUNDLOGOUT%

@rem Munge 2 substream streams
@if /i not %MUNGESTREAMS%x==0x @if %MUNGE2SUBSTREAMS%==1 @for /R %%A in (*.st4) do @echo Munging %%~nA%%~xA & soundflmunge -platform %4 -banklistinput %%A -bankoutput %MUNGEDIR%\ -stream %CHECKDATE% -resample %CHECKID% noabort %SOUNDOPT% %STREAMOPT% -substream 2 2>>%MUNGE_LOG% 1>>%SOUNDLOGOUT%

@rem Build level files
@if EXIST %LEVELDIR% goto skipcreateleveldir
@mkdir %LEVELDIR%
:skipcreateleveldir

@if %SOUNDNOLVL%x==1x @goto exit

@rem build up a list of include directories for levelpack
@rem language overrides first!
@if %LANGVERSION%x==x goto skiplang
@for /F %%A in ('dir /AD /B %STARTDIR%\%7') do @set LANGSRCDIR=!LANGSRCDIR! %STARTDIR%\%7\%%A\MUNGED\%4\%LANGVERSION%
@for /F %%A in ('dir /AD /B %STARTDIR%\%7\Worlds') do @set LANGSRCDIR=!LANGSRCDIR! %STARTDIR%\%7\Worlds\%%A\MUNGED\%4\%LANGVERSION%
:skiplang

@for /F %%A in ('dir /AD /B %STARTDIR%\%7') do @set LEVELSRCDIR=!LEVELSRCDIR! %STARTDIR%\%7\%%A\MUNGED\%4
@for /F %%A in ('dir /AD /B %STARTDIR%\%7\Worlds') do @set LEVELSRCDIR=!LEVELSRCDIR! %STARTDIR%\%7\Worlds\%%A\MUNGED\%4

@for /R %%A in (*.req) do @if /i not %%A==%SOURCEDIR%\%LEVELFILEREQ% levelpack -inputfile %%~nA%%~xA -platform %4 -sourcedir %SOURCEDIR% %LANGSRCDIR% %PLATFORMDIR% -inputdir %LEVELSRCDIR% -outputdir %MUNGEDIR% -continue %CHECKDATE%

@if EXIST %LEVELFILEREQ% levelpack -inputfile %LEVELFILEREQ% -platform %4 -sourcedir %SOURCEDIR% %LANGSRCDIR% %PLATFORMDIR% -inputdir %LEVELSRCDIR% -outputdir %LEVELDIR% -continue %CHECKDATE%

@goto exit

:nomungedir
@echo Munge directory must be specified as the first argument
@goto exit
:nosourcedir
@echo Source data directory must be specified as the second argument
@goto exit
:nooverridedir
@echo Platform specific source data directory must be specified as the third argument
@goto exit
:noplatform
@echo Platform must be specified as the fourth argument
@goto exit
:nomungelogdir
@echo Munge log directory must be specified as the fifth argument
@goto exit
:noleveldir
@echo Level output directory must be specified as the sixth argument
@goto exit
:nolevelsrcdir
@echo Level source direct must be specified as the seventh argument
@goto exit
:nolevelfile
@echo Final output level file must be specified as the eighth argument
@goto exit
:exit
@endlocal
@cd %STARTDIR%