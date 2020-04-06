using System;

public class ReverseInteger {
    public static void Main(String[] args) {
        int temp = 0;
        int flag = 1;
        int x = Convert.ToInt32(Console.ReadLine());

        if (x < 0) {
            flag = -1;
            x = -x;
        }

        while (x != 0) {
            temp *= 10;
            temp += x % 10;
            x /= 10;
        }

        Console.WriteLine(temp * flag);
    }
}