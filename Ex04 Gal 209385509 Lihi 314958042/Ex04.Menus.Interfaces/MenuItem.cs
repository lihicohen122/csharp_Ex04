using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly string r_Title;
        private readonly List<MenuItem> r_SubItems;
        private IMenuItemListener m_Listener;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
            r_SubItems = new List<MenuItem>();
            m_Listener = null;
        }

        public string Title
        {
            get { return r_Title; }
        }

        public List<MenuItem> SubItems
        {
            get { return r_SubItems; }
        }

        public void AttachListener(IMenuItemListener i_Listener)
        {
            m_Listener = i_Listener;
        }

        public void AddSubItem(MenuItem i_MenuItem)
        {
            r_SubItems.Add(i_MenuItem);
        }

        public void Show(bool i_IsRoot)
        {
            bool isRunning = true;
            int userChoice = -1;

            while(isRunning)
            {
                Console.Clear();
                printMenu(i_IsRoot);
                userChoice = getUserChoice(i_IsRoot);

                if(userChoice == 0)
                {
                    isRunning = false;
                }
                else
                {
                    MenuItem selectedItem = r_SubItems[userChoice - 1];
                    if(selectedItem.SubItems.Count > 0)
                    {
                        selectedItem.Show(false);
                    }
                    else
                    {
                        selectedItem.notifyListener();
                    }
                }
            }
        }

        private void printMenu(bool i_IsRoot)
        {
            int itemIndex = 1;
            string exitOrBackMsg = string.Empty;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"** {r_Title} **");
            Console.ResetColor();

            foreach(MenuItem item in r_SubItems)
            {
                Console.WriteLine($"{itemIndex}. {item.Title}");
                itemIndex++;
            }

            if(i_IsRoot)
            {
                exitOrBackMsg = "Exit";
            }
            else
            {
                exitOrBackMsg = "Back";
            }

            Console.WriteLine($"0. {exitOrBackMsg}");
        }

        private int getUserChoice(bool i_IsRoot)
        {
            int userChoice = -1;
            bool isInputValid = false;
            string exitOrBackStr = string.Empty;

            if(i_IsRoot)
            {
                exitOrBackStr = "exit";
            }
            else
            {
                exitOrBackStr = "go back";
            }

            while(!isInputValid)
            {
                Console.WriteLine($"Please enter your choice (1-{r_SubItems.Count} or 0 to {exitOrBackStr}):");
                string userInput = Console.ReadLine();
                isInputValid = int.TryParse(userInput, out userChoice);

                if(!isInputValid || userChoice < 0 || userChoice > r_SubItems.Count)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    isInputValid = false;
                }
            }

            return userChoice;
        }

        private void notifyListener()
        {
            if(m_Listener != null)
            {
                Console.Clear();
                m_Listener.ReportSelected(this);
                Console.WriteLine("Press 'Enter' to continue...");
                Console.ReadLine();
            }
        }
    }
}