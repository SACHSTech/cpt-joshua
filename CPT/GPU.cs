using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT
{
    public class GPU
    {
        private int ranking;
        private string name, change;
        private double marPercent, aprPercent, mayPercent, junPercent, julPercent;
        public GPU(int ranking, string name, double marPercent, double aprPercent, double mayPercent, double junPercent, double julPercent, string change)
        {
            this.ranking = ranking;
            this.name = name;
            this.marPercent = marPercent;
            this.aprPercent = aprPercent;
            this.mayPercent = mayPercent;
            this.junPercent = junPercent;
            this.julPercent = julPercent;
            this.change = change;
        }
        public int getRanking()
        {
            return ranking;
        }
        public string getName()
        {
            return name;
        }
        public double getMarPercent()
        {
            return marPercent;
        }
        public double getAprPercent()
        {
            return aprPercent;
        }
        public double getMayPercent()
        {
            return mayPercent;
        }
        public double getJunPercent()
        {
            return junPercent;
        }
        public double getJulPercent()
        {
            return julPercent;
        }
        
        public string getChange()
        {
            return change;
        }

        public double getValue(string funcName)
        {
            switch (funcName)
            {
                case "getRanking": return Convert.ToDouble(getRanking());
                case "getMarPercent": return getMarPercent();
                case "getAprPercent": return getAprPercent();
                case "getMayPercent": return getMayPercent();
                case "getJunPercent": return getJunPercent();
                case "getJulPercent": return getJulPercent();
                case "getChange": return Convert.ToDouble(getChange());
                default: return 0.00;
            }         
        }
        public String toString()
        {
            return getRanking() + " | " + getMarPercent() + " | " + getAprPercent() + " | " + getMayPercent() + " | " + getJunPercent() + " | " + getJulPercent() + " | " + getChange();
        }
    }
}
