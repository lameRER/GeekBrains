package seminar.java_seminar_3;
// Даны следующие строки, cравнить их с помощью == и метода equals()
public class Task0 {
    public static void main(String[] args) {
         String s1 = "hello";
         String s2 = "hello";
         String s3 = s1;
         String s4 = "h" + "e" + "l" + "l" + "o";
         String s5 = new String("hello");
         String s6 = new String(new char[]{'h', 'e', 'l', 'l', 'o'});
         String[] str_arr = new String[] {s1, s2, s3, s4, s5, s6};

         for (int i = 0; i < 6; i++){
             for (int j = i + 1; j < 6; j++){
                 System.out.println((i+1) + " " + (j+1));
                 System.out.println("== " + (str_arr[i] == str_arr[j]));
                 System.out.println("equals " + str_arr[i].equals(str_arr[j]));
             }
         }
    }
}
