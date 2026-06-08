using System;

namespace Ex04.Menus.Test
{
    public class TimeShowAction : IMenuItemListener
    {
        public void ReportSelected(MenuItem i_MenuItem)
        {
            Console.WriteLine($"> Current Time is {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }
}