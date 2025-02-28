﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool isEmpty()
        {
            return Count == 0;
        }
        public void AddRange(IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                Push(item);
            }
        }
    }
}
