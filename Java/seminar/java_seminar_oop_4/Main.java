package seminar.java_seminar_oop_4;

import seminar.java_seminar_oop_4.items.Archer;
import seminar.java_seminar_oop_4.items.SwordMan;
import seminar.java_seminar_oop_4.items.Warrior;
import seminar.java_seminar_oop_4.shields.BigShield;
import seminar.java_seminar_oop_4.shields.NotShield;
import seminar.java_seminar_oop_4.shields.SmallShield;
import seminar.java_seminar_oop_4.team.Team;
import seminar.java_seminar_oop_4.weapons.Bow;
import seminar.java_seminar_oop_4.weapons.Sword;

public class Main {
    public static void main(String[] args) {
        Team<Archer> archerTeam = new Team<>("Archers");
        archerTeam.addWarrior(new Archer("Vasya", new Bow(), new NotShield()))
                .addWarrior(new Archer("Petya", new Bow(), new NotShield()))
                .addWarrior(new Archer("Misha", new Bow(), new NotShield()))
                .addWarrior(new Archer("Grisha", new Bow(), new NotShield()));

        System.out.println(archerTeam);

        Team<Warrior> mixTeam = new Team<>("Mixer");
        mixTeam.addWarrior(new Archer("Vasya", new Bow(), new NotShield()))
                .addWarrior(new SwordMan("Petya", new Sword(), new BigShield()))
                .addWarrior(new Archer("Misha", new Bow(), new NotShield()))
                .addWarrior(new SwordMan("Grisha", new Sword(), new SmallShield()));

        System.out.println(mixTeam);

        SwordMan greg = new SwordMan("Petya", new Sword(), new BigShield());
        Archer misha = new Archer("Misha", new Bow(), new NotShield());

        while (greg.getHealthPoint() > 0 && misha.getHealthPoint() > 0) {
            int damage2 = misha.hitDamage(greg);
            int damage1 = greg.hitDamage(misha);
            System.out.printf("Здоровье Гриши: %d Здоровье Миши: %d \n", greg.getHealthPoint(), misha.getHealthPoint());
        }

        if (greg.getHealthPoint()>0)
            System.out.println("Гриша победил");
        else
            System.out.println("Миша победил");
    }
}