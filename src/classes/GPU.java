package classes;

public class GPU {
    private int ranking;
    private String name;
    private double marPercent, aprPercent, mayPercent, junPercent, julPercent;

    public GPU(int ranking, String name, double marPercent, double aprPercent, double mayPercent, double junPercent, double julPercent) {
        this.ranking = ranking;
        this.name = name;
        this.marPercent = marPercent;
        this.aprPercent = aprPercent;
        this.mayPercent = mayPercent;
        this.junPercent = julPercent;      
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
}
