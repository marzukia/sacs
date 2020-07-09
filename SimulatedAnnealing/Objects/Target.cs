using System.Drawing;
using System.Collections.Generic;

namespace SimulatedAnnealing.Objects
{
    public class Target
    {
        public long Width { get; set; }
        public long Height { get; set; }
        public List<Color> PixelArray { get; set; }

        public Target(long width, long height, List<Color> pixelArray)
        {
            Width = width;
            Height = height;
            PixelArray = pixelArray;
        }
    };
};