using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment
{
    public class Pixel
    {
        public Pixel(string name, ConsoleColor color)
        {
            Name = name;

            ScreenColor = color;
        }


        public string Name { get; set; }
        public ConsoleColor ScreenColor { get; set; }
    }
}
