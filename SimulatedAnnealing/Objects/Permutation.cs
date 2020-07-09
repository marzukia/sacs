using System;
using System.Linq;
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
            clone.PixelArray = CopyPixelArray();
            clone.Width = Width;
            clone.Height = Height;

            return clone;
        }

        public List<Color> CopyPixelArray()
        {
            var clone = new List<Color>() {};

            foreach (var pixel in PixelArray)
            {
                clone.Add(Color.FromArgb(pixel.R, pixel.G, pixel.B));
            };

            return clone;
        }
    };
};