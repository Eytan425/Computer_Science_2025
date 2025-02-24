using System;
using System.Runtime.InteropServices;

class Program
{

    public static int GetNum()
    {
        Console.WriteLine("Enter a number, -999 exit: ");
        return int.Parse(Console.ReadLine());
    }
    public static Queue<int> createQueue()
    {
        Queue<int> outQueue = new Queue<int>();
        int num = GetNum();
        while(num!=-999)
        {
            outQueue.Insert(num);
            num = GetNum();
        }
        return outQueue;
    }
    
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
    public static void ShowQueue(Queue<int> queue)
    {
        int num = 0;
        if(queue.IsEmpty())
        {
            Console.WriteLine("The queue is empty!");
            return;
        }
        Queue<int> copyQueue = CloneQueueGeneric(queue);
        while(!copyQueue.IsEmpty())
        {
            num = copyQueue.Remove();
            Console.WriteLine($"{num} ");
        }
    }
    //First Question
    public static int Size<T>(Queue<T> queue)
    {
        int count = 0;
        Queue<T> temp = CloneQueueGeneric(queue);
        while(!temp.IsEmpty())
        {
            temp.Remove();
            count++;
        }
        return count;
    }
    

    public static bool TwoSum(Queue<int> q, int x)
    {

        while(!q.IsEmpty())
        {
            int header = q.Remove();
            Queue<int> tempQueue = CloneQueueGeneric(q);
            while(!tempQueue.IsEmpty())
            {
                int num = tempQueue.Remove();
                if(header+num ==x)
                {
                    return true;
                }
            }
        }

        return false;
    }
    //Second question is the the NumCount file
    public static void Main(string[] args)
    {
        
        OrderedList orderedList = new OrderedList();

        // Insert numbers into the ordered list
        orderedList.InsertNum(5);
        orderedList.InsertNum(3);
        orderedList.InsertNum(8);
        orderedList.InsertNum(1);
        orderedList.InsertNum(5); // Duplicate to test count increment

        // Print the list to verify the order and counts
        Node<NumCount> current = orderedList.GetNode();
        while (current != null)
        {
            Console.WriteLine($"Number: {current.GetValue().GetNum()}, Count: {current.GetValue().GetCount()}");
            current = current.GetNext();
        }
        Console.WriteLine($"Value at position 5: {orderedList.ValueN(5)}");
    }
}