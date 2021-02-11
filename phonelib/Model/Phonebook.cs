using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonelib.Model
{
    public class Phonebook
    {
        public readonly List<Users> user = new List<Users>();
        public List<Users> User { get { return user; } }
    }
}
