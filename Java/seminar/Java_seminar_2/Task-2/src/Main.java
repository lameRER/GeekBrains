public class Main {
    public static void main(String[] args) {
        String s = "Dcba";
        final int[] index = new int[]{3, 2, 1, 4};
        System.out.println(shuffle(s, index));
    }

    public static String shuffle(final String s, final int[] index) {
        String outputResult = "";
        String temp = "";
        for (int i = 0; i < index.length; i++) {
            outputResult = outputResult + s.charAt(index[i] - 1);
        }
        return outputResult;
    }
}