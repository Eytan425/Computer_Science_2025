using System;

class Program
{
    //Page 32
    public static int T01(int n)
    {
        if(n == 0)
            return n;
        return n + T01(n-1);    
    }
    public static int T02(int n)
    {
        if(n == 1)
            return n;
        if(n%2 == 0)
            n-=1;
        return n*T02(n-2);    
    }
    public static int T03(int n)
    {
        if(n==1)
            return n;
        return n * T03(n-1);    
    }
    public static int T04(int n)
    {
        int amount = 1;
        if(n < 10)
            return 1;
        return amount+T04( n/10);    

    }
    public static int T05(int n)
    {
        if(n < 10 && n%2==1)
            return 0;
        if((n %10)%2 == 1)
        {
            n/=10;
        }
        return n%10+T05(n/10);
        
    }
    
    public static void Main()
    {
        Console.WriteLine(T04(1234));
    }
}