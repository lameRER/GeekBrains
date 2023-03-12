package seminar.java_seminar_oop_6.Solid7Dip.src.solid.dip;

import java.util.List;

public class PrintReport implements Output{
    public void output(List<ReportItem> items) {
        System.out.println("Output to printer");
        for (ReportItem item : items) {
            System.out.format("printer %s - %f \n\r", item.getDescription(), item.getAmount());
        }
    }
}