package seminar.java_seminar_oop_3;

import java.awt.*;
import java.util.*;
import java.util.Iterator;
import java.util.List;

public class Personal implements Iterable<User> {

    private User[] users;

    public Personal(User[] users) {
        this.users = users;
    }

    public List<User> toList() {
        List<User> users = new ArrayList<User>();
        for (User user : this) {
            users.add(user);
        }
        return users;
    }

    @Override
    public Iterator<User> iterator() {
        return new PersonalIterator();
    }

    protected class PersonalIterator implements Iterator<User> {

        private int index = 0;

        @Override
        public boolean hasNext() {
            return index < users.length;
        }

        @Override
        public User next() {
            return users[index++];
        }
    }
}



