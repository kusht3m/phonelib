using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonelib.Model
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }

    }
}
