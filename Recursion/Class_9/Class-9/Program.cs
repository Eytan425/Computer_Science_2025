using System;

class Program
{
    //Page 33 Question 17
    //0,1,1,2,5,29,........
    public static int T17PT1(int n)
    {
        return T17PT1(0, 1, n, 1);
    }
    public static int T17PT1(int n1, int n2, int n, int mone)
    {
        if (mone == n)
            return n1;
        return T17PT1(n2, (n1 * n1) + (n2 * n2), n, mone + 1);
    }
    public static int T17PT2(int n)
    {
        return T17PT2(n, 1);
        
    }
    public static int T17PT2(int n, int mone)
    {
        if (mone > n)
            return 0;
        return T17PT1(mone) + T17PT2(n, mone + 1);
    }
    public static void Main()
    {
        Console.WriteLine(T17PT2(6));
    }
}