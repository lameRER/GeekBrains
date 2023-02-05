package seminar.java_seminar_6;

import java.util.*;

public class Task2 {

    // Продумайте структуру класса Бульдожка. Какие поля и методы будут актуальны для приложения, которое является
    // а) информационной системой ухода за ней
    // б) архивом выставки бульдожков
    // в) информационной системой Театра бульдожек имени Дарахвелидзе
    public static void main(String[] args) {
        Buldozhka dog1 = new Buldozhka("Eva", 6, "Black", "Ж");
        Buldozhka dog2 = new Buldozhka("Reks", 5, "Black-White", "M");
        dog1.eatDog();
        Buldozhka.getCount();
        List<Buldozhka> listDog = new ArrayList<>(Arrays.asList(dog1, dog2));
        System.out.println(listDog);
        Map<Integer, Buldozhka> mapDog = new TreeMap<>();
        for (Buldozhka item : listDog) {
            mapDog.put(item.idCheap, item);
        }
        System.out.println(mapDog);
    }
}