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
            var pixelArray = new List<Color>() {};

            for (int w = 0; w < permutation.Width; w++)
            {
                for (int h = 0; h < permutation.Height; h++)
                {
                    int r = rng.Next(0, 255);
                    int g = rng.Next(0, 255);
                    int b = rng.Next(0, 255);
                    pixelArray.Add(Color.FromArgb(r, g, b));
                };
            };
        }

        public void MutatePixelArray(Permutation permutation, double temperature)
        {
            var pixelArray = permutation.PixelArray.Clone();

            foreach (var pixel in pixelArray)
            {
                if (rng.NextDouble() <= temperature)
                {
                    int r = rng.Next(0, 255); 
                    int g = rng.Next(0, 255); 
                    int b = rng.Next(0, 255);

                    pixel = Color.FromArgb(r, g, b);
                };
            };

            permutation.PixelArray = pixelArray;
        }
   };
}