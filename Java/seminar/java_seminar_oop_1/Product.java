package seminar.java_seminar_oop_1;

import java.util.Date;

public class Product {

    private String name;


    private double cost;


    private Date loadDate = new Date();


    public Product(String name, double cost) {
        this.name = name;
        this.cost = cost;
    }


    public Product() {
        this("0", 0);
    }

    public void setLoadDate(Date loadDate) {
        this.loadDate = loadDate;
    }

    @Override
    public String toString() {
        return String.format("наименование %s цена %.2f дата загрузки %s", name, cost, loadDate.toString());
    }

    public String getName() {
        return name;
    }

    public double getCost() {
        return cost;
    }

    @Override
    public boolean equals(Object obj) {
        return (this.name.equals(((Product) obj).name) && this.cost == (((Product) obj).cost));
    }

    @Override
    public int hashCode() {
        return name.hashCode() + (int) cost;
    }
}
