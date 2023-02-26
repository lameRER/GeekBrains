package seminar.java_seminar_oop_3;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        User.setSorter(new User.SorterLastName());

        User[] BillKlinton = new User[]{
                new User("Monika", "Livinsky", 48),
                new User("Monika", "Livinsky", 68)
        };
        User[] users = new User[]{
                new User("Bill", "Klinton", 98, BillKlinton),
                new User("Bill", "Gatse", 86),
                new User("Tom", "Kruse", 98),
                new User("Chipollino", "Radary", 198)
        };


        Personal personal = new Personal(users);


        for (User user : personal) {
            System.out.println(user);
        }

        List<User> myUsers = personal.toList();

        Collections.sort(myUsers);

        System.out.println(myUsers);

        User Boss = new User("Alex", "Makedonsry", 43, users);

        Company company = new Company(Boss);
        System.out.println();
        for (User user : company) {
            System.out.println(user);
        }
        System.out.println("Sout Lambda");

        company.forEach(item-> System.out.println(item));
        System.out.println("Sout Lambda Array");

        Arrays.stream(users).forEach(user -> System.out.println(user));

    }
}