package seminar.java_seminar_oop_6.Solid5Lsp2.src.solid.lsp;

public class Order extends AbstractOrder implements Orderable {


    public Order(int qnt, int price) {
        super(price, qnt);
    }

    public int getAmount() {
        return qnt * price;
    }

}
