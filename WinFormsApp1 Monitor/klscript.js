RunTheOtherr()
{
    WinActivate "Kennathon"

    if ImageSearch(& FoundX, & FoundY, 0, 0, 800, 1440, "*180 joinkthon.png")
    {
        if !PixelSearch(& Px, & Py, FoundX, FoundY, FoundX + 152, FoundY + 47, 0xea0500, 3)
        {
            msgbox "found"
            mouseclick "left", FoundX, FoundY
            sleep 3000
            if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*80 marchselectkthon.png")
            {
                mouseclick "left", 200, 1343
                sleep 1000
                mouseclick "left", 531, 1025
                sleep 1000
                mouseclick "left", 535, 1324
                sleep 1000

            }
            else {
                if ImageSearch(& FoundX, & FoundY, 0, 0, 800, 1440, "*100 joinkthon.png")
                {
                }
                else {
                    msgbox "asdf12"
                    Send "{escape}"
                }
            }
        }
        else {
            msgbox "not found red "
        }
    }
    else {
        msgbox "not found"
    }
    sleep 1000

    if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*140 alliancekthon.png")
    {
        mouseclick "left", 372, 808
        sleep 3000
    } else if ImageSearch(& FoundX, & FoundY, 0, 0, 560, 1440, "*50 questkthon.png")
    {
        mouseclick "left", 753, 1063
        sleep 3000
        mouseclick "left", 372, 808
        sleep 3000

    } else if ImageSearch(& FoundX, & FoundY, 0, 0, 760, 1440, "*80 AllianceWarkthon.png")
    {
    }
    else {
        msgbox "asdf3"
        Send "{escape}"
    }
}