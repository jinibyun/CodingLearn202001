using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreConsole.Model
{
    public class StudentAddress
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Student Student { get; set; }
    }
}
