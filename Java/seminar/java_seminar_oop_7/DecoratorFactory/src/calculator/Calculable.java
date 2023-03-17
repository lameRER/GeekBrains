package seminar.java_seminar_oop_7.DecoratorFactory.src.calculator;

public interface Calculable {
    Calculable sum(int arg);
    Calculable multi(int arg);
    int getResult();
}
