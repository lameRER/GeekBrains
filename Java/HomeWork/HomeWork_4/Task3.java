package HomeWork.HomeWork_4;
import java.util.*;
import java.util.Stack;


public class Task3 {

//Дана строка содержащая только символы '(', ')', '{', '}', '[' и ']', определите,
// является ли входная строка логически правильной.
// Входная строка логически правильная, если:
// 1) Открытые скобки должны быть закрыты скобками того же типа.
// 2) Открытые скобки должны быть закрыты в правильном порядке. Каждая закрывающая скобка имеет соответствующую
// открытую скобку того же типа.
// ()[] = true
// () = true
// {[()]} = true
// ()() = true
// )()( = false

    public static void main(String[] args) {
        ArrayDeque<Character> sequence  = new ArrayDeque<>(Arrays.asList('(',')','{','}','[',']'));
        System.out.println(validate(sequence));
    }

    public static boolean validate(Deque<Character> deque){
        Map<Character, Character> brackets = new HashMap<>();
        brackets.put(')', '(');
        brackets.put('}', '{');
        brackets.put(']', '[');
        Stack<Character> stack = new Stack<>();
        for (Character item : deque){
            if(brackets.containsValue(item)){
                stack.push(item);
            }
            else if (brackets.containsKey(item) && (stack.isEmpty() || !stack.pop().equals(brackets.get(item)))) return false;
        }
        return stack.isEmpty();
    }
}