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
            Interfaces.MenuItem dateTimeSubMenu = createInterfaceDateTimeSubMenu();
            Interfaces.MenuItem versionSubMenu = createInterfaceVersionSubMenu();

            interfaceMenu.RootMenuItem.AddSubItem(dateTimeSubMenu);
            interfaceMenu.RootMenuItem.AddSubItem(versionSubMenu);
            interfaceMenu.Show();
        }

        private static Interfaces.MenuItem createInterfaceDateTimeSubMenu()
        {
            Interfaces.MenuItem dateTimeSubMenu = new Interfaces.MenuItem("Show Current Date/Time");
            Interfaces.MenuItem dateItem = new Interfaces.MenuItem("Show Current Date");
            Interfaces.MenuItem timeItem = new Interfaces.MenuItem("Show Current Time");

            dateItem.AttachListener(new DateShowAction());
            timeItem.AttachListener(new TimeShowAction());
            dateTimeSubMenu.AddSubItem(dateItem);
            dateTimeSubMenu.AddSubItem(timeItem);

            return dateTimeSubMenu;
        }

        private static Interfaces.MenuItem createInterfaceVersionSubMenu()
        {
            Interfaces.MenuItem versionSubMenu = new Interfaces.MenuItem("Version and Capitals");
            Interfaces.MenuItem capitalsItem = new Interfaces.MenuItem("Count Capitals");
            Interfaces.MenuItem versionItem = new Interfaces.MenuItem("Show Version");

            capitalsItem.AttachListener(new CapitalsCountAction());
            versionItem.AttachListener(new VersionShowAction());
            versionSubMenu.AddSubItem(capitalsItem);
            versionSubMenu.AddSubItem(versionItem);

            return versionSubMenu;
        }

        private static void runEventsMenuDemo()
        {
            Events.MainMenu eventsMenu = new Events.MainMenu("Delegates Main Menu");
            Events.MenuItem dateTimeSubMenu = createEventsDateTimeSubMenu();
            Events.MenuItem versionSubMenu = createEventsVersionSubMenu();

            eventsMenu.RootMenuItem.AddSubItem(dateTimeSubMenu);
            eventsMenu.RootMenuItem.AddSubItem(versionSubMenu);
            eventsMenu.Show();
        }

        private static Events.MenuItem createEventsDateTimeSubMenu()
        {
            Events.MenuItem dateTimeSubMenu = new Events.MenuItem("Show Current Date/Time");
            Events.MenuItem dateItem = new Events.MenuItem("Show Current Date");
            Events.MenuItem timeItem = new Events.MenuItem("Show Current Time");

            dateItem.Selected += showCurrentDate;
            timeItem.Selected += showCurrentTime;
            dateTimeSubMenu.AddSubItem(dateItem);
            dateTimeSubMenu.AddSubItem(timeItem);

            return dateTimeSubMenu;
        }

        private static Events.MenuItem createEventsVersionSubMenu()
        {
            Events.MenuItem versionSubMenu = new Events.MenuItem("Version and Capitals");
            Events.MenuItem capitalsItem = new Events.MenuItem("Count Capitals");
            Events.MenuItem versionItem = new Events.MenuItem("Show Version");

            capitalsItem.Selected += countCapitals;
            versionItem.Selected += showVersion;
            versionSubMenu.AddSubItem(capitalsItem);
            versionSubMenu.AddSubItem(versionItem);

            return versionSubMenu;
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

            foreach (char currentChar in userInput)
            {
                if (char.IsUpper(currentChar))
                {
                    upperCaseCount++;
                }
            }

            Console.WriteLine($"> There are {upperCaseCount} uppercase letters in your text.");
        }
    }
}