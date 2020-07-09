using System;
using System.Drawing;
using System.Collections.Generic;

using SimulatedAnnealing.Objects;

namespace SimulatedAnnealing.Services
{
    public interface IGenerationService
    {
        Generation CreateGeneration();
        Generation CreateGeneration(Permutation permutation);
        Generation CreateNextGeneration(Generation generation);
        void CalculateGenerationLoss(Generation generation);
        void SaveBitMap(Generation generation, string filepath);
    };

    public class GenerationService : IGenerationService
    {
        private Target _target;
        private double _temperature;
        private long _iterations;

        private int _iteration = 0;
        private IPermutationService _permutationService;

        private static Random rng = new Random();

        public GenerationService(Target target, double temperature, long iterations)
        {
            _target = target;
            _temperature = temperature;
            _iterations = iterations;
            _permutationService = new PermutationService();
        }

        public Generation CreateGeneration()
        {
            var permutation = new Permutation(_target.Width, _target.Height);
            _permutationService.PopulatePixelArray(permutation);

            var generation = new Generation(permutation, _iteration);
            CalculateGenerationLoss(generation);

            return generation;
        }


        public Generation CreateGeneration(Permutation permutation)
        {
            var generation = new Generation(permutation, _iteration);
            CalculateGenerationLoss(generation);
            return generation;
        }

        public Generation CreateNextGeneration(Generation currentGeneration)
        {
            _iteration++;
            _temperature -= (_temperature / _iterations);

            var temperature = rng.NextDouble() * _temperature;

            var permutation = currentGeneration.Permutation.DeepCopy();
            _permutationService.MutatePixelArray(permutation, temperature);

            var generation = CreateGeneration(permutation);

            if (generation.Loss > currentGeneration.Loss)
                generation = currentGeneration.DeepCopy();
                generation.Iteration = _iteration;

            return generation;
        }

        public void CalculateGenerationLoss(Generation generation)
        {
            double loss = 0;
            var permutation = generation.Permutation;

            var targetPixels = _target.PixelArray;
            var permutationPixels = permutation.PixelArray;

            for (int i = 0; i < targetPixels.Count; i++)
            {
                double r_delta = Math.Pow((double)(targetPixels[i].R - permutationPixels[i].R), 2);
                double g_delta = Math.Pow((double)(targetPixels[i].G - permutationPixels[i].G), 2);
                double b_delta = Math.Pow((double)(targetPixels[i].B - permutationPixels[i].B), 2);
                double pixel_loss = Math.Sqrt(r_delta + g_delta + b_delta);

                loss += pixel_loss;
            };

            generation.Loss = loss;
        }

        public void SaveBitMap(Generation generation, string filepath)
        {
            var permutation = generation.Permutation;
            var width = (int)permutation.Width;
            var height = (int)permutation.Height;
            var bmp = new Bitmap(width, height);

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    bmp.SetPixel(w, h, permutation.PixelArray[w + (h * width)]);
                };
            };

            bmp.Save(filepath);
        }
    };
}