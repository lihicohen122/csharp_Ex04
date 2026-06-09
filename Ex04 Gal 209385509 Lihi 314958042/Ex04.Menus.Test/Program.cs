namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfaceMenuTest interfaceMenuTest = new InterfaceMenuTest();
            EventsMenuTest eventsMenuTest = new EventsMenuTest();

            interfaceMenuTest.Show();
            eventsMenuTest.Show();
        }
    }
}