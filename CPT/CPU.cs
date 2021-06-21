using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT
{
    public class CPU
    {
        private int _ranking;
        private double _cores, _mar, _apr, _may, _jun, _jul;
        private string _os, _change;
        public CPU(int ranking, double cores, string os, double mar, double apr, double may, double jun, double jul, string change)
        {
            Ranking = ranking;
            Cores = cores;
            OS = os;
            Mar = mar;
            Apr = apr;
            May = may;
            Jun = jun;
            Jul = jul;
            Change = change;
        }
        public int Ranking
        {
            get { return _ranking; }
            set { _ranking = value; }
        }
        public double Cores
        {
            get { return _cores; }
            set { _cores = value; }
        }
        public double Mar
        {
            get => _mar;
            set => _mar = value;
        }
        public double Apr
        {
            get => _apr;
            set => _apr = value;
        }
        public double May
        {
            get => _may;
            set => _may = value;
        }
        public double Jun
        {
            get => _jun;
            set => _jun = value;
        }
        public double Jul
        {
            get => _jul;
            set => _jul = value;
        }
        public string Change
        {
            get => _change;
            set => _change = value;
        }
        public string OS
        {
            get => _os;
            set => _os = value;
        }
        public double getValue(string funcName)
        {
            switch (funcName)
            {
                case "Ranking": return Convert.ToDouble(Ranking);
                case "Cores": return Cores;
                case "Mar": return Mar;
                case "Apr": return Apr;
                case "May": return May;
                case "Jun": return Jun;
                case "Jul": return Jul;
                case "Change": return Convert.ToDouble(Change);

                default: return 0.00;
            }
        }
    }
}
