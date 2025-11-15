using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum_State
{
    public static class QuantumInterface
    {
        public static void RunHelloQ()
        {
            using var sim = new QuantumSimulator();

            // Call the Q# operation in the Quantum_Analyser project
            Quantum_Analyser.HelloQ.Run(sim).Wait();
        }
    }
}
