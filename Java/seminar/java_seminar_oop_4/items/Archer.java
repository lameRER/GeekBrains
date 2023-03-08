package seminar.java_seminar_oop_4.items;

import seminar.java_seminar_oop_4.shields.Shield;
import seminar.java_seminar_oop_4.weapons.Bow;

public class Archer extends Warrior<Bow, Shield> implements DistanceAttacker {
    private int distance;

    public Archer(String name, Bow weapon, Shield shield) {
        super(name, weapon, shield);

        distance = weapon.getDistance() + rnd.nextInt(10);
    }

    public int getDistance() {
        return distance;
    }

    @Override
    public String toString() {
        return super.toString() + " Type = Archer{" +
                "distance=" + distance +
                '}';
    }
}
