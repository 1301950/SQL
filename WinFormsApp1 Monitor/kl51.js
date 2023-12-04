

loop
{
    WinActivate "kendo v5"
    if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*120 join.png")
   {
        if !PixelSearch(& Px, & Py, FoundX, FoundY, FoundX + 152, FoundY + 47, 0xea0500, 3)
            {
            mouseclick "left", FoundX, FoundY
            sleep 2000

            if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*120 marchselect.png")
            {
                mouseclick "left", 161, 182
                sleep 3000
                mouseclick "left", 125, 780
                sleep 1000
                mouseclick "left", 383, 200
                sleep 1000

                mouseclick "left", 620, 1245
                sleep 1000
                mouseclick "left", 535, 1324
                sleep 5000
            }
            else {
                if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*120 join.png")
                {
                }
                else {
                    Send "{escape}"
                }
            }
        }
    }
    sleep 1000
    if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*80 alliance.png")
    {
        mouseclick "left", 237, 808
        sleep 3000
    } else if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*80 quest.png")
    {
        mouseclick "left", 753, 1063
        sleep 3000
        mouseclick "left", 237, 808
        sleep 3000

    } else if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*80 AllianceWar.png")
    {
    }
    else {
        Send "{escape}"
    }
}