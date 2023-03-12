package seminar.java_seminar_oop_6.HomeWork;

public class User{
	private String name;
	
	public User(String name){
		this.name = name;
	}
	
	public String getName(){
		return name;
	}
	
	public void save(){
		Persister persister = new Persister(this);
		persister.save();
	}
	
	public void report(){
		System.out.println("Report for user: " + name);
	}
}