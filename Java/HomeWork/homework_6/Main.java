package homework.homework_6;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {
    public static void main(String[] args) {
        var shop = new Shop<Computer>();
        var comp = new ArrayList<Computer>();
        addProduct(comp);
        shop.setComputersFromShop(comp);


        Map<String, String> sortStore = new HashMap<>();
        sortStore.put(String.valueOf(OS.Windows), String.valueOf(RAM.RAM_16GB));
        sortStore.put(String.valueOf(OS.linux), String.valueOf(Color.blue));

        var filteredTable = Filter.getFilteredComputersBy(sortStore, shop.getComputersFromShop());
        System.out.println(filteredTable);

        System.out.println(SortingList.sortByPrice(filteredTable));
    }

    static void addProduct(List<Computer> product){
        product.add(new Computer(
                CPU.i7,
                RAM.RAM_16GB,
                Disk.SSD_256GB,
                GPU.nvidia_GTX1060,
                OS.Windows,
                Color.blask,
                70000));
        product.add(new Computer(
                CPU.i5,
                RAM.RAM_8GB,
                Disk.HDD_258GB,
                GPU.nvidia_GTX1030,
                OS.linux,
                Color.blue,
                60000));
        product.add(new Computer(
                CPU.i3,
                RAM.RAM_4GB,
                Disk.HDD_258GB,
                GPU.nvidia_GTX1030,
                OS.linux,
                Color.blue,
                50000));
    }
}
