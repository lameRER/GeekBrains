package seminar.java_seminar_oop_6.Solid1Srp1.src.solid.srp;

public class SquareView {
    private int scale;
    private int side;

    private int scaledSide;

    public SquareView(int scale, int side) {
        this.scale = scale;
        this.side = side;
        scaledSide = scale*side;
    }

    public void draw() {
        printHorizontalBorder();
        printVerticalBorder();
        printHorizontalBorder();
    }
    private void printHorizontalBorder(){
        for (int i = 0; i < scaledSide; i++) {
            System.out.print("* ");
        }
    }

    private void printVerticalBorder(){
        System.out.println();
        for (int i = 0; i < scaledSide-2; i++) {
            System.out.print("* ");
            for (int j = 1; j < scaledSide - 1; j++) {
                System.out.print("  ");
            }
            System.out.println("*");
        }
    }
}
