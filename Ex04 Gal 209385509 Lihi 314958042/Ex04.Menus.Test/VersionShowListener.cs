using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class VersionShowListener : IMenuItemListener
    {
        private const string k_Version = "26.2.4.7310";
        
        public void ReportSelect(MenuItem i_MenuItem)
        {
            Console.WriteLine($"App Version: {k_Version}");
        }
    }
}