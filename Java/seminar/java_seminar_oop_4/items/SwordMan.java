package seminar.java_seminar_oop_4.items;

import seminar.java_seminar_oop_4.weapons.Sword;

public class SwordMan extends Warrior<Sword> {
    public SwordMan(String name, Sword weapon) {
        super(name, weapon);
    }


    @Override
    public String toString() {
        return super.toString() + " Type = SwordMan";
    }
}
