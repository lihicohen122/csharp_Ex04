using System;

namespace Ex04.Menus.Test
{
    public class CapitalsCountAction : IMenuItemListener
    {
        public void ReportSelected(MenuItem i_MenuItem)
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