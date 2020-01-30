using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreConsole.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public Nullable<int> StandardId { get; set; }
        public Nullable<TeacherType> TeacherType { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual Standard Standard { get; set; }
    }
}
