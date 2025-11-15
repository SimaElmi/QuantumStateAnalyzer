using System.Windows;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using Quantum_Analyser;


namespace Quantum_StateAnalyzer
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Apply(object sender, RoutedEventArgs e)
        {
            using var sim = new QuantumSimulator();

            var result = await MeasureQubit.Run(sim);
            Input.Text = result == Result.Zero? "|0⟩" : "|1⟩";
        }

        private async void RunBell(object sender, RoutedEventArgs e)
        {
            using var sim = new QuantumSimulator();

            (Result r1, Result r2) = await BellExperiment.Run(sim);

            Input.Text = $"Q1: {(r1 == Result.Zero ? "|0⟩" : "|1⟩")}, " +
                         $"Q2: {(r2 == Result.Zero ? "|0⟩" : "|1⟩")}";
        }
    }
}
