using System;
using System.Drawing;
using System.Collections.Generic;

using SimulatedAnnealing.Objects;

namespace SimulatedAnnealing.Services
{
    public interface IPermutationService
    {
        void PopulatePixelArray(Permutation permutation);
        void MutatePixelArray(Permutation permutation, double temperature);
    };

    public class PermutationService : IPermutationService
    {
        private static Random rng = new Random();

        public void PopulatePixelArray(Permutation permutation)
        {
            var pixels = new List<Color>() {};

            for (int w = 0; w < permutation.Width; w++)
            {
                for (int h = 0; h < permutation.Height; h++)
                {
                    int r = rng.Next(0, 255);
                    int g = rng.Next(0, 255);
                    int b = rng.Next(0, 255);
                    pixels.Add(Color.FromArgb(r, g, b));
                };
            };

            permutation.PixelArray = pixels;
        }

        public void MutatePixelArray(Permutation permutation, double temperature)
        {
            var currentPixels = permutation.CopyPixelArray();
            var pixels = new List<Color>() {};

            foreach (var pixel in currentPixels)
            {
                if (rng.NextDouble() <= temperature)
                {
                    int r = rng.Next(0, 255);
                    int g = rng.Next(0, 255);
                    int b = rng.Next(0, 255);

                    pixels.Add(Color.FromArgb(r, g, b));
                }
                else
                {
                    pixels.Add(pixel);
                }
            };

            permutation.PixelArray = pixels;
        }
   };
}