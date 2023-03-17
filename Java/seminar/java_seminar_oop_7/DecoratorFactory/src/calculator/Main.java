package seminar.java_seminar_oop_7.DecoratorFactory.src.calculator;

// Создать логирование операций, для класса Calculator. Класс Calculator не должен изменится.
public class Main {
    public static void main(String[] args) {
        ICalculableFactory calculableFactory = new CalculableFactory();
        ICalculableFactory calcFactory = new CalculatorLoggerFactory(calculableFactory, new FileLogger("calclogger.txt"));
        ViewCalculator view = new ViewCalculator(calcFactory);
        view.run();
    }
}
