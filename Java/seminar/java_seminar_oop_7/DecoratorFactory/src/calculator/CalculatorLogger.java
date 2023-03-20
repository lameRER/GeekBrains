package seminar.java_seminar_oop_7.DecoratorFactory.src.calculator;

public class CalculatorLogger implements Calculable{


    private Calculable journal;
    private Loggable logger;

    public CalculatorLogger(Calculable journal, Loggable logger){

        this.journal = journal;
        this.logger = logger;
        logger.saveToJournal("Введено число " + journal.getResult());
    }
    @Override
    public Calculable sum(int arg) {
        logger.saveToJournal("Суммируем " + arg);
        return journal.sum(arg);
    }

    @Override
    public Calculable multi(int arg) {
        logger.saveToJournal("Умножаем " + arg);
        return journal.multi(arg);
    }

    @Override
    public int getResult() {
        int result = journal.getResult();
        logger.saveToJournal("Получаем результат " + result);
        return result;
    }
}
