package homework.homework_6;

public class Computer implements IComputer{

    private CPU CPU;
    private RAM RAM;
    private Disk Disk;
    private GPU GPU;
    private OS OS;
    private Color color;
    private int price;

    public Computer(CPU CPU, RAM RAM, Disk disk, GPU GPU, OS OS, Color color, int price) {
        this.CPU = CPU;
        this.RAM = RAM;
        this.Disk = disk;
        this.GPU = GPU;
        this.OS = OS;
        this.color = color;
        this.price = price;
    }

    @Override
    public void setPrice(int price) {
        this.price = price;
    }

    @Override
    public void setPrice() {
        if (this.CPU == CPU.i7){
            this.price = 70000;
        }
        else if (this.CPU == CPU.i5){
            this.price = 60000;
        }
        else if (this.CPU == CPU.i3){
            this.price = 50000;
        }
    }

    @Override
    public int getPrice() {
        return this.price;
    }

    @Override
    public Computer getComputer() {
        return new Computer(CPU, RAM, Disk, GPU, OS, color, price);
    }

    @Override
    public String toString() {
        return String.format("CPU: %s, ОЗУ: %s, HDD: %s, OS: %s, Цвет: %s, Цена: %d р.\n", this.CPU, this.RAM, this.Disk, this.OS, this.color, this.price);
    }
}
