namespace Quantum_Analyser {
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    //
    // Operation #1: Single qubit measurement
    //
    operation MeasureQubit() : Result {
        using (q = Qubit()) {
            let r = M(q);
            Reset(q);
            return r;
        }
    }

    //
    // Operation #2: Bell experiment (entangled measurement)
    //
    operation BellExperiment() : (Result, Result) {
        using ((q1, q2) = (Qubit(), Qubit())) {
            H(q1);
            CNOT(q1, q2);

            let r1 = M(q1);
            let r2 = M(q2);

            Reset(q1);
            Reset(q2);

            return (r1, r2);
        }
    }

    //
    // Optional demo entrypoint
    //
    @EntryPoint()
    operation HelloQ() : Unit {
        Message("Hello from Q#!");
    }
}
