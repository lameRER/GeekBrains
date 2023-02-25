package seminar.java_seminar_oop_1;

import java.time.LocalDate;

public class Perishable extends Product {
    private LocalDate expireDate;

    public Perishable(String name, double cost, LocalDate expireDate) {
        super(name, cost);
        this.expireDate =  expireDate;
    }

    @Override
    public String toString() {
        StringBuilder localString = new StringBuilder(super.toString());
        localString.append(String.format(" годен до %s", expireDate));
        return localString.toString();
    }
}
