using System.Collections.Generic;

namespace SimulatedAnnealing.Objects
{
    public class Generation
    {
        public Permutation Permutation { get; set; }
        public long Iteration { get; set; }
        public double Loss { get; set; }

        public Generation(Permutation permutation, long iteration)
        {
            Permutation = permutation.DeepCopy();
            Iteration = iteration;
        }

        public Generation DeepCopy()
        {
            var clone = (Generation) this.MemberwiseClone();
            clone.Permutation = Permutation.DeepCopy();
            clone.Iteration = Iteration;
            clone.Loss = Loss;

            return clone;
        }
    };
};