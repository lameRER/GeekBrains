package seminar.java_seminar_oop_6.Solid1Srp1.src.solid;

import seminar.java_seminar_oop_6.Solid1Srp1.src.solid.srp.Point;
import seminar.java_seminar_oop_6.Solid1Srp1.src.solid.srp.Square;
import seminar.java_seminar_oop_6.Solid1Srp1.src.solid.srp.SquareCalculation;
import seminar.java_seminar_oop_6.Solid1Srp1.src.solid.srp.SquareView;

public class Main {
    public static void main(String[] args) {
        int side = 5;
        int scale = 1;
        System.out.printf("Площадь фигуры: %d \n", new SquareCalculation(side).getArea());

        new SquareView(scale,side).draw();
    }
}
