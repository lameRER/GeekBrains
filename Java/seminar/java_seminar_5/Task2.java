package seminar.java_seminar_5;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Task2 {

    // Вам дан массив путей, где пути[i] = [”Город А”, “Город Б”] означают, что существует прямой путь, идущий от
    // ”Город А” до“Город Б”. Верните город назначения, то есть город без какого-либо пути, ведущего в другой город.
    // Пример 1: Input: s = [["Москва","Самара"], ["Курск","Пенза"],["Самара","Курск"]]  Output: Пенза
    // Пример 2: Input: s = [["Москва","Самара"]]  Output: Самара
    public static void main(final String[] args) {
        Map<String, String> map = new HashMap<>();
        {
            map.put("Москва", "Самара");
            map.put("Курск", "Пенза");
            map.put("Самара", "Курск");
        }
        System.out.println(getFinalCity(map));
    }

    public static String getFinalCity(final Map<String, String> map) {
        List<String> arr = new ArrayList<>(map.values());
        for (String i : arr) {
            if (map.containsKey(i))
                continue;
            else
                return i;
        }
        return "такого города нет";
    }
}