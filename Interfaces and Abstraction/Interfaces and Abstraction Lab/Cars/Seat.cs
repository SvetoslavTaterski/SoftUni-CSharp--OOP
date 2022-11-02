﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model 
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public string Color 
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            } 
        }

        public string Start() => "Engine start";

        public string Stop() => "Breaaak!";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} Seat {Model}");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
