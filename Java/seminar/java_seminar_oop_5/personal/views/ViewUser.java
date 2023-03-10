package seminar.java_seminar_oop_5.personal.views;

import seminar.java_seminar_oop_5.personal.controllers.UserController;
import seminar.java_seminar_oop_5.personal.model.User;

import java.util.List;
import java.util.Scanner;

public class ViewUser {

    private final UserController userController;

    public ViewUser(UserController userController) {
        this.userController = userController;
    }

    public void run() throws Exception {
        Commands com = null;

        while (true) {
            String command = prompt("Введите команду: ");
            try {
                com = Commands.valueOf(command.toUpperCase());
            } catch (Exception e) {
                com = Commands.valueOf("NULL".toUpperCase());
            }
            if (com == Commands.EXIT) return;
                switch (com) {
                    case CREATE:
                        createUser();
                        break;
                    case READ:
                        readUser();
                        break;
                    case LIST:
                        listUsers();
                        break;
                    case UPDATE:
                        updateUser();
                        break;
                    case DELETE:
                        deleteUser();
                    default:
                        System.out.println("Введено недопустимое значение");
                }
            }
    }

    private void updateUser() throws Exception {
        String readId = prompt("Введиет редактируемый ID юзера: ");
        userController.updateUser(readId,inputUser());
    }

    private void listUsers() {
        List<User> listUsers = userController.readAllUsers();
        for (User user : listUsers) {
            System.out.println(user + "\n");
        }
    }

    private void readUser() throws Exception {
        String id = getUserId();

        User user = userController.readUser(id);
        System.out.println(user);

    }

    private String getUserId() {
        return prompt("Идентификатор пользователя: ");
    }

    private User inputUser() {
        String firstName = prompt("Имя: ");
        String lastName = prompt("Фамилия: ");
        String phone = prompt("Номер телефона: ");
        return new User(firstName, lastName, phone);
    }

    private void createUser() throws Exception {
        userController.saveUser(inputUser());
    }


    private String prompt(String message) {
        Scanner in = new Scanner(System.in);
        System.out.print(message);
        return in.nextLine();
    }

    private void deleteUser() throws Exception {
        String userId = getUserId();
        userController.deleteUser(userId);
    }
}
