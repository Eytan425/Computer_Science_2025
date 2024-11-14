using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

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
    public static int T06(int num)
    {
        if(num < 10)
            return num;
        return T06(num/10);    
    }
    public static int T07(int num1, int num2)
    {
        //NNum1 > Num2
        if(num1 < num2)
            return 0;
        return 1 + T07(num1-num2, num2);     
    }
    public static int T08(int num1, int num2)
    {
        if(num1 < num2)
        {
            return num1;
        }
        return T08(num1-num2, num2);        
    }
    public static bool T09(int num, int digit)
    {
        if(digit > num)
            return false;
        if(num%10 == digit)
            return true;
        return T09(num/10, digit);
    }
    public static bool T10(int x, int y)
    {
        //x needs to be a multiple of y
        if(x > y)
            return false;
        if((y-x)%2==0)
            return true;
        return T10(x,y-x);
        
    }
    public static bool T11(int num)
    {
        return T11(num,2);
    }
    public static bool T11(int num, int counter)
    {
        if(counter==num)
        {
            return true;
        }
        if(num%counter==0)
        {
            return false;
        }

        return T11(num, counter+1);    
    }
    public static void Main()
    {
        Console.WriteLine(T11(11));
        // Console.WriteLine(T10(2,247));
    }
}