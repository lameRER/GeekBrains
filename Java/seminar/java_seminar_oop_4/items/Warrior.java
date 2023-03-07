package seminar.java_seminar_oop_4.items;

import seminar.java_seminar_oop_4.shields.Shield;
import seminar.java_seminar_oop_4.weapons.Weapon;

import java.util.Random;

public abstract class Warrior<T extends Weapon, X extends Shield> {
    private X shield;
    private String name;
    protected T weapon;
    protected Random rnd = new Random();
    private int healthPoint;


    public Warrior(String name, T weapon, X shield) {
        this.name = name;
        this.weapon = weapon;
        this.shield = shield;
        healthPoint = 100;
    }

    public int getHealthPoint() {
        return healthPoint;
    }

    public void reduceHealthPoint(int damage) {
        this.healthPoint -= damage / shield.defend();
    }

    public int hitDamage(Warrior enemy) {
        int damage = rnd.nextInt(weapon.damage());
        enemy.reduceHealthPoint(damage);
        return damage;
    }

    public int getMaxDamage() {
        return weapon.damage();
    }

    public int getShield() {
        return shield.defend();
    }

    @Override
    public String toString() {
        return "Warrior{" + "name='" + name + '\'' + ", weapon=" + weapon + ", healthPoint=" + healthPoint + "shied=" + shield + '}';
    }
}
