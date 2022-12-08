using ConsoleApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class Teacher: BaseRepository<Teacher>
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string TeacherName { get; set; }
    }
}
