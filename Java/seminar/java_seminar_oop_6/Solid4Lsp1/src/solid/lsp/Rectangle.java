package seminar.java_seminar_oop_6.Solid4Lsp1.src.solid.lsp;

public class Rectangle {
    private int sideA;
    private int sideB;

    public Rectangle(int sideA, int sideB) {
        this.setSideA(sideA);
        this.setSideB(sideB);
    }

    public int getSideA() {
        return sideA;
    }

    public int getSideB() {
        return sideB;
    }

    public void setSideA(int sideA) {
        this.sideA = sideA;
    }

    public void setSideB(int sideB) {
        this.sideB = sideB;
    }

    public int getArea() {
        return sideA * sideB;
    }
}
