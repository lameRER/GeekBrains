import java.util.Scanner;


public class Main {
    public static void main(String[] args) {
//        SayHello();
//        GetName();
//        HiByTime();
        int[] arr = new int[] {1,1,0,1,1,1,0,1,1,1,1,1};
        CounterOf1(arr);
    }

    public static void GetName(){
        Scanner scn = new Scanner(System.in);
        System.out.println("Введите имя: ");
        String username = scn.nextLine();
        scn.close();
        System.out.println("Hello " + username);
    }

    public static void SayHello(){
        System.out.println("Hello world");
    }

    public static void HiByTime(){
        Scanner scn = new Scanner(System.in);
        System.out.println("Введите имя: ");
        String username = scn.nextLine();
        System.out.println("Введите часы: ");
        String hour = scn.nextLine();
        System.out.println("Введите минуты: ");
        String minute = scn.nextLine();
        int hours = Integer.parseInt(hour);
        int minutes = Integer.parseInt(minute);


        if (hours >= 5 && hours < 12){
            System.out.println(username + "Доброе утро " + hours + ":" + minutes);
        }
        else if (hours >= 12 && hours < 18){
            System.out.println(username + "Добрый день " + hours + ":" + minutes);
        }
        else if (hours >= 18 && hours < 23){
            System.out.println(username + "Добрый вечер" + hours + ":" + minutes);
        }
        else if (hours >= 23 || hours < 5){
            System.out.println(username + "Доброй ночи " + hours + ":" + minutes);
        }

        scn.close();
    }

    public static void CounterOf1(int[] arr){
        int incounter = 0;
        int rescounter = 0;
        int i = 0;
        while (i<arr.length){
            if(arr[i] ==1){
                incounter++;
            }
            if((arr[i] != 1 || i == arr.length-1) && incounter > rescounter) {
                rescounter = incounter;
                incounter = 0;
            }
            i++;
        }
        System.out.println(rescounter);
    }
}