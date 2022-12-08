using ConsoleApp2.Apps;
using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Application
    {
        StudentApp _studentApp;
        TeacherApp _teacherApp;
        public Application(StudentApp student,TeacherApp teacher)
        {
            _studentApp= student;
            _teacherApp= teacher;
        }
        public void Run()
        {
            var Stop = false;
            while(!Stop)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("|         Menu Applications          |");
                Console.WriteLine("=====================================");
                Console.WriteLine("1.Student");
                Console.WriteLine("2.Teacher");
                Console.WriteLine("3.Exit");
                Console.Write("\nSelect : ");
                switch(Console.ReadLine())
                {
                    case "1":
                        _studentApp.MenuStart();
                        break; 
                    case "2":
                        _teacherApp.MenuStart();
                        break;
                    case "3":
                        Stop= true;
                        break;
                }
            }
        }
    }
}
