package seminar.java_seminar_oop_6.Solid6Isp1.src.solid.isp;

public class InternetPaymentService implements Webable, CreditCardable, PhoneNumberable{
    @Override
    public void payWebMoney(int amount) {
        System.out.printf("Internet pay by web money %d\n", amount);
    }

    @Override
    public void payCreditCard(int amount) {
        System.out.printf("Internet pay by credit card %d\n", amount);
    }

    @Override
    public void payPhoneNumber(int amount) {
        System.out.printf("Internet pay by phone number %d\n", amount);
    }
}
