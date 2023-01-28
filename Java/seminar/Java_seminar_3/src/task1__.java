/*
Напишите программу, которая принимает с консоли число 
в формате byte и записывает его в файл ”result.txt”.

Требуется перехватить все возможные ошибки и вывести их в логгер.

После написания, попробуйте подать на вход числа 100 и 200 
и проследите разницу в результате
*/

/*
Комментарий к условию задачи:
Наименьший по размеру целочисленный тип это byte (8-битовый тип)
с диапазоном допустимых значений от -128 до 127.
При вводе 200 будет вызвана ошибка "Value out of range".
*/

package homework2;

import java.util.Scanner;
import java.io.FileWriter;
import java.io.IOException;
import java.util.logging.*;

public class task1{

    public static void send_log(String text) throws IOException {
        
        Logger logger = Logger.getLogger(task1.class.getName());
        FileHandler fh = new FileHandler("log_for_task1.txt", true);
        logger.addHandler(fh);
        
        SimpleFormatter sFormat = new SimpleFormatter();
        fh.setFormatter(sFormat);
        
        logger.log(Level.INFO, text);
        fh.close();
    }

    public static String get_data_console_format_byte_return_string(String text) throws IOException {

        System.out.printf(text);
        String data_str = "";
        
        try {
            Scanner terminal_scanner = new Scanner(System.in);
            byte data = terminal_scanner.nextByte();
            terminal_scanner.close();
            data_str = Byte.toString(data);
        }
        catch (Exception e) {
            //System.out.printf(e.toString());
            send_log(e.toString());
        }
        return data_str;
    }

    public static void writing_data_in_txt_file(String data_str, String file_name) throws IOException {
        
        file_name +=".txt";
    
        if (data_str == ""){
            return;
        }
    
        try (FileWriter file_for_write = new FileWriter(file_name, true)) {

            file_for_write.write(data_str + "\n");
            file_for_write.flush();
            file_for_write.close();
        }
        catch (IOException e) {
            send_log(e.getMessage());
        }
    }

    public static void main(String[] args) throws IOException {

        String text = "Введите число в формате byte: ";

        String data_str = get_data_console_format_byte_return_string(text);

        String file_name = "result";
        
        writing_data_in_txt_file(data_str,file_name);
    }
}