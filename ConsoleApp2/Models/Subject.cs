using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class Subject
    {
        public int Id { get; set; }
        public string NameSubject { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }

    }
}
