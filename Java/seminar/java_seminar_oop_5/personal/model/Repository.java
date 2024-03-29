package seminar.java_seminar_oop_5.personal.model;

import java.util.List;

public interface Repository {
    List<User> getAllUsers();

    String createUser(User user);

    void saveUsers(List<User> users);
}
