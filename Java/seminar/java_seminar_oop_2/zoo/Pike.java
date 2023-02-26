package seminar.java_seminar_oop_2.zoo;

public class Pike extends Predator implements Swimable{

    private int flightSwim = 25;

    public Pike(String name) {
        super(name);
    }

    @Override
    public int getSpeedSwimable() {
        return this.flightSwim;
    }

    @Override
    public String say() {
        return "brrbl";
    }
}
