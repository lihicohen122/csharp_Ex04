using System;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    public class EventsMenuTest
    {
        private const string k_Version = "26.2.4.7310";
        private readonly MainMenu r_MainMenu;

        private void dateItem_OptionSelected()
        {
            Console.WriteLine($"Current Date is {DateTime.Now.ToString("dd/MM/yyyy")}");
        }

        private void timeItem_OptionSelected()
        {
            Console.WriteLine($"Current Time is {DateTime.Now.ToString("HH:mm:ss")}");
        }

        private void versionItem_OptionSelected()
        {
            Console.WriteLine($"App Version: {k_Version}");
        }

        private void capitalsItem_OptionSelected()
        {
            int upperCaseCount = 0;
            string userInput = Console.ReadLine();

            foreach(char currentChar in userInput)
            {
                if(char.IsUpper(currentChar))
                {
                    upperCaseCount++;
                }
            }

            Console.WriteLine($"There are {upperCaseCount} uppercase letters in your text.");
        }

        private void buildMenu()
        {
            MenuItem dateTimeSubMenu = createDateTimeSubMenu();
            MenuItem versionSubMenu = createVersionAndCapitalsSubMenu();

            r_MainMenu.RootMenuItem.AddSubItem(dateTimeSubMenu);
            r_MainMenu.RootMenuItem.AddSubItem(versionSubMenu);
        }

        private MenuItem createDateTimeSubMenu()
        {
            MenuItem dateTimeSubMenu = new MenuItem("Show Current Date/Time");
            MenuItem dateItem = new MenuItem("Show Current Date");
            MenuItem timeItem = new MenuItem("Show Current Time");

            dateItem.OptionSelected += dateItem_OptionSelected;
            timeItem.OptionSelected += timeItem_OptionSelected;
            dateTimeSubMenu.AddSubItem(dateItem);
            dateTimeSubMenu.AddSubItem(timeItem);

            return dateTimeSubMenu;
        }

        private MenuItem createVersionAndCapitalsSubMenu()
        {
            MenuItem versionSubMenu = new MenuItem("Version and Capitals");
            MenuItem capitalsItem = new MenuItem("Count Capitals");
            MenuItem versionItem = new MenuItem("Show Version");

            capitalsItem.OptionSelected += capitalsItem_OptionSelected;
            versionItem.OptionSelected += versionItem_OptionSelected;
            versionSubMenu.AddSubItem(capitalsItem);
            versionSubMenu.AddSubItem(versionItem);

            return versionSubMenu;
        }

        public EventsMenuTest()
        {
            r_MainMenu = new MainMenu("Delegates Main Menu");
            buildMenu();
        }

        public void Show()
        {
            r_MainMenu.Show();
        }
    }
}