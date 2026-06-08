using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class VersionShowAction : IMenuItemListener
    {
        public void ReportSelected(MenuItem i_MenuItem)
        {
            Console.WriteLine("App Version: 26.2.4.7310");
        }
    }
}