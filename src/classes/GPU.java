package classes;

public class GPU {
    private int ranking;
    private String name, change;
    private double marPercent, aprPercent, mayPercent, junPercent, julPercent;

    public GPU(int ranking, String name, double marPercent, double aprPercent, double mayPercent, double junPercent, double julPercent, String change) {
        this.ranking = ranking;
        this.name = name;
        this.marPercent = marPercent;
        this.aprPercent = aprPercent;
        this.mayPercent = mayPercent;
        this.junPercent = julPercent;   
        this.change = change;   
    }
    public int getRanking() {
        return ranking;
    }
    public String getName() {
        return name;
    }
    public double getMarPercent() {
        return marPercent;
    }
    public double getAprPercent() {
        return aprPercent;
    }
    public double getMayPercent() {
        return mayPercent;
    }
    public double getJunPercent() {
        return junPercent;
    }
    public double getJulPercent() {
        return julPercent;
    }
    public String getChange() {
        return change;
    }
    @Override
    public String toString() {
        return getRanking() + " | " + getMarPercent() + " | " + getAprPercent() + " | " + getMayPercent() + " | " + getJunPercent() + " | " + getJulPercent() + " | " + getChange();
    }
}
