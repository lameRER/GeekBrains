package seminar.java_seminar_oop_6.Solid6Isp1.src.solid.isp;


public class TerminalPaymentService implements Webable, CreditCardable {

    @Override
    public void payWebMoney(int amount) {
        System.out.printf("Terminal pay by web money %d\n", amount);
    }

    @Override
    public void payCreditCard(int amount) {
        System.out.printf("Terminal pay by credit card %d\n", amount);
    }
}
