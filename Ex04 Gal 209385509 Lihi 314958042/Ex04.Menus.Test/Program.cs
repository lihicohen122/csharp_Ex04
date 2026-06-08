using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            runInterfaceMenuDemo();
            runEventsMenuDemo();
        }

        private static void runInterfaceMenuDemo()
        {
            Interfaces.MainMenu interfaceMenu = new Interfaces.MainMenu("Interfaces Main Menu");
            Interfaces.MenuItem dateTimeSubMenu = new Interfaces.MenuItem("Show Current Date/Time");
            Interfaces.MenuItem dateItem = new Interfaces.MenuItem("Show Current Date");
            Interfaces.MenuItem timeItem = new Interfaces.MenuItem("Show Current Time");
            Interfaces.MenuItem versionSubMenu = new Interfaces.MenuItem("Version and Capitals");
            Interfaces.MenuItem capitalsItem = new Interfaces.MenuItem("Count Capitals");
            Interfaces.MenuItem versionItem = new Interfaces.MenuItem("Show Version");

            dateItem.AttachObserver(new DateShowAction());
            timeItem.AttachObserver(new TimeShowAction());
            capitalsItem.AttachObserver(new CapitalsCountAction());
            versionItem.AttachObserver(new VersionShowAction());
            dateTimeSubMenu.AddSubItem(dateItem);
            dateTimeSubMenu.AddSubItem(timeItem);
            versionSubMenu.AddSubItem(capitalsItem);
            versionSubMenu.AddSubItem(versionItem);
            interfaceMenu.RootMenuItem.AddSubItem(dateTimeSubMenu);
            interfaceMenu.RootMenuItem.AddSubItem(versionSubMenu);
            interfaceMenu.Show();
        }

        private static void runEventsMenuDemo()
        {
            Events.MainMenu eventsMenu = new Events.MainMenu("Delegates Main Menu");
            Events.MenuItem dateTimeSubMenu = new Events.MenuItem("Show Current Date/Time");
            Events.MenuItem dateItem = new Events.MenuItem("Show Current Date");
            Events.MenuItem timeItem = new Events.MenuItem("Show Current Time");
            Events.MenuItem versionSubMenu = new Events.MenuItem("Version and Capitals");
            Events.MenuItem capitalsItem = new Events.MenuItem("Count Capitals");
            Events.MenuItem versionItem = new Events.MenuItem("Show Version");

            dateItem.Selected += showCurrentDate;
            timeItem.Selected += showCurrentTime;
            capitalsItem.Selected += countCapitals;
            versionItem.Selected += showVersion;
            dateTimeSubMenu.AddSubItem(dateItem);
            dateTimeSubMenu.AddSubItem(timeItem);
            versionSubMenu.AddSubItem(capitalsItem);
            versionSubMenu.AddSubItem(versionItem);
            eventsMenu.RootMenuItem.AddSubItem(dateTimeSubMenu);
            eventsMenu.RootMenuItem.AddSubItem(versionSubMenu);
            eventsMenu.Show();
        }

        private static void showCurrentDate()
        {
            Console.WriteLine($"> Current Date is {DateTime.Now.ToString("dd/MM/yyyy")}");
        }

        private static void showCurrentTime()
        {
            Console.WriteLine($"> Current Time is {DateTime.Now.ToString("HH:mm:ss")}");
        }

        private static void showVersion()
        {
            Console.WriteLine("App Version: 26.2.4.7310");
        }

        private static void countCapitals()
        {
            string userInput = string.Empty;
            int upperCaseCount = 0;

            Console.WriteLine("Please enter a sentence:");
            userInput = Console.ReadLine();
            foreach(char currentChar in userInput)
            {
                if(char.IsUpper(currentChar))
                {
                    upperCaseCount++;
                }
            }

            Console.WriteLine($"> There are {upperCaseCount} uppercase letters in your text.");
        }
    }
}