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
            _student = student;
            _grade = grade;
            _subject = subject;
            _studentClass = studentClass;
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
                Console.WriteLine("2.GiveScore");
                Console.WriteLine("3.NextLevelStudent");
                Console.WriteLine("4.ShowTeacher");
                Console.WriteLine("5.Exit");
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
                        ShowTeacher();
                        break;
                    case "5":
                        Stop = true;
                        break;
                }
            }
        }

        private void ShowTeacher()
        {
            var teachers = _teacher.GetAll();
            var pageTeacher = new Pages<Teacher>(teachers.ToList());
            pageTeacher.page();
        }

       
        private void Register()
        {
            IEnumerable<Subject>? subjects = _subject.GetAll();
            Console.Write("Input Name Teacher: ");
            var input = Console.ReadLine();
            var pageSubject = new Pages<Subject>(subjects.ToList());
            pageSubject.page();
            var inputInt = Input.InputInt("Chosee Subject: ");
            var teacher = new Teacher();
            teacher.TeacherName = input;
            teacher.SubjectId = inputInt;
            _teacher.Add(teacher); 
            Console.WriteLine("Change Successfully\nPress Enter To Continue....");
            Console.ReadKey();


        }

        private void GiveScore()
        {
            var grade = new StudentGrade();
            var subjects = _subject.GetAll();
            var students = _student.GetAll();
            var pageSubject = new Pages<Subject>(subjects.ToList());
            pageSubject.page();
            var subjectId = Input.InputInt("Chosee Subject: ");
            var Score = Input.InputInt("Input Score: ");
            grade.Score = Score;
            grade.SubjectId= subjectId;
            var pageStudent = new Pages<Student>(students.ToList());
            pageStudent.page();
            var StudentId = Input.InputInt("Chosee Student: ");
            grade.StudentId = StudentId;
            grade.DateCreate= DateTime.Now;
            _grade.Add(grade);
            Console.WriteLine("Change Successfully\nPress Enter To Continue....");
            Console.ReadKey();

        }

        private void NextLevelStudent()
        {
            var students = _student.GetAll();
            var pageStudent = new Pages<Student>(students.ToList());
            pageStudent.page();
            var StudentId = Input.InputInt("Chosee Student: ");
            var student = students.Where(w => w.Id == StudentId).FirstOrDefault();
            student.ClassId += 1; 
            _student.Update(student);
            Console.WriteLine("Change Successfully\nPress Enter To Continue....");
            Console.ReadKey();

        }
    }
}
