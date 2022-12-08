using ConsoleApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class StudentGrade:BaseRepository<StudentGrade>
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set;}
        public int Score { get; set;}
    }
}
