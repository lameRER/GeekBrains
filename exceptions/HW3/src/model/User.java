package model;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Date;

public class User {
    private String lastName;
    private String firstName;
    private String Surname;
    private LocalDate dateOfBirth;
    private String phoneNumber;
    private Character gender;


    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getSurname() {
        return Surname;
    }

    public void setSurname(String surname) {
        Surname = surname;
    }

    public LocalDate getDateOfBirth() {
        return dateOfBirth;
    }

    public void setDateOfBirth(String data) throws IllegalArgumentException{
        try {
            LocalDate dateOfBirth = LocalDate.parse(data, DateTimeFormatter.ofPattern("dd.MM.yyyy"));
            this.dateOfBirth = dateOfBirth;
        }
        catch (IllegalArgumentException e){
            throw new IllegalArgumentException("Invalid dateOfBirth");
        }
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) throws IllegalArgumentException {
        if (phoneNumber.matches("^((8|7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$")) {
            this.phoneNumber = phoneNumber;
        } else {
            throw new IllegalArgumentException("Invalid phone number format.");
        }
    }

    public Character getGender() {
        return gender;
    }

    public void setGender(Character gender) throws IllegalArgumentException {
        if (gender == 'm' || gender == 'f') {
            this.gender = gender;
        } else {
            throw new IllegalArgumentException("Invalid gender.");
        }
    }

    @Override
    public String toString() {
        return lastName + " " + firstName + " " + Surname + " " + dateOfBirth + " " + phoneNumber + " " + gender;
    }
}
