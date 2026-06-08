using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class DateShowAction : IMenuItemListener
    {
        public void ReportSelected(MenuItem i_MenuItem)
        {
            Console.WriteLine($"> Current Date is {DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }
}