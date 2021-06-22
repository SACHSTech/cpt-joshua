using System;

namespace CPT
{
    /**
     * A class to store data about each gpu
     * @author Joshua Shuttleworth
     */
    public class GPU
    {
        // Private feild decloration
        private int ranking;
        private string name, change;
        private double marPercent, aprPercent, mayPercent, junPercent, julPercent;

        // Constructor
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

        /**
         * A getter method for ranking
         * @return ranking
         */
        public int getRanking()
        {
            return ranking;
        }

        /**
         * A getter method for name
         * @return name
         */
        public string getName()
        {
            return name;
        }

        /**
         * A getter method for marPercent
         * @return marPercent
         */
        public double getMarPercent()
        {
            return marPercent;
        }

        /**
         * A getter method for aprPercent
         * @return aprPercent
         */
        public double getAprPercent()
        {
            return aprPercent;
        }

        /**
         * A getter method for mayPercent
         * @return mayPercent
         */
        public double getMayPercent()
        {
            return mayPercent;
        }

        /**
         * A getter method for junPercent
         * @return junPercent
         */
        public double getJunPercent()
        {
            return junPercent;
        }

        /**
         * A getter method for julPercent
         * @return julPercent
         */
        public double getJulPercent()
        {
            return julPercent;
        }

        /**
         * A getter method for change
         * @return change
         */
        public string getChange()
        {
            return change;
        }

        /**
         * @param funcName
         * @return the value of a varible given its name
         */
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

        /**
         * Useless toString added to emulate java
         */
        public String toString()
        {
            return getRanking() + " | " + getMarPercent() + " | " + getAprPercent() + " | " + getMayPercent() + " | " + getJunPercent() + " | " + getJulPercent() + " | " + getChange();
        }
    }
}
