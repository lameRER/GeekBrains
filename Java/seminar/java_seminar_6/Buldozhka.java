package seminar.java_seminar_6;


public class Buldozhka {
    // Продумайте структуру класса Бульдожка. Какие поля и методы будут актуальны для приложения, которое является
    // а) информационной системой ухода за ней
    // б) архивом выставки бульдожков
    // в) информационной системой Театра бульдожек имени Дарахвелидзе

    String name;
    int age;
    String colour;
    String sex;
    int idCheap;

    static int count = 0;

    Buldozhka(String name, int age, String colour, String sex) {
        this.name = name;
        this.age = age;
        this.colour = colour;
        this.sex = sex;
        this.idCheap = count + 1;
        setCount();
    }

    public void setCount() {
        count += 1;
    }

    public void freshDog() {
        System.out.println(this.name + " моется");
    }

    public void eatDog() {
        System.out.println(this.name + " кушает");
    }

    public void walkDog() {
        System.out.println(this.name + " гуляет");
    }

    public static void getCount() {
        System.out.println("Собак - " + count);
    }

    @Override
    public String toString() {
        return "Собака №%d: кличка - %s, возраст - %d, цвет - %s, пол - %s".formatted(this.idCheap, this.name, this.age, this.colour, this.sex);
    }
}