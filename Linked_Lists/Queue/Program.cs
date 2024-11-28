using System;
using System.Runtime.CompilerServices;

class Program
{
    public static int getNum()
    {
        Console.WriteLine("Enter a number, -999 exit: ");
        return int.Parse(Console.ReadLine());
    }
    public static Queue<int> createQueue()
    {
        Queue<int> outQueue = new Queue<int>();
        int num = getNum();
        while(num!=-999)
        {
            outQueue.Insert(num);
            num = getNum();
        }
        return outQueue;
    }
    public static Queue<int> CloneQueue(Queue<int> queue)
    {
        int num;
        Queue<int> copyQueue = new Queue<int>();
        Queue<int> tempQueue = new Queue<int>();
        while(!queue.IsEmpty())
            tempQueue.Insert(queue.Remove());
        while(!tempQueue.IsEmpty())
        {
            num = tempQueue.Remove();
            queue.Insert(num);
            copyQueue.Insert(num);
        }
        return copyQueue;
    }
    public static void ShowQueue(Queue<int> queue)
    {
        if(queue.IsEmpty())
            Console.WriteLine("The queue is empty!");
            return;
        
    }
    public static void Main()
    {
        Queue<int> queue = createQueue();
        ShowQueue(queue);
    }
}