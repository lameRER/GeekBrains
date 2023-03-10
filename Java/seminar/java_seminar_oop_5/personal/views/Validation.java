package seminar.java_seminar_oop_5.personal.views;

import seminar.java_seminar_oop_5.personal.model.User;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Validation {
        Pattern namePattern = Pattern.compile("^\\S+$");
        Pattern phonePattern = Pattern.compile("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$");
    public void validateUser(User inputUser) throws IllegalArgumentException, NumberFormatException{
        Matcher nameMatcher = namePattern.matcher(inputUser.getFirstName());
        Matcher lastnameMatcher = namePattern.matcher(inputUser.getLastName());
        Matcher phoneMatcher = phonePattern.matcher(inputUser.getPhone());
        if(!nameMatcher.find()){
            throw new IllegalArgumentException("Такое имя недопустимо!");
        }
        if(!lastnameMatcher.find()){
            throw new IllegalArgumentException("Такая фамилия недопустимая!");
        }
        if(!phoneMatcher.find()){
            throw new NumberFormatException("Такая телефона недопустимая!");
        }
    }
}
