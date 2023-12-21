using HighSchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem3.Application.ApplicationLogic.MenuLogic
{
    internal class ClassMenu
    {
        private string[] classMenuOptions = { "[1] Välj klass att visa\t\t", "[2] Tillbaka till huvudmenyn\t\t" };
        private int classMenuSelected = 0;

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

                for (int i = 0; i < classMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == classMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(classMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(classMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && classMenuSelected + 1 != classMenuOptions.Length)
                {
                    classMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && classMenuSelected != 0)
                {
                    classMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (classMenuSelected)
                    {
                        case 0:
                            new Method().GetStudentsByClass();
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
