using System;
using System.Drawing;
using System.Collections.Generic;

using SimulatedAnnealing.Objects;

namespace SimulatedAnnealing.Services
{
    public interface ITargetService
    {
        List<Color> GetPixelArray();
        Target GetTarget();
    };

    public class TargetService : ITargetService
    {
        public Tuple<long, long> Dimensions { get => Tuple.Create(_width, _height); }

        private Bitmap _target;
        private long _width;
        private long _height;

        public TargetService(string filepath)
        {
            _target = new Bitmap(filepath, true);
            _width = _target.Width;
            _height = _target.Height;
        }

        public List<Color> GetPixelArray()
        {
            var pixelArray = new List<Color> {};

            for (int h = 0; h < _height; h++)
            {
                for (int w = 0; w < _width; w++)
                {
                    pixelArray.Add(_target.GetPixel(w, h));
                }
            };

            return pixelArray;
        }

        public Target GetTarget()
        {
            var pixelArray = GetPixelArray();
            return new Target(_width, _height, pixelArray);
        }
    };
}