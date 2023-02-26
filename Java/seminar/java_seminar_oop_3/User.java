package seminar.java_seminar_oop_3;

public class User implements Comparable<User> {
    private String firstName;
    private String lastName;
    private int age;

    private Personal personal = new Personal(new User[]{});

    private static Sorter sort;

    public Personal getPersonal() {
        return personal;
    }


    public static void setSorter(Sorter sort) {
        User.sort = sort;
    }

    public User(String firstName, String lastName, int age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public User(String firstName, String lastName, int age, User[] personal) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.personal = new Personal(personal);
    }


    @Override
    public String toString() {
        return "User{" +
                "firstName='" + firstName + '\'' +
                ", lastName='" + lastName + '\'' +
                ", age=" + age +
                "} \n";
    }

    @Override
    public int compareTo(User o) {
        return sort.compare(this, o);
    }

    public static abstract class Sorter {
        public abstract int compare(User u1, User u2);
    }

    public static class SorterFirstName extends Sorter {

        @Override
        public int compare(User u1, User u2) {
            return u1.firstName.compareTo(u2.firstName);

        }
    }

    public static class SorterLastName extends Sorter {

        @Override
        public int compare(User u1, User u2) {
            return u1.lastName.compareTo(u2.lastName);

        }
    }
}

