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
            Permutation = permutation.Clone();
            Iteration = iteration;
        }

        public Generation DeepCopy()
        {
            var clone = (Generation) this.MemberwiseClone();
            other.Permutation = Permutation.DeepCopy();
            other.Iteration = Itertation;
            other.Loss = Loss;

            return clone;
        }
    };
};