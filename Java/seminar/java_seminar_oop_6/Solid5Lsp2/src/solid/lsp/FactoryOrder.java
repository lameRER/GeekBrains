package seminar.java_seminar_oop_6.Solid5Lsp2.src.solid.lsp;

public class FactoryOrder {
    public Orderable create(int qnt, int price, boolean isBonus) {
        if (isBonus) {
            return new OrderBonus(qnt, price);
        }
        return new Order(qnt, price);
    }
}
