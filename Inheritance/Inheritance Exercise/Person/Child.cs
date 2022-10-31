﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        private string name;
        private int age;

        public Child(string name, int age) : base(name, age)
        {
        }

        public override int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age > 15)
                {
                    throw new ArgumentException("Invalid age!");
                }
                age = value;
            }
        }

    }
}
