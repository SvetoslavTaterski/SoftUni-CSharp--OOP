using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }


        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid age!");
                }

                age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
