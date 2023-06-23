import controller.UserController;
import model.User;
import view.View;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        User model = new User();
        View view = new View();
        UserController controller = new UserController(model, view);
        controller.CreateUser();
    }
}