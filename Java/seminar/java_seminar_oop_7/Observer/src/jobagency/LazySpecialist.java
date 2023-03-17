package seminar.java_seminar_oop_7.Observer.src.jobagency;

import java.sql.SQLOutput;

public class LazySpecialist implements Observer{

    private String name;
    private int salary = 0;
    public LazySpecialist(String name){
        this.name = name;
    }
    @Override
    public void receiveOffer(String nameCompany, int salary) {
        if (this.salary != 0){
            System.out.println(String.format("Lazy specialist %s: I completely enjoy of my new job! I don't need any offers!!!\n", name));
        }else {
            this.salary = salary;
            System.out.println(String.format("Lazy specialist %s: I get my first and last job!(work %s, salary = %d)\n", name, nameCompany, salary));
        }
    }
}
