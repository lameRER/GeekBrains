package seminar.java_seminar_oop_6.HomeWork;

public class Main{
	public static void main(String[] args){
		IUser user = new User("Bob");
		new ReportUser(user).report();
		new SaveUser(user).save();
	}
}