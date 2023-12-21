using HighSchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem3.Application.ApplicationLogic.MenuLogic
{
    internal class EmployeeMenu
    {
        private string[] employeeMenuOptions = { "[1] Visa all personal\t\t", "[2] Visa alla rektorer\t\t", "[3] Visa alla administratörer \t\t", "[4] Visa alla lärare\t\t", "[5] Visa alla skolsköterskor\t\t", "[6] Visa alla städare \t\t", "[7] Visa alla vaktmästare\t\t", "[8] Tillbaka till huvudmenyn\t\t" };
        private int employeeMenuSelected = 0;

        private HighSchoolSystemContext Context { get; set; }
        public EmployeeMenu()
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

                for (int i = 0; i < employeeMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == employeeMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(employeeMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(employeeMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && employeeMenuSelected + 1 != employeeMenuOptions.Length)
                {
                    employeeMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && employeeMenuSelected != 0)
                {
                    employeeMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (employeeMenuSelected)
                    {
                        case 0:
                            GetEmployees();
                            break;
                        case 1:
                            GetPrincipals();
                            break;
                        case 2:
                            GetAdmins();
                            break;
                        case 3:
                            GetTeachers();
                            break;
                        case 4:
                            GetSchoolNurses();
                            break;
                        case 5:
                            GetCleaners();
                            break;
                        case 6:
                            GetJanitors();
                            break;
                        case 7:
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

        public void GetEmployees()
        {
            var employees = Context.Employees.ToList();
            Console.WriteLine("Visar alla anställda:");

            foreach (var e in employees)
            {
                Console.WriteLine($"Anställnings-ID: {e.EmployeeId}, Namn: {e.FirstName} {e.LastName}, Titel: {e.Title}, Anställningsdatum: {e.HireDate}, Födelsedatum: {e.BirthDate}, Adress: {e.Address}, Postnummer: {e.Zip}");
            }
        }

        public void GetPrincipals()
        {
            var principals = Context.Employees.Where(s => s.FkprofessionId == 1).ToList();
            Console.WriteLine("Visar alla rektorer:");

            foreach (var p in principals)
            {
                Console.WriteLine($"Anställnings-ID: {p.EmployeeId}, Namn: {p.FirstName} {p.LastName}, Titel: {p.Title}, Anställningsdatum: {p.HireDate}, Födelsedatum: {p.BirthDate}, Adress: {p.Address}, Postnummer: {p.Zip}");
            }
        }

        public void GetAdmins()
        {
            var administrators = Context.Employees.Where(s => s.FkprofessionId == 2).ToList();
            Console.WriteLine("Visar alla administratörer:");

            foreach (var a in administrators)
            {
                Console.WriteLine($"Anställnings-ID: {a.EmployeeId}, Namn: {a.FirstName} {a.LastName}, Titel: {a.Title}, Anställningsdatum: {a.HireDate}, Födelsedatum: {a.BirthDate}, Adress: {a.Address}, Postnummer: {a.Zip}");
            }
        }

        public void GetTeachers()
        {
            var teachers = Context.Employees.Where(s => s.FkprofessionId == 3).ToList();
            Console.WriteLine("Visar alla lärare:");

            foreach (var t in teachers)
            {
                Console.WriteLine($"Anställnings-ID: {t.EmployeeId}, Namn: {t.FirstName} {t.LastName}, Titel: {t.Title}, Anställningsdatum: {t.HireDate}, Födelsedatum: {t.BirthDate}, Adress: {t.Address}, Postnummer: {t.Zip}");
            }
        }

        public void GetSchoolNurses()
        {
            var nurses = Context.Employees.Where(s => s.FkprofessionId == 4).ToList();
            Console.WriteLine("Visar alla skolsköterskor:");

            foreach (var n in nurses)
            {
                Console.WriteLine($"Anställnings-ID: {n.EmployeeId}, Namn: {n.FirstName} {n.LastName}, Titel: {n.Title}, Anställningsdatum: {n.HireDate}, Födelsedatum: {n.BirthDate}, Adress: {n.Address}, Postnummer: {n.Zip}");
            }
        }

        public void GetCleaners()
        {
            var cleaners = Context.Employees.Where(s => s.FkprofessionId == 5).ToList();
            Console.WriteLine("Visar alla lokalvårdare:");

            foreach (var c in cleaners)
            {
                Console.WriteLine($"Anställnings-ID: {c.EmployeeId}, Namn: {c.FirstName} {c.LastName}, Titel: {c.Title}, Anställningsdatum: {c.HireDate}, Födelsedatum: {c.BirthDate}, Adress: {c.Address}, Postnummer: {c.Zip}");
            }
        }

        public void GetJanitors()
        {
            var janitors = Context.Employees.Where(s => s.FkprofessionId == 6).ToList();
            Console.WriteLine("Visar alla vaktmästare:");

            foreach (var j in janitors)
            {
                Console.WriteLine($"Anställnings-ID: {j.EmployeeId}, Namn: {j.FirstName} {j.LastName}, Titel: {j.Title}, Anställningsdatum: {j.HireDate}, Födelsedatum: {j.BirthDate}, Adress: {j.Address}, Postnummer: {j.Zip}");
            }
        }   
    }
}
