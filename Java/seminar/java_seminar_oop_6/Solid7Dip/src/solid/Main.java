package seminar.java_seminar_oop_6.Solid7Dip.src.solid;

import seminar.java_seminar_oop_6.Solid7Dip.src.solid.dip.DisplayReport;
import seminar.java_seminar_oop_6.Solid7Dip.src.solid.dip.PrintReport;
import seminar.java_seminar_oop_6.Solid7Dip.src.solid.dip.Report;

public class Main {
    public static void main(String[] args) {
        Report report = new Report();
        report.calculate();
        report.output(new PrintReport());
        report.output(new DisplayReport());
    }
}
