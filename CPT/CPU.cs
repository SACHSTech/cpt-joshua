namespace CPT
{
    /// <summary>
    /// A class to data of each cpu
    /// unlike the gpu class which I did in the java style since this was secondary to the main main cpt I did thing one with c# conventions
    /// @author Joshua Shuttleworth
    /// </summary>
    public class CPU
    {
        // Constructor
        public CPU(int _ranking, double _cores, string _os, double _mar, double _apr, double _may, double _jun, double _jul, string _change)
        {
            Ranking = _ranking;
            Cores = _cores;
            OS = _os;
            Mar = _mar;
            Apr = _apr;
            May = _may;
            Jun = _jun;
            Jul = _jul;
            Change = _change;
        }

        // Getters and setters
        public int Ranking { get; private set; }
        public double Cores { get; private set; }
        public double Mar { get; private set; }
        public double Apr { get; private set; }
        public double May { get; private set; }
        public double Jun { get; private set; }
        public double Jul { get; private set; }
        public string Change { get; private set; }
        public string OS { get; private set; }
    }
}
