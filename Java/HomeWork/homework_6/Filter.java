package homework.homework_6;

import java.util.*;

public class Filter {
    public static Set<Computer> getFilteredComputersBy(Map<String, String> params, List<Computer> putStore) {
        List<Computer> sortedComputers = new ArrayList<>();
        Set<Computer> filteredComputers = new HashSet<>();
        Set<String> keys = params.keySet();
        for (Computer computer : putStore) {
            for (var key : keys) {
                if (computer.toString().contains(key) && computer.toString().contains(params.get(key))) {
                    sortedComputers.add(computer.getComputer());
                }
            }
        }
        for (Computer computer : sortedComputers) {
//            System.out.println(computer);
            filteredComputers.add(computer.getComputer());
        }
        return filteredComputers;
    }
}
