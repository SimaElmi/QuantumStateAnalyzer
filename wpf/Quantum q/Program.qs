namespace Quantum_StateAnalyzer {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Measurement;

    operation MeasureQubit() : Result {
        use q = Qubit();
        H(q);
        let r = M(q);
        Reset(q);
        return r;
    }

    operation BellExperiment() : (Result, Result) {
        use (q1, q2) = (Qubit(), Qubit());
        H(q1);
        CNOT(q1, q2);
        let r1 = M(q1);
        let r2 = M(q2);
        ResetAll([q1, q2]);
        return (r1, r2);
    }
}
