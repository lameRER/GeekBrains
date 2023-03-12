package seminar.java_seminar_oop_6.Solid7Dip.src.solid.dip;

public class ReportItem{
    private String description;
    private float amount;

    public ReportItem(String description, float amount){
        this.description = description;
        this.amount = amount;
    }
    public String getDescription(){
        return description;
    }
    public float getAmount(){
        return amount;
    }
}