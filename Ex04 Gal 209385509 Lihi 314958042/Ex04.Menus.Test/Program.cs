namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfaceMenuTest interfaceMenuTest = new InterfaceMenuTest();
            interfaceMenuTest.Show();
            
            EventsMenuTest eventsMenuTest = new EventsMenuTest();
            eventsMenuTest.Show();
        }
    }
}