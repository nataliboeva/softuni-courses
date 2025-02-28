using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public class Box
    {

        public Box (double lenght, double width, double height)
        {
            if(lenght <= 0) throw new ArgumentException("Length cannot be zero or negative.");
            if (width <= 0) throw new ArgumentException("Width cannot be zero or negative.");
            if (height <= 0) throw new ArgumentException("Height cannot be zero or negative.");

            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght { get; }
        public double Width { get; }
        public double Height { get; }

        public double SurfaceArea()
        {
            return this.LateralSurfaceArea() + 2 * this.Lenght * this.Width;
        }
        public double LateralSurfaceArea()
        {
            return 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;
        }
        public double Volume()
        {
            return this.Lenght * this.Width * this.Height;
        }
    }
}
