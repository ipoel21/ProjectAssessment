using ConsoleApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class Subject: BaseRepository<Subject>
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

    }
}
