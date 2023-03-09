package seminar.java_seminar_oop_5;

import seminar.java_seminar_oop_5.personal.controllers.UserController;
import seminar.java_seminar_oop_5.personal.model.FileOperation;
import seminar.java_seminar_oop_5.personal.model.FileOperationImpl;
import seminar.java_seminar_oop_5.personal.model.Repository;
import seminar.java_seminar_oop_5.personal.model.RepositoryFile;
import seminar.java_seminar_oop_5.personal.views.Validation;
import seminar.java_seminar_oop_5.personal.views.ViewUser;

public class Main {
    public static void main(String[] args) {
        FileOperation fileOperation = new FileOperationImpl("users.txt");
        Repository repository = new RepositoryFile(fileOperation);
        UserController controller = new UserController(repository,new Validation());
        ViewUser view = new ViewUser(controller);
        view.run();
    }
}
