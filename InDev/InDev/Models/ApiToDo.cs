using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InDev.Models
{
    public class ApiToDo
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ToDo { get; set; }
        public bool Done { get; set; }
    }
}
