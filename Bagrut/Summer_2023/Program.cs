using System;

class Program
{
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
    public static int Size(Queue<int> queue)
    {
        Queue<int> cloneQueue = CloneQueue(queue);
        int counter = 0;
        while(!cloneQueue.IsEmpty())
        {
            counter++;
            cloneQueue.Remove();
        }
        return counter;
    }
    public static void ShowQueue(Queue<int> queue)
    {
        int num = 0;
        if(queue.IsEmpty())
        {
            Console.WriteLine("The queue is empty!");
            return;
        }
        Queue<int> copyQueue = CloneQueue(queue);
        while(!copyQueue.IsEmpty())
        {
            num = copyQueue.Remove();
            Console.WriteLine($"{num} ");
        }
    }
    public static Queue<int> CreateQueue()
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
    public static int getNum()
    {
        Console.WriteLine("Enter a number, -999 exit: ");
        return int.Parse(Console.ReadLine());
    }
    public static bool TwoSum(Queue<int> q, int x)
    {
        while(!q.IsEmpty())
        {
            int num = q.Remove();
            Queue<int> cloneQue = CloneQueue(q);
            while(!cloneQue.IsEmpty())
            {
                if(num + cloneQue.Remove() == x)
                    return true;
            }
        }
        return false;
    }

    public static void Main()
    {
        OrderedList list = new OrderedList();

        list.InsertNum(5);
        list.InsertNum(2);
        list.InsertNum(8);
        list.InsertNum(5);
        list.InsertNum(3);
        list.InsertNum(8);
        list.InsertNum(2);
        list.InsertNum(2);
        list.InsertNum(6);
        list.PrintList();
    }

    
}