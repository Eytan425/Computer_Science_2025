using System;

class Program
{
    //Page 35 Question 39
    public static void T39()
    {
        T39(1, 1);
    }
    public static void T39(int rows, int columns)
    {
        if(columns > 10)
        {
            Console.WriteLine();
            columns = 1;
            rows++;
        }
        if(rows > 10)
        {
            return;
        }
        Console.Write("{0,4}", rows*columns);
        T39(rows, columns + 1);
    }
    public static void Main()
    {
        T39(1, 1);
    }
}