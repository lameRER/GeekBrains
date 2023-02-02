package seminar.Java_seminar_3;// Дан список с десятью случайными числами, нужно отсортировать
import java.util.*;

public class Task1 {

    public static List<Integer> sortByCollections(List<Integer> list){
        Collections.sort(list);
        return list;
    }

    public static List<Integer> sortByComparator(List<Integer> list){
        Collections.sort(list, new Comparator<Integer>(){
        @Override
            public int compare(Integer i1, Integer i2) {
                return i1 - i2;
            }
        });
        return list;
    }

    public static void main(String[] args) {
        List<Integer> list = new ArrayList<>(Arrays.asList(1, 9, 2, 6, 4, 3, 5, 7, 8, 0));
        System.out.println(sortByCollections(list));
        System.out.println(sortByComparator(list));
    }
}
