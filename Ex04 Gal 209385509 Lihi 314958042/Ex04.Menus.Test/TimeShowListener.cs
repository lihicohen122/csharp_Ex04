using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class TimeShowListener : IMenuItemListener
    {
        public void ReportSelect(MenuItem i_MenuItem)
        {
            Console.WriteLine($"> Current Time is {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }
}