using System;
using System.Drawing;

using SimulatedAnnealing.Objects;
using SimulatedAnnealing.Services;

namespace SimulatedAnnealing
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "target.jpg";
            double startingTemperature = 1;
            long iterations = (long)10e7;

            ITargetService _targetService = new TargetService(filepath);
            Target _target = _targetService.GetTarget();
            IGenerationService _generationService = new GenerationService(
                _target, startingTemperature, iterations);

            var gen = _generationService.CreateGeneration();
            for (int i = 0; i < iterations; i++)
            {
                gen = _generationService.CreateNextGeneration(gen);

                if (i % 100000 == 0)
                {
                    Console.WriteLine(gen.Loss);
                    _generationService.SaveBitMap(gen, $"output/{i}.bmp");
                };
            }
        }
    }
}
