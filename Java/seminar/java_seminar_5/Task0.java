package seminar.java_seminar_5;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Task0 {
    public static void main(String[] args) {
        Task0 task0 = new Task0();
        List<Integer> integerList = new ArrayList<Integer>();
        int maxCount = 10;

        for (int j = 0; j < 2; j++) {
            for (int i = 0; i < maxCount; i++) {
                integerList.add(i);
            }
        }

        System.out.println(task0.getSumOfUniqueValues(integerList));


    }

    public Integer getSumOfUniqueValues(final List<Integer> list) {
        int outputSUM = 0;
        Map countMap = fillMap(list);

        for (Object item : countMap.keySet()) {
            outputSUM = outputSUM + (Integer) item;
        }

        return outputSUM;
    }

    private Map fillMap(List<Integer> list) {
        Map outputMap = new HashMap();
        int fixNum = 0;
        for (Integer item : list) {
            outputMap.putIfAbsent(item, fixNum);
        }
        return outputMap;
    }

}