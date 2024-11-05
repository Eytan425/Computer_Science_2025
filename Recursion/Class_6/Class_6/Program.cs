using System;

class Program
{
    //Page 33 Question 12
    public static bool T12(int n)
    {
        int remainder = n % 2;//Or 1 or 0
        Console.WriteLine(remainder);
        return T12(n, remainder);
    }
    public static bool T12(int n, int remainder)
    {
        if(n== 0)
            return true;
        if(n%2 != remainder)
            return false;
        return T12(n / 10, remainder);
    }
    //Recursive
    public static bool T12Another(int n)
    {
        int remainder = n % 2;
        if(n == 0)
            return true;
        if (n % 2 != remainder)
            return false;
        return T12Another(n / 10);
    }
    //Page 33 Question 13
    public static bool T13(int n, int k)
    {
        if(n == 0 && k == 0)
        {
            return true;
        }
        if(n == 0 || k == 0)
        {
            return false;
        }
        return T13(n / 10, k/10);
    }
    public static int T14(int n)
    {
        return T14(n, 1);
    }
    public static int T14(int n, int num )//num=1
    {
        int tosefet = num * 2;
        if(num > n)
        {
            return 0;
        }
        if(num %2 ==0 )
        {
            tosefet = num * num;

        }
        return tosefet + (T14(n, num + 1));
    }
    public static void Main()
    {
        Console.WriteLine(T14(5));
    }


}