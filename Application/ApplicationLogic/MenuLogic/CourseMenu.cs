using HighSchoolSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem3.Application.ApplicationLogic.MenuLogic
{
    internal class CourseMenu
    {
        private string[] courseMenuOptions = { "[1] Visa alla kurser\t\t", "[2] Tillbaka till huvudmenyn\t\t" };
        private int courseMenuSelected = 0;

        public void Menu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("HighSchoolSystem");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Styr pilen upp eller ner och tryck sedan på");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Enter");
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l");

                for (int i = 0; i < courseMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == courseMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(courseMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(courseMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && courseMenuSelected + 1 != courseMenuOptions.Length)
                {
                    courseMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && courseMenuSelected != 0)
                {
                    courseMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (courseMenuSelected)
                    {
                        case 0:
                            new Method().GetCourses();
                            break;
                        case 2:
                            ReturnToMainMenu();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
            ReturnToMenu();
        }

        public void ReturnToMainMenu()
        {
            new App().RunMenu();
        }

        public void ReturnToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på Enter för att gå tillbaka till menyn");
            Console.ResetColor();
            Console.ReadKey(true);
            Menu();
        }

    }
}
