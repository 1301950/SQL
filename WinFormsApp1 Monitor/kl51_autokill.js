#z:: ExitApp	;Win + Z

WinActivate "kendo v5"

mouseclick "left", 70, 1087
sleep 1000
mouseclick "left", 657, 188
sleep 1000

loop
{
	mouseclick "left", 114, 394
	sleep 1000

	loop
	{
		mouseclick "left", 386, 707
		sleep 1000
		if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*120 attack.png")
		{
			mouseclick "left", 200, 593
			sleep 1000
				; mouseclick "left", 206, 952; lvl1 pan

			mouseclick "left", 175, 1035		; junior cerb
			sleep 2000

			if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*120 marchselect.png")
			{
				; select march slot
				mouseclick "left", 255, 184
				sleep 1000
				mouseclick "left", 132, 424
				sleep 1000
				mouseclick "left", 388, 199
				sleep 1000
				mouseclick "left", 626, 755
				sleep 1000

					; send march
				mouseclick "left", 565, 1328
				sleep 1000

				BackToListAndDelete()
				break
			}
		}
		else {
			BackToListAndDelete()
			break
		}
	}


}

BackToListAndDelete()
{
	; back to list
	mouseclick "left", 70, 1087
	sleep 1000
	mouseclick "left", 657, 188	; select enemy list
	sleep 1000
		; delete the first one
	mouseclick "left", 488, 431
	sleep 1000
		; confirm
	mouseclick "left", 511, 839
	sleep 1000
}