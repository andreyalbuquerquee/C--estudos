﻿using System.Globalization;

namespace Course.Model.Entities
{
    class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double Area()
        {
            return Height * Width;
        }

        public override string ToString()
        {
            return "Rectangle color = "
                + Color
                + ", height = "
                + Height.ToString("F2", CultureInfo.InvariantCulture)
                + ", width = "
                + Width.ToString("F2", CultureInfo.InvariantCulture)
                + ", area = "
                + Area().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
