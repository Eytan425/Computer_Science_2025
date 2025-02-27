using System;
using System.Diagnostics.Contracts;
using System.Net.Security;

class Program
{
    public static int GetMaxValue(Node<int> lst)
    {
        Node<int> pos = lst;
        int max = int.MinValue;
        while(pos!=null)
        {
            if(pos.GetValue() >=  max)
                max = pos.GetValue();
            pos = pos.GetNext();
        }
        return max;
        
    }
    public static int GetSize(Node<int> lst)
    {
        Node<int> pos = lst;
        int count = 0;
        while(pos!=null)
        {
            count++;
            pos = pos.GetNext();
        }
        return count;
    }
    public static Node<int> Delete(int num, Node<int> lst)
    {
        if (lst == null)
            return null;
        
        if (lst.GetValue() == num)
            return lst.GetNext();
        
        lst.SetNext(Delete(num, lst.GetNext()));
        return lst;
    }
    public static BiList GenerateBiList(Node<int> lst)
    {
        BiList biList = new BiList();
        Node<int> pos = lst;
        int size = GetSize(lst);
        int counter = 0;
        while(pos!=null)
        {
            biList.AddNum(GetMaxValue(pos), 1);
            counter++;
            if(counter > size / 2)
            {
                biList.AddNum(pos.GetValue(), 2);
            }
            pos = pos.GetNext();
        }
        return biList;
    }
    public static Node<int> Move(Node<int> lst, int n)
    {
        // Get the size of the list
        int size = GetSize(lst); // size = 7 for the list [1, 2, 3, 4, 5, 6, 7]
        
        // Initialize pos to the head of the list
        Node<int> pos = lst; // pos = Node with value 1
        
        // Move pos to the node just before the segment to be moved
        for(int i = 0; i < (size - n - 1); i++) // Loop runs 3 times for n = 3
        {
            pos = pos.GetNext(); // pos = Node with value 4 after the loop
        }
        
        // Set temp to the start of the segment to be moved
        Node<int> temp = pos.GetNext(); // temp = Node with value 5
        
        // Break the list at pos
        pos.SetNext(null); // List is now [1, 2, 3, 4] and [5, 6, 7]
        
        // Initialize pos2 to temp
        Node<int> pos2 = temp; // pos2 = Node with value 5
        
        // Move pos2 to the end of the segment to be moved
        while(pos2.GetNext() != null) // Loop runs 2 times
        {
            pos2 = pos2.GetNext(); // pos2 = Node with value 7 after the loop
        }
        
        // Attach the old head to the end of the new segment
        pos2.SetNext(lst); // List is now [5, 6, 7, 1, 2, 3, 4]
        
        // Return the new head of the list
        return temp; // temp = Node with value 5
    }
    public static void PrintList(Node<int> head)
    {
        Node<int> current = head;
        while (current != null)
        {
            Console.Write(current.GetValue() + " -> ");
            current = current.GetNext();
        }
        Console.WriteLine("null");
    }
    public static int Size(Queue<int> que)
    {
        int counter = 0;
        Queue<int> temp = new Queue<int>();
        while (!que.IsEmpty())
        {
            counter++;
            temp.Insert(que.Remove());
        }
        while (!temp.IsEmpty())
        {
            que.Insert(temp.Remove());
        }
        return counter;
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

    public static bool IsIdentical(Queue<int> q1,  Queue<int> q2)
    {
        Queue<int> newQue1 = CloneQueue(q1);
        Queue<int> newQue2 = CloneQueue(q2);
        while(!newQue1.IsEmpty() && !newQue2.IsEmpty())
        {
            if(newQue1.Remove() != newQue2.Remove())
            {
                return false;
            }
        }
        if(newQue1.IsEmpty() && newQue2.IsEmpty())
        {
            return true;
        }
        return false;
    }
    public static bool IsSimilar(Queue<int> q1,  Queue<int> q2)
    {
        int size = Size(q1);
        for(int i = 0; i < size; i++)
        {
            if(IsIdentical(q1,q2))
                return true;
            q1.Insert(q1.Remove());
            
        }
        return false;
    }
    public static void Main(string[] args)
    {
        // Create a linked list: 1 -> 2 -> 3 -> 4
        Node<int> node1 = new Node<int>(1);
        Node<int> node2 = new Node<int>(2);
        Node<int> node3 = new Node<int>(3);
        Node<int> node4 = new Node<int>(4);
        Node<int> node5 = new Node<int>(5);
        Node<int> node6 = new Node<int>(6);

        // Link nodes
        node1.SetNext(node2);
        node2.SetNext(node3);
        node3.SetNext(node4);
        node4.SetNext(node5);
        node5.SetNext(node6);

        // Display the original list
        Console.WriteLine("Original list:");
        PrintList(node1);

        // Move a segment (for example, move 3 positions from the end)
        Node<int> newHead = Move(node1, 3);

        // Display the modified list
        Console.WriteLine("\nModified list after moving 3 positions:");
        PrintList(newHead);

        // Create two queues
        Queue<int> queue1 = new Queue<int>();
        Queue<int> queue2 = new Queue<int>();

        // Add elements to the queues
        queue1.Insert(1);
        queue1.Insert(2);
        queue1.Insert(3);

        queue2.Insert(3);
        queue2.Insert(1);
        queue2.Insert(2);

        // Check if the queues are identical
        bool identical = IsSimilar(queue1, queue2);
        Console.WriteLine($"\nAre the queues identical? {identical}");

        
    }
}