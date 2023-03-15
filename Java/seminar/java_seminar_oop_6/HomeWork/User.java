package seminar.java_seminar_oop_6.HomeWork;

public class User implements IUser {
    private final String name;

    public User(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}