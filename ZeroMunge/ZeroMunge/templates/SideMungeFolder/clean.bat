@if "%1"=="" (
	del /q MUNGED\PS2\*.*
	del /q MUNGED\PC\*.*
	del /q MUNGED\XBOX\*.*
) else (
	del /q MUNGED\%1\*.*
)

