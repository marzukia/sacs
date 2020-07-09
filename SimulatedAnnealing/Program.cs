using System;
using System.Drawing;

using SimulatedAnnealing.Objects;
using SimulatedAnnealing.Services;

namespace SimulatedAnnealing
{
    class Program
    {
        public string Filepath = "target.jpg";
        public double StartingTemperature = 1;
        public long Permutations = 100;

        private Target _target;

        private ITargetService _targetService;
        private IGenerationService _generationService;

        public Program()
        {
            _targetService = new TargetService(Filepath);
            _target = _targetService.GetTarget();
            _generationService = new GenerationService(
                _target, StartingTemperature, Permutations);
        }

        static void Main(string[] args)
        {
            var gen1 = _generationService.CreateGeneration();
            Console.WriteLine(gen1.Loss);

            var gen2 = _generationService.CreateNextGeneration(gen1);
            Console.WriteLine(gen2.Loss);
        }
    }
}
