package seminar.java_seminar_oop_6.Solid5Lsp2.src.solid.lsp;

public class OrderBonus extends AbstractOrder implements Orderable {

    public OrderBonus(int qnt, int price) {
        super(price, qnt);
    }

    @Override
    public int getAmount() {
        return 0;
    }


}
