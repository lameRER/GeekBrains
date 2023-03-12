package seminar.java_seminar_oop_6.Solid3Ocp1.src.solid.ocp;

public class Circle implements Shape{
    private int radius;

    public Circle(int radius) {
        this.radius=radius;
    }

    public int getRadius() {
        return radius;
    }

    @Override
    public double getArea() {
        return Math.PI*Math.pow( radius, 2);
    }

}
