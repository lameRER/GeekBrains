package homework.homework_6;

import java.util.List;

public interface IShop<E> {

    List<E> getComputersFromShop();

    void setComputersFromShop(List<E> product);
    void setComputersFromShop(E product);
}
