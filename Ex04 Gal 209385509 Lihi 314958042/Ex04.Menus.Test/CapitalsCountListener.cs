using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class CapitalsCountListener : IMenuItemListener
    {
        public void ReportSelect(MenuItem i_MenuItem)
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
    }
}