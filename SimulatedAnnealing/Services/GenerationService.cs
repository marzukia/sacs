using System.Collections.Generic;

using SimulatedAnnealing.Objects;

namespace SimulatedAnnealing.Services
{
    public interface IGenerationService
    {
        Generation CreateGeneration(Permutation permutation);
        Generation CreateNextGeneration(Generation generation);
        void CalculateGenerationLoss(Generation generation);
    };

    public class GenerationService : IGenerationService
    {
        private Target _target;
        private double _temperature;
        private long _iterations;

        private int _iteration = 0;
        private IPermutationService _permutationService;

        public GenerationService(Target target, double temperature, long permutations)
        {
            _target = target;
            _temperature = temperature;
            _iterations = permutations;
        }

        public Generation CreateGeneration(Permutation permutation = null)
        {
            if (permutation == null)
                permutation = new Permutation(_target.Width, _target.Height);
                _permutationService.PopulatePixelArray(permutation);

            var generation = new Generation(permutation, _iteration);
            CalculateGenerationLoss(generation);
            
            return generation;
        }

        public Generation CreateNextGeneration(Generation currentGeneration)
        {
            _iteration++;

            var permutation = currentGeneration.Permutation.DeepCopy();
            _permutationService.MutatePixelArray(permutation, temperature);

            var generation = CreateGeneration(permutation);

            if (generation.Loss > currentGeneration.Loss)
                generation = currentGeneration.DeepCopy();
                generation.Iteration = _iteration;
        
            _temperature -= (_temperature / _iterations);

            return generation;
        }

        public void CalculateGenerationLoss(Generation generation)
        {
            double loss = 0;
            var permutation = generation.Permutation;

            for (int i; i < _target.Count(); i++)
            {
                double r_delta = Math.Pow((double)(_target[i].R - permutation[i].R));
                double g_delta = Math.Pow((double)(_target[i].G - permutation[i].G));
                double b_delta = Math.Pow((double)(_target[i].B - permutation[i].B));
                double pixel_loss = Math.Sqrt(r_delta + g_delta + b_delta);

                loss += pixel_loss;
            };

            permutation.Loss = loss;
        }
    };
}