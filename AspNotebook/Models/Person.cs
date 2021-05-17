using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNotebook.Models
{
    public class Person
    {
        public int Id { get; private set; } = -1;
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}
