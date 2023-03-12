package seminar.java_seminar_oop_6.Solid2Srp2.src.solid;

import seminar.java_seminar_oop_6.Solid2Srp2.src.solid.srp.models.Order;

public class Main {
    public static void main(String[] args) {
        System.out.println("Введите заказ:");
        Order order = new Order("", "", 0, 0);
        order.inputFromConsole();
        order.saveToJson();
    }
}
