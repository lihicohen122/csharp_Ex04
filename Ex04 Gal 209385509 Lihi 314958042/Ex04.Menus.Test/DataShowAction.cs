using System;

namespace Ex04.Menus.Test
{
    public class DataShowAction : IMenuItemListener
    {
        public void ReportSelected(MenuItem i_MenuItem)
        {
            Console.WriteLine($"> Current Date is {DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }
}