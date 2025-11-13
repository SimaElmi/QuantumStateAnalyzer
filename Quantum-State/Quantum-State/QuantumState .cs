using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{

    public class QuantumState
    {
        //حالت تک کیوبیتی
        public Complex Alpha { get; set; } // ضریب |0>
        public Complex Beta { get; set; }  // ضریب |1>
        // حالت دوکیوبیتی (درهم‌تنیدگی)
        public Complex Alpha00 { get; set; }
        public Complex Alpha01 { get; set; }
        public Complex Alpha10 { get; set; }
        public Complex Alpha11 { get; set; }
        public QuantumState(bool twoQubits = false)
        {
            if (!twoQubits)
            {
                //state |0>
                Alpha = Complex.One;
                Beta = Complex.Zero;
            }
            else
            {

                Alpha00 = Complex.One;  // شروع از |00>
                Alpha01 = Alpha10 = Alpha11 = Complex.Zero;
            }
        }

        public void Normalize()
        {
            /*double norm = Math.Sqrt(Alpha.Magnitude * Alpha.Magnitude + Beta.Magnitude * Beta.Magnitude);
            if (norm == 0) return;
            Alpha /= norm;
            Beta /= norm;*/
            double norm;
            if (Alpha00 == Complex.Zero && Alpha01 == Complex.Zero &&
                Alpha10 == Complex.Zero && Alpha11 == Complex.Zero)
            {
                norm = Math.Sqrt(Math.Pow(Alpha.Magnitude,2) + Beta.Magnitude * Beta.Magnitude);
                if (norm == 0) return;
                Alpha /= norm;
                Beta /= norm;
            }
            else
            {
                norm = Math.Sqrt(
                    Alpha00.Magnitude * Alpha00.Magnitude + //a00^2 //math.pow(a00.magnitude,2)
                    Alpha01.Magnitude * Alpha01.Magnitude +//a01^2
                    Alpha10.Magnitude * Alpha10.Magnitude +//a10^2
                    Alpha11.Magnitude * Alpha11.Magnitude);//a11^2
                if (norm == 0) return;
                Alpha00 /= norm; //  i=i/2;  i+=2; i/=2;
                Alpha01 /= norm;
                Alpha10 /= norm;
                Alpha11 /= norm;
            }
        }

        public double Prob0() => Math.Pow(Alpha.Magnitude, 2);
        public double Prob1() => Math.Pow(Beta.Magnitude, 2);

        public double Prob00() => Math.Pow(Alpha00.Magnitude, 2);
        public double Prob01() => Math.Pow(Alpha01.Magnitude, 2);
        public double Prob10() => Math.Pow(Alpha10.Magnitude, 2);

        public double Prob11() => Math.Pow(Alpha11.Magnitude, 2);



        public string PrintState()
        {
           
            string s ;
            /*s = $"|ψ⟩ = ({Alpha.Real:F3} + {Alpha.Imaginary:F3}i)|0⟩ + ({Beta.Real:F3} + {Beta.Imaginary:F3}i)|1⟩";
            return s;*/
            if (Alpha00 == Complex.Zero && Alpha01 == Complex.Zero &&
               Alpha10 == Complex.Zero && Alpha11 == Complex.Zero)
            {
                s=$"|ψ⟩ = ({Alpha.Real:F3}+{Alpha.Imaginary:F3}i)|0⟩ + ({Beta.Real:F3}+{Beta.Imaginary:F3}i)|1⟩";
            }
            else
            {
               s=$"|ψ⟩ = +({Alpha00.Real:F3}+{Alpha00.Imaginary:F3}i)|00⟩\n + ({Alpha01.Real:F3}+{Alpha01.Imaginary:F3}i)|01⟩\n +({Alpha10.Real:F3}+{Alpha10.Imaginary:F3}i)|10⟩ \n+({Alpha11.Real:F3}+{Alpha11.Imaginary:F3}i)|11⟩";
            }
            return s;
        }
        public string GetStateString()
        {
            return
                $"|ψ⟩ = \n" +
                $"  {FormatComplex(Alpha00)} |00⟩\n" +
                $"  {FormatComplex(Alpha01)} |01⟩\n" +
                $"  {FormatComplex(Alpha10)} |10⟩\n" +
                $"  {FormatComplex(Alpha11)} |11⟩";
        }

        // تابع کمکی برای نمایش ضریب با قسمت حقیقی و موهومی
        private string FormatComplex(Complex c)
        {
            string real = c.Real.ToString("F3");
            string imag = c.Imaginary.ToString("F3");
            if (c.Imaginary >= 0)
                return $"{real}+{imag}i";
            else
                return $"{real}{imag}i";
        }

        public string probstate()
        {
            string s;
            s = $"P(|0⟩) = {Prob0():F3},  P(|1⟩) = {Prob1():F3}";
            return s;
        }
        // شبیه‌سازی اندازه‌گیری (single-shot). برگردونه 0 یا 1 و حالت را collapse کند.
        private static readonly Random _rnd = new Random();
        public int Measure()
        {
            double r = _rnd.NextDouble();
            if (r < this.Prob0())
            {
                Alpha = Complex.One;
                Beta = Complex.Zero;
                return 0;
            }
            else
            {
                Alpha = Complex.Zero;
                Beta = Complex.One;
                return 1;
            }
        }
        public void reset()
        {
            Alpha=Complex.One; Beta=Complex.Zero;
        }

    }

}

