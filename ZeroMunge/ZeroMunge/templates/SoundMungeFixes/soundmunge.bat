@if %1x==x goto noplatform
@set MUNGE_PLATFORM=%1
@set MUNGE_DIR=MUNGED\%MUNGE_PLATFORM%
@rem EDIT THE LINE BELOW TO POINT TO YOUR BF2 INTSALL PATH
@set BF2_SOUNDPATH="c:\Program Files\LucasArts\Star Wars Battlefront II\"

@rem Munge global, shell and side specific sound data
::@call soundmungedir _BUILD\sound\cw\%MUNGE_DIR%     sound\cw     sound\cw\%MUNGE_PLATFORM%     %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound cw
::@call soundmungedir _BUILD\sound\gcw\%MUNGE_DIR%    sound\gcw    sound\gcw\%MUNGE_PLATFORM%    %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound gcw
::@call soundmungedir _BUILD\sound\global\%MUNGE_DIR% sound\global sound\global\%MUNGE_PLATFORM% %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound global nolevelfile
::@call soundmungedir _BUILD\sound\shell\%MUNGE_DIR%  sound\shell  sound\shell\%MUNGE_PLATFORM%  %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound shell
@rem Munge world specific sound data
::@call soundmungedir _BUILD\sound\worlds\@#$\%MUNGE_DIR% sound\worlds\@#$ sound\worlds\@#$\%MUNGE_PLATFORM% %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound @#$

xcopy _LVL_%MUNGE_PLATFORM%\sound\*  %BF2_SOUNDPATH%GameData\addon\@#$\data\_LVL_PC\Sound\ /Y

@goto exit
:noplatform
@echo Platform must be specified as the first argument
:exit