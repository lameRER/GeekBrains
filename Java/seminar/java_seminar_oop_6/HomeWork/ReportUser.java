package seminar.java_seminar_oop_6.HomeWork;

public class ReportUser {
    private final IUser user;

    public ReportUser(IUser user){

        this.user = user;
    }

    public void report(){
        System.out.println("Report for user: " + user.getName());
    }
}
