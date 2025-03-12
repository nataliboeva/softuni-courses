﻿using System;
using System.Collections.Generic;

namespace AcademicRecordsApp.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
