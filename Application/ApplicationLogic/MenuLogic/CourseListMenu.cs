using HighSchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem3.Application.ApplicationLogic.MenuLogic
{
    internal class CourseListMenu
    {
        private string[] courseListMenuOptions = { "[1] Visa alla betyg som satts den senaste månaden\t\t", "[2] Tillbaka till huvudmenyn\t\t" };
        private int courseListMenuSelected = 0;

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

                for (int i = 0; i < courseListMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == courseListMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(courseListMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(courseListMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && courseListMenuSelected + 1 != courseListMenuOptions.Length)
                {
                    courseListMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && courseListMenuSelected != 0)
                {
                    courseListMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (courseListMenuSelected)
                    {
                        case 0:
                            new Method().GetAllGradesByMonth();
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
            ReturnToMainMenu();
        }

        public void ReturnToMainMenu()
        {
            new App().RunMenu();
        }
    }
}
