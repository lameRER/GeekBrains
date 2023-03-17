package seminar.java_seminar_oop_7.DecoratorFactory.src.calculator;

import java.io.FileWriter;
import java.io.IOException;
import java.time.LocalDateTime;

public class FileLogger implements Loggable{

    private String filename;

    public FileLogger(String filename){

        this.filename = filename;
    }
    @Override
    public void saveToJournal(String event){
        try{
            FileWriter writer = new FileWriter(filename, true);
            LocalDateTime eventTime = LocalDateTime.now();
            writer.write(String.format("%s %s \n", eventTime, event));
            writer.flush();
            writer.close();
        } catch (IOException e) {
            throw new RuntimeException(e.getMessage());
        }
    }
}
