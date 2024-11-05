using System;

class Program
{
    //Page 35 Question 34
    public static String T34(String str)
    {
        return T34(str, 0);
    }
    public static String T34(string str, int index)
    {
        if (index == str.Length)
        {
            return "";
        }
        return T34(str, index + 1) + str[index];
    }
    //Page 35 Question 35
    public static void T35(char c1, char c2)
    {
        if (c1 > c2)
        {
            T35(c2, c1, 0);
        }
        else
        {
            T35(c1, c2, 0);
        }
    }

    public static void T35(char c1, char c2, int stam)
    {
        if (c1 == c2)
        {
            return;
        }
        Console.Write(c1);
        T35((char)(c1 + 1), c2, stam);

    }

    public static void Main()
    {
        char c1 = 'a';
        char c2 = 'z';
        T35(c1, c2);
    }
}