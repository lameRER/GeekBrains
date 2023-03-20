package seminar.java_seminar_oop_7.DecoratorFactory.src.calculator;

public class CalculableFactory implements ICalculableFactory {

    public Calculable create(int primaryArg) {
        return new Calculator(primaryArg);

    }
}
