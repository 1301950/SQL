WinActivate "scanner 305"

loop
{
    if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*180 join.png")
    {
        if !PixelSearch(& Px, & Py, FoundX, FoundY, FoundX + 152, FoundY + 47, 0xea0500, 3)
        {
            mouseclick "left", FoundX, FoundY
            sleep 1000

            if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*120 marchselect.png")
            {
                ; msgbox "found"
                mouseclick "left", 161, 177
                sleep 1000
                mouseclick "left", 125, 780
                sleep 1000
                mouseclick "left", 383, 200
                sleep 1000

                mouseclick "left", 620, 1245
                sleep 1000
                mouseclick "left", 535, 1324
                sleep 500
            }
        }
    }
    sleep 1000
    if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*140 quest.png")
    {
        mouseclick "left", 691, 1056
        sleep 2000
        mouseclick "left", 204, 796
        sleep 2000
    }
    if ImageSearch(& FoundX, & FoundY, 0, 0, 2560, 1440, "*160 alliance.png")
    {
        mouseclick "left", 430, 810
        sleep 1000
    }
}