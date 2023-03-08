package seminar.java_seminar_oop_4.items;

import seminar.java_seminar_oop_4.shields.Shield;
import seminar.java_seminar_oop_4.weapons.Sword;

public class SwordMan extends Warrior<Sword, Shield> {
    public SwordMan(String name, Sword weapon, Shield shield) {
        super(name, weapon, shield);
    }


    @Override
    public String toString() {
        return super.toString() + " Type = SwordMan";
    }
}
