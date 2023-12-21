using HighSchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem3.Application.ApplicationLogic.MenuLogic
{
    internal class StudentMenu
    {
        private string[] studentMenuOptions = { "[1] Sortera alla elever efter förnamn\t\t", "[2] Sortera alla elever efter efternamn\t\t", "[3] Stigande sortering \t\t", "[4] Fallande sortering\t\t", "[5] Tillbaka till huvudmenyn\t\t" };
        private int studentMenuSelected = 0;

        private HighSchoolSystemContext Context { get; set; }
        public StudentMenu()
        {
            Context = new();
        }

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

                for (int i = 0; i < studentMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == studentMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(studentMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(studentMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && studentMenuSelected + 1 != studentMenuOptions.Length)
                {
                    studentMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && studentMenuSelected != 0)
                {
                    studentMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (studentMenuSelected)
                    {
                        case 0:
                            SortByFirstName();
                            break;
                        case 1:
                            SortByLastName();
                            break;
                        case 2:
                            AscendingSorting();
                            break;
                        case 3:
                            DescendingSorting();
                            break;
                        case 4:
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

        public void SortByFirstName()
        {
            var students = from s in Context.Students.OrderBy(s => s.FirstName)
                           select s;

            foreach (var s in students)
            {
                Console.WriteLine($"Namn: {s.FirstName} {s.LastName}, Personnummer: {s.PersonalNumber}, Adress: {s.Address}, Postnummer: {s.Zip}, Elev-ID: {s.StudentId}");
            }
        }

        public void SortByLastName()
        {
            var students = from s in Context.Students.OrderBy(s => s.LastName)
                           select s;

            foreach (var s in students)
            {
                Console.WriteLine($"Namn: {s.LastName} {s.FirstName}, Personnummer: {s.PersonalNumber}, Adress: {s.Address}, Postnummer: {s.Zip}, Elev-ID: {s.StudentId}");
            }
        }

        public void AscendingSorting()
        {
            var students = from s in Context.Students
                           orderby s.StudentId ascending
                           select s;

            foreach (var s in students)
            {
                Console.WriteLine($"Namn: {s.FirstName} {s.LastName}, Personnummer: {s.PersonalNumber}, Adress: {s.Address}, Postnummer: {s.Zip}, Elev-ID: {s.StudentId}");
            }
        }

        public void DescendingSorting()
        {
            var students = from s in Context.Students
                           orderby s.StudentId descending
                           select s;

            foreach (var s in students)
            {
                Console.WriteLine($"Namn: {s.FirstName} {s.LastName}, Personnummer: {s.PersonalNumber}, Adress: {s.Address}, Postnummer: {s.Zip}, Elev-ID: {s.StudentId}");
            }
        }
    }
}
