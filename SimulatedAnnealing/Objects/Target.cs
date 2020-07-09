using System.Drawing;
using System.Collections.Generic;

namespace SimulatedAnnealing.Objects
{
    public class Target
    {
        public long Width { get; set; }
        public long Height { get; set; }
        public List<Color> PixelArray { get; set; }
    };
};