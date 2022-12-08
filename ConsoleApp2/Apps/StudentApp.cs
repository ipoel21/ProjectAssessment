using ConsoleApp2.Apps.Dto;
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
    internal class StudentApp
    {
        Student _student;
        StudentGrade _grade;
        Subject _subject;
        Class _studentClass;
        Teacher _teacher;
        public StudentApp(Student student,StudentGrade grade,Subject subject,Class studentClass,Teacher teacher) 
        {
            _studentClass= studentClass;
            _teacher= teacher;
            _subject= subject;
            _grade= grade;
            _student= student;
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
                        ShowScore();
                        break;
                    case "3":
                        Stop = true;
                        break;
                }
            }
        }
        public void Register()
        {
            Console.Write("Input Name Student: ");
            var input = Console.ReadLine();
            var student = new Student()
            {
                StudentName = input,
                ClassId = 1,
            };
            _student.Add(student);
            Console.WriteLine("Change Successfully\nPress Enter To Continue....");
            Console.ReadKey();
        }
        public void ShowScore()
        {
            var students = _student.GetAll();
            var pageStudent = new Pages<Student>(students.ToList());
            pageStudent.page();
            int InputInt = Input.InputInt("Choose Student: ");

            var Grades = _grade.GetAll();
            var subjects = _subject.GetAll();
            var studentClasses = _studentClass.GetAll();

            var studentDto = from studentClass in studentClasses
                             join student in students on studentClass.Id equals student.ClassId
                             join grade in Grades on student.Id equals grade.StudentId
                             join subject in subjects on grade.SubjectId equals subject.Id
                             where student.Id == InputInt
                             select new StudentDto
                             {
                                 Id= student.Id,
                                 StudentName = student.StudentName,
                                 ClassName = studentClass.ClassName,
                                 Score = grade.Score,
                                 SubjectName = subject.SubjectName,
                             };

            var StudentGrade = new Pages<StudentDto>(studentDto.ToList());
            StudentGrade.page();
            

        }
    }
}
