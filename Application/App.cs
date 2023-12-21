using HighSchoolSystem3.Application.ApplicationLogic;
using HighSchoolSystem3.Application.ApplicationLogic.MenuLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem3.Application
{
    internal class App
    {
        private string[] menuOptions = { "[1] Visa personal\t\t", "[2] Visa elever\t\t", "[3] Visa alla elever i en viss klass \t\t", "[4] Visa alla betyg från senaste månaden\t\t", "[5] Visa alla kurser\t\t", "[6] Lägg till ny elev\t\t", "[7] Lägg till ny personal\t\t" };
        private int menuSelected = 0;

        public void RunMenu()
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

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == menuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(menuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && menuSelected + 1 != menuOptions.Length)
                {
                    menuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && menuSelected != 0)
                {
                    menuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (menuSelected)
                    {
                        case 0:
                            GetEmployees();
                            break;
                        case 1:
                            GetStudents();
                            break;
                        case 2:
                            GetStudentsByClass();
                            break;
                        case 3:
                            GetAllGradesByMonth();
                            break;
                        case 4:
                            GetCourses();
                            break;
                        case 5:
                            AddNewStudent();
                            break;
                        case 6:
                            AddNewEmployee();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
        }

        void GetEmployees()
        {
            new EmployeeMenu().Menu();
        }

        static void GetStudents()
        {
           new StudentMenu().Menu();
        }

        static void GetStudentsByClass()
        {
            new Method().GetStudentsByClass();
        }

        static void GetAllGradesByMonth()
        {
            new Method().GetAllGradesByMonth();
        }

        static void GetCourses()
        {
            new Method().GetCourses();
        }

        static void AddNewStudent()
        {
            new Method().AddNewStudent();
        }

        static void AddNewEmployee()
        {
            new Method().AddNewEmployee();
        }
    }
}
