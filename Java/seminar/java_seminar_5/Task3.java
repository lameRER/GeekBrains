package seminar.java_seminar_5;

import java.util.Map;
import java.util.TreeMap;

public class Task3 {

    // Дана строка. Необходимо написать метод, который отсортирует слова в строке по длине с помощью TreeMap.
    // Строки с одинаковой длиной не должны “потеряться”.
    public static void main(final String[] args) {
        String str = "мама Папа папа привет пок g";
        Map<Integer, String> map = new TreeMap<>();
        for (String i : str.split(" ")) {
            map.put(i.hashCode(), i);
        }
        System.out.println(getSortedIncludesWords(map));
    }

    public static String getSortedIncludesWords(final Map<Integer, String> map) {
        return String.join(" ", map.values());
    }

}