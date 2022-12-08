using ConsoleApp2.Helpers;
using ConsoleApp2.Models;
using ConsoleApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Apps
{
    internal class TeacherApp
    {
        Student _student;
        StudentGrade _grade;
        Subject _subject;
        Class _studentClass;
        Teacher _teacher;
        public TeacherApp(Student student, StudentGrade grade, Subject subject, Class studentClass, Teacher teacher)
        {
            _teacher = teacher;

        }
        public void MenuStart()
        {
            var Stop = false;
            while (!Stop)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("|           Menu Student            |");
                Console.WriteLine("=====================================");
                Console.WriteLine("1.Register");
                Console.WriteLine("2.Show Score");
                Console.WriteLine("3.Exit");
                Console.Write("\nSelect : ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        GiveScore();
                        break;
                    case "3":
                        NextLevelStudent();
                        break;
                    case "4":
                        Stop = true;
                        break;
                }
            }
        }

        private void Register()
        {
            var subjects = _subject.GetAll();
            Console.Write("Input Name Teacher: ");
            var input = Console.ReadLine();
            var pageSubject = new Pages<Subject>(subjects.ToList());
            pageSubject.page();
            var inputInt = Input.InputInt("Chosee Subject: ");
            var teacher = new Teacher();
            teacher.TeacherName = input;
            teacher.SubjectId = inputInt;
            _teacher.Add(teacher);
            

        }

        private void GiveScore()
        {
            throw new NotImplementedException();
        }

        private void NextLevelStudent()
        {
            throw new NotImplementedException();
        }
    }
}
