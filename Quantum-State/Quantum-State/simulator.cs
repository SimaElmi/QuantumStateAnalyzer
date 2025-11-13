using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class simulator
    {
        public QuantumState State { get; private set; }
        private List<Complex[,]> gates = new List<Complex[,]>();

        public simulator()
        {
            State = new QuantumState();
        }

        public void ApplyGate(Complex[,] gate)
        {
            var α = State.Alpha;
            var β = State.Beta;

            var newAlpha = gate[0, 0] * α + gate[0, 1] * β;
            var newBeta = gate[1, 0] * α + gate[1, 1] * β;

            State.Alpha = newAlpha;
            State.Beta = newBeta;
            State.Normalize();
        }


        // افزودن گیت جدید به دنباله
        public void AddGate(Complex[,] gate)
        {
            gates.Add(gate);
        }
        public void ApplyAll()
        {
            foreach (var gate in gates)
            {
                ApplyGate(gate);
            }
        }

        public void Clear()
        {
            gates.Clear();


        }
    }
}
