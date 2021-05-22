using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_curso.Model {
    public class Person {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string gender { get; set; }
    }
}
