package homework.homework_6;

import java.util.ArrayList;
import java.util.List;

public class Shop<E> implements IShop<E> {

    private List<E> product = new ArrayList<>();

    @Override
    public List<E> getComputersFromShop() {
        return this.product;
    }

    @Override
    public void setComputersFromShop(List<E> product) {
//        this.product.addAll(product);
        for (var item : product){
            this.setComputersFromShop(item);
        }
    }

    @Override
    public void setComputersFromShop(E product) {
        this.product.add(product);
    }
}
