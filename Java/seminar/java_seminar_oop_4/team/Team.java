package seminar.java_seminar_oop_4.team;

import seminar.java_seminar_oop_4.items.DistanceAttacker;
import seminar.java_seminar_oop_4.items.Warrior;

import java.util.ArrayList;
import java.util.List;

public class Team<T extends Warrior> {
    private List<T> team = new ArrayList<>();
    private String name;

    public Team(String name) {
        this.name = name;
    }

    public Team<T> addWarrior(T warrior) {
        team.add(warrior);
        return this;
    }

    public int getMaxDistance() {
        int distance = 0;
        for (T item : team) {
            if (!(item instanceof DistanceAttacker)) {
                continue;
            }
            DistanceAttacker temp = (DistanceAttacker) item;
            if (temp.getDistance() > distance) {
                distance = temp.getDistance();
            }
        }
        return distance;
    }

    public int getTeamDamage() {
        int sum = 0;
        for (T item : team) {
            sum += item.getMaxDamage();
        }
        return sum;
    }

    public int getTeamMinShield(){
        int min = 100;
        for (T item : team){
            int shied = item.getShield();
            if (shied < min){
                min = shied;
            }
        }
        return min;
    }

    @Override
    public String toString() {
        StringBuilder teamBuilder = new StringBuilder();
        for (T item : team) {
            teamBuilder.append(item.toString()).append("\n");
        }
        return String.format("Team{ team= %s, maxDistance = %d, maxDamage = %d, minShied = %d \n%s}", name, getMaxDistance(), getTeamDamage(), getTeamMinShield(), teamBuilder);
    }
}
