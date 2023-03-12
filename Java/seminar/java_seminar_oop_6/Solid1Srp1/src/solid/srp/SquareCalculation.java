package seminar.java_seminar_oop_6.Solid1Srp1.src.solid.srp;

public class SquareCalculation {

    private int side;
    public SquareCalculation(int side) {
        this.side = side;
    }

    public int getArea() {
        return side * side;
    }
    public int getSide(){
        return side;
    }
}
