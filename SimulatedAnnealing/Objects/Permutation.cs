using System.Drawing;
using System.Collections.Generic;

namespace SimulatedAnnealing.Objects
{
    public class Permutation
    {
        public long Width { get; set; }
        public long Height { get; set; }
        public List<Color> PixelArray { get; set; }

        public Permutation(long width, long height)
        {
            Width = width;
            Height = height;
        }

        public Permutation DeepCopy()
        {
            var clone = (Permutation) this.MemberwiseClone();
            clone.PixelArray = PixelArray.Clone();
            clone.Width = Width;
            clone.Height = Height;

            return clone;
        }
    };
};