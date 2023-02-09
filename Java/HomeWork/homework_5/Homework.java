package homework.homework_5;

import java.util.HashMap;

public class Homework {

    // Реализуйте структуру телефонной книги с помощью HashMap, учитывая, что 1 человек может иметь несколько телефонов.
// Пусть дан список сотрудников:Иван Иванов (и остальные)
// Написать программу, которая найдет и выведет повторяющиеся имена с количеством повторений.
// Отсортировать по убыванию популярности.
    public static void main(final String[] args) {
        var dict = new HashMap<String, String>();
        dict.put("88001122333", "Иван Иванов");
        dict.put("88001662333", "Иван Курицин");
        dict.put("88001112333", "Иван Курицин");
        dict.put("88001122432", "Иван Незлобин");
        dict.put("88001112453", "Сергей Потапов");
        dict.put("88001632145", "Сергей Потапов");
        dict.put("88001424214", "Сергей Курицин");
        dict.put("88001424215", "Сергей Курицин");
        dict.put("88001424216", "Сергей Курицин");
        dict.put("88001234374", "Михаил Незлобин");

        var a = get(dict);

        a.entrySet().stream()
                .sorted((k1, k2) -> -k1.getValue().compareTo(k2.getValue()))
                .forEach(k -> System.out.println(k.getKey() + ": " + k.getValue()));
    }


    public static HashMap<String, Integer> get(HashMap<String, String> dict){
        var result = new HashMap<String, Integer>();
        for (var item : dict.entrySet()) {
            if (result.containsKey(item.getValue())) {
                var key = item.getValue();
                var value = result.get(item.getValue());
                result.replace(key, value + 1);
            } else {
                result.put(item.getValue(), 1);
            }
        }
        return result;
    }
}
//
//    OutPut
//    Иван - 3
//    Сергей - 2
//    Потому как если один сотрудник имеет 2 или более номера , его имя считаем 1 раз.
