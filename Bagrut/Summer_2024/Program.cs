using System;

class Program
{
    public static Queue<T> CloneQueueGeneric<T>(Queue<T> queue)
    {
        T num;
        Queue<T> copyQueue = new Queue<T>();
        Queue<T> tempQueue = new Queue<T>();
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

    public static bool IsMagic(Queue<int> q, int m)
    {
        int counter = 1;
        Queue<int> tempQueue = CloneQueueGeneric(q);
        while(!tempQueue.IsEmpty())
        {
            if(counter+1 == m)
            {
                if (tempQueue.IsEmpty())
                    return false;

                int num = tempQueue.Remove();
                if (tempQueue.IsEmpty())
                    return false;

                int num1 = tempQueue.Remove();
                if (tempQueue.IsEmpty())
                    return false;

                int num3 = tempQueue.Remove();
                if(num + num3 == num1)
                    return true;
                tempQueue.Insert(num);
                tempQueue.Insert(num1);
                tempQueue.Insert(num3);
            }
            else
            {
                tempQueue.Remove();
            }
            counter++;
        }
        return false;
    }

    public static void Main()
    {
        Queue<int> q = new Queue<int>();
        q.Insert(1);
        q.Insert(2);
        q.Insert(1);
        q.Insert(4);
        q.Insert(5);

        int m = 2;

        bool result = IsMagic(q, m);
        Console.WriteLine($"IsMagic result: {result}");
    }
}