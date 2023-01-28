// Дан список содержащий строки и числа в строковом формате.
// C помощью итератора пройти по списку и вывести в консоль что является строкой, а что числом
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.List;

public class Task2 {
    public static void main(String[] args) {
        List<String> list = new ArrayList<>(Arrays.asList("a", "2", "b", "3", "c", "4"));
        printResultOfCheck(list);
    }

    public static void printResultOfCheck(List<String> list){
        Iterator<String> itr = list.iterator();
        String tmp = "";
        while (itr.hasNext()){
            tmp = itr.next();
            try{
                Integer.parseInt(tmp);
                System.out.println("Это число! " + tmp);
            } catch (Exception e){
                System.out.println("Это строка! " + tmp);
            }
    }

}
}
