package seminar.java_seminar_oop_6.Solid5Lsp2.src.solid;

import seminar.java_seminar_oop_6.Solid5Lsp2.src.solid.lsp.Order;
import seminar.java_seminar_oop_6.Solid5Lsp2.src.solid.lsp.Orderable;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class OrderCalculator implements Iterable<Orderable> {
    private List<Orderable> orders = new ArrayList<>();

    public void add(Orderable order) {
        orders.add(order);
    }

    public int calcAmount() {
        int sum = 0;
        for (Orderable order : orders) {
            sum += order.getAmount();
        }
        return sum;
    }

    @Override
    public Iterator<Orderable> iterator() {
        return orders.iterator();
    }
}
