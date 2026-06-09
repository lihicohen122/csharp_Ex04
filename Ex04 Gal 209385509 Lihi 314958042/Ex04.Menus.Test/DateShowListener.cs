using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class DateShowListener : IMenuItemListener
    {
        public void ReportSelect(MenuItem i_MenuItem)
        {
            Console.WriteLine($"Current Date is {DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }
}