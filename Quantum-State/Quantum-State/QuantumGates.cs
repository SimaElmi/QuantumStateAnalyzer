using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    static class QuantumGates
    {
        public static Complex[,] X => new Complex[,]
        {
            { 0, 1 },
            { 1, 0 }
        };

        public static Complex[,] Z => new Complex[,]
        {
            { 1, 0 },
            { 0, -1 }
        };
        public static Complex[,] I => new Complex[,]
        {
            { 1, 0 },
            { 0, 1 }
        };
        public static Complex[,] Y => new Complex[,]
    {
        { 0, -Complex.ImaginaryOne },
        { Complex.ImaginaryOne, 0 }
    };
        public static Complex[,] H => new Complex[,]
        {
            { 1/Math.Sqrt(2), 1/Math.Sqrt(2) },
            { 1/Math.Sqrt(2), -1/Math.Sqrt(2) }
        };
        public static Complex[,] H1 => new Complex[,]
       {
            { 1/Math.Sqrt(2), 0, 1/Math.Sqrt(2), 0 },
            { 0, 1/Math.Sqrt(2), 0, 1/Math.Sqrt(2) },
            { 1/Math.Sqrt(2), 0, -1/Math.Sqrt(2), 0 },
            { 0, 1/Math.Sqrt(2), 0, -1/Math.Sqrt(2) }
       };

        public static Complex[,] CNOT => new Complex[,]
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 0, 1 },
            { 0, 0, 1, 0 }
        };


        // گیت I ⊗ H (اعمال H روی کیوبیت دوم)
        public static Complex[,] H2
        {
            get
            {
                double s = 1 / Math.Sqrt(2);
                return new Complex[,]
                {
                    { s, s, 0, 0 },
                    { s, -s, 0, 0 },
                    { 0, 0, s, s },
                    { 0, 0, s, -s }
                };
            }
        }
    }
}
