package seminar.java_seminar_oop_2.zoo;

public class Crocodile extends Predator implements Runable, Flyable {
    private int flightSpeed = 15;
    private int flightHing = 5;
    private int runSpeed = 100;

    public Crocodile(String name) {
        super(name);
    }

    @Override
    public String say() {
        return "Shhhhh";
    }

    @Override
    public int getSpeedFlyable() {
        return this.flightSpeed;
    }

    @Override
    public int getHigh() {
        return this.flightHing;
    }

    @Override
    public int getSpeedRun() {
        return this.runSpeed;
    }
}
