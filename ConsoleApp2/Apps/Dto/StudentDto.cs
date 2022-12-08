using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Apps.Dto
{
    internal class StudentDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public int Score { get; set; }
        public string TeacherName { get; set; }

    }
}
