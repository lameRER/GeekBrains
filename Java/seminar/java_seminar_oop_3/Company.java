package seminar.java_seminar_oop_3;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class Company implements Iterable<User> {
    User BigBoss;

    public Company(User bigBoss) {
        BigBoss = bigBoss;
    }

    private List<User> getCollectionUsers(User user){
        List<User> result = new ArrayList<User>();
        result.add(user);
        for (User item: user.getPersonal()) {
            result.addAll(getCollectionUsers(item));
        }
        return result;
    }

    @Override
    public Iterator<User> iterator() {
        return getCollectionUsers(BigBoss).iterator();
    }
}
