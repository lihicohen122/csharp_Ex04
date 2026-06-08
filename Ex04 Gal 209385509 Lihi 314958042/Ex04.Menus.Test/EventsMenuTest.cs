using System;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    public class EventsMenuTest
    {
        private const string k_Version = "26.2.4.7310";
        private MainMenu m_MainMenu;

        public EventsMenuTest()
        {
            m_MainMenu = new MainMenu("Delegates Main Menu");
            buildMenu();
        }

        private void buildMenu()
        {
            MenuItem dateTimeSubMenu = createDateTimeSubMenu();
            MenuItem versionSubMenu = createVersionSubMenu();

            m_MainMenu.RootMenuItem.AddSubItem(dateTimeSubMenu);
            m_MainMenu.RootMenuItem.AddSubItem(versionSubMenu);
        }

        private MenuItem createDateTimeSubMenu()
        {
            MenuItem dateTimeSubMenu = new MenuItem("Show Current Date/Time");
            MenuItem dateItem = new MenuItem("Show Current Date");
            MenuItem timeItem = new MenuItem("Show Current Time");

            dateItem.Selected += showCurrentDate;
            timeItem.Selected += showCurrentTime;
            dateTimeSubMenu.AddSubItem(dateItem);
            dateTimeSubMenu.AddSubItem(timeItem);

            return dateTimeSubMenu;
        }

        private MenuItem createVersionSubMenu()
        {
            MenuItem versionSubMenu = new MenuItem("Version and Capitals");
            MenuItem capitalsItem = new MenuItem("Count Capitals");
            MenuItem versionItem = new MenuItem("Show Version");

            capitalsItem.Selected += countCapitals;
            versionItem.Selected += showVersion;
            versionSubMenu.AddSubItem(capitalsItem);
            versionSubMenu.AddSubItem(versionItem);

            return versionSubMenu;
        }

        private void showCurrentDate()
        {
            Console.WriteLine($"Current Date is {DateTime.Now.ToString("dd/MM/yyyy")}");
        }

        private void showCurrentTime()
        {
            Console.WriteLine($"Current Time is {DateTime.Now.ToString("HH:mm:ss")}");
        }

        private void showVersion()
        {
            Console.WriteLine($"App Version: {k_Version}");
        }

        private void countCapitals()
        {
            string userInput = string.Empty;
            int upperCaseCount = 0;
            
            userInput = Console.ReadLine();
            foreach(char currentChar in userInput)
            {
                if(char.IsUpper(currentChar))
                {
                    upperCaseCount++;
                }
            }

            Console.WriteLine($"There are {upperCaseCount} uppercase letters in your text.");
        }

        public void Show()
        {
            m_MainMenu.Show();
        }
    }
}