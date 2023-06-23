package controller;

import model.User;
import view.View;

import java.io.FileWriter;
import java.io.IOException;

public class UserController {
    private final User model;
    private final View view;

    public UserController(User model, View view) {
        this.model = model;
        this.view = view;
    }

    public void CreateUser(){
        if(Parse(view.CreateUser().split(" "))){
            Save();
        }
        else {
            CreateUser();
        }
    }

    private boolean Parse(String[] usersArray) {
        try {
            for (String data : usersArray) {
                if (data.matches("[a-zA-Zа-яА-Я]+") && !data.equals("f") && !data.equals("m")) {
                    if (data.equals(usersArray[0])) {
                        model.setLastName(data);
                    } else if (data.equals(usersArray[1])) {
                        model.setFirstName(data);
                    } else {
                        model.setSurname(data);
                    }
                } else if (data.matches("\\d{2}\\.\\d{2}\\.\\d{4}")) {

                    model.setDateOfBirth(data);
                } else if (data.matches("\\d+")) {
                    model.setPhoneNumber(data);
                } else if (data.matches("[mf]")) {
                    model.setGender(data.charAt(0));
                } else {
                    throw new IllegalArgumentException("Incorrect input. Try again.");

                }
            }
        } catch (Exception e) {
            view.Exception(e);
            return false;
        }
        return true;
    }

    private void Save(){
        try (FileWriter writer = new FileWriter(model.getLastName() + ".txt", true)) {
            writer.write(model.toString() + "\n");
            System.out.println("User has been added to the file.");
        } catch (IOException e) {
            System.err.println("Error writing to file: " + e.getMessage());
        }
    }
}
