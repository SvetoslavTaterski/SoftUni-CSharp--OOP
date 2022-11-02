using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Length = lenght;
            Width = width;
            Height = height;
        }

        public double Length 
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        private double SurfaceArea() => 2 * ((Length * Width) + (Length * Height) + (Width * Height));

        private double LateralSurfaceArea() => 2 * ((Length * Height) + (Width * Height));

        private double Volume() => Length * Width * Height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
