package seminar.java_seminar_oop_2.zoo;

public abstract class Herbivores extends Animal {

    public Herbivores(String name) {
        super(name);
    }

    @Override
    public String feed() {
        return "Grass";
    }


}
