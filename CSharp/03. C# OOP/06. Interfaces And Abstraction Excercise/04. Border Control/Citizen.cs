﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._Border_Control
{
    public class Citizen : IEnter
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
    }

}
