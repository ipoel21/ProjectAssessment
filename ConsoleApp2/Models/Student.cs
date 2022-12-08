using ConsoleApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class Student: BaseRepository<Student>
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
    }
}
