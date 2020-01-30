using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreConsole.Model
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        // public ICollection<Student> Students { get; set; }
    }
}
