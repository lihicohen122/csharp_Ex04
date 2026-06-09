using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private readonly string r_Title;
        private readonly List<MenuItem> r_SubItems;
        public event Action OptionSelected;

        private void printMenu(bool i_IsRoot)
        {
            int itemIndex = 1;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"** {r_Title} **");
            Console.ResetColor();
            foreach(MenuItem item in r_SubItems)
            {
                Console.WriteLine($"{itemIndex}. {item.Title}");
                itemIndex++;
            }

            string exitOrBackMsg = i_IsRoot ? "Exit" : "Back";

            Console.WriteLine($"0. {exitOrBackMsg}");
        }

        private int getUserChoice(bool i_IsRoot)
        {
            int userChoice = -1;
            bool isInputValid = false;
            string exitOrBackStr = i_IsRoot ? "exit" : "go back";

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

        protected virtual void OnOptionSelected()
        {
            if(OptionSelected != null)
            {
                Console.Clear();
                OptionSelected.Invoke();
                Console.WriteLine();
            }
        }

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
            r_SubItems = new List<MenuItem>();
        }

        public string Title
        {
            get { return r_Title; }
        }

        public List<MenuItem> SubItems
        {
            get { return r_SubItems; }
        }

        public void AddSubItem(MenuItem i_MenuItem)
        {
            r_SubItems.Add(i_MenuItem);
        }

        public void Show(bool i_IsRoot)
        {
            bool isRunning = true;

            Console.Clear();
            while(isRunning)
            {
                printMenu(i_IsRoot);
                int userChoice = getUserChoice(i_IsRoot);

                if(userChoice == 0)
                {
                    isRunning = false;
                }
                else
                {
                    MenuItem selectedItem = r_SubItems[userChoice - 1];

                    if(selectedItem.SubItems.Count > 0)
                    {
                        const bool v_IsRoot = true;
                        
                        selectedItem.Show(!v_IsRoot);
                        Console.Clear();
                    }
                    else
                    {
                        selectedItem.OnOptionSelected();
                    }
                }
            }
        }
    }
}