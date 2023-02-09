package seminar.java_seminar_5;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Objects;

public class Task1 {

    // Дана последовательность чисел. Необходимо вернуть число совпадающих пар в этой последовательности
    // Пример 1:     In: arr = [1, 2]  Out: 0
    // Пример 2:     In: arr = [1, 1, 2]  Out: 1
    // Пример 3:     In: arr = [1, 1, 1, 2, 2]  Out: 4
    public static void main(String[] args) {
        ArrayList<Integer> arr = new ArrayList<>(Arrays.asList(1, 1, 1, 2, 2));
        System.out.println(getNumberOfCouples(arr));
    }

    public static Integer getNumberOfCouples(List<Integer> list) {
        Integer count = 0;
        for (int i = 0; i < list.size(); i++) {
            for (int j = i + 1; j < list.size(); j++) {
                if (Objects.equals(list.get(i), list.get(j)))
                    count++;
            }
        }
        return count;
    }

}