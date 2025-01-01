using System;

class Program
{
    public static int GetNum()
    {
        Console.WriteLine("Enter any number, -999 to end: ");
        return int.Parse(Console.ReadLine());
    }
    public static Node<int> CreateList()
    {
        int num = GetNum();
        Node<int> first = new Node<int>(num);
        Node<int> pos = first, newNode;
        num = GetNum();
        while(num!=-999)
        {
            newNode = new Node<int>(num);
            pos.SetNext(newNode);
            pos=pos.GetNext();
            num=GetNum();
        }
        return first;
    }
    public static void ShowList(Node<int> first)
    {
        Node<int> pos = first;
        while(pos!= null)
        {
            Console.Write($"{pos.GetValue()} ");
            pos.GetNext();
        }
    }
    public static bool IsNumInList(Node<int> first, int num)
    {
        Node<int> pos = first;
        while(pos!=null)
        {
            if(pos.GetNext() == num)
            {
                return true;
            }
            pos = pos.GetNext();
        }
        return false;
    }
    public static bool IsNumInListR(Node<int> lst, int num)
    {
        if(lst == null)
        {
            return false;
        }
        if(lst.GetValue() == num)
            return true;
        return IsNumInListR(lst.GetNext(), num);    
    }
    public static int GetMax(Node <int> first)
    {
        Node<int> pos = first;
        int max = pos.GetValue();
        pos = pos.GetNext();
        while(pos != null)
        {
            max = Math.Max(max, pos.GetValue());
            pos = pos.GetNext();
        }
        return max;
    }
    public static int GetMaxR(Node <int> first)
    {
        return GetMaxR(first, first.GetValue());
        
    }
    public static int GetMaxR(Node <int> first, int max)
    {
        if(first == null)
        {
            return max;
        }
        max = Math.Max(first.GetValue(), max);
        return GetMaxR(first.GetNext(), max);

    }
    
    public static Node<int> GetMaxPos(Node<int> first)
    {
        Node<int> pos = first;
        Node<int> maxPos = first;
        while(pos!= null)
        {
            if(maxPos.GetValue() < pos.GetValue())
                maxPos = pos;
            pos = pos.GetNext();
        }
        return maxPos;
    }
    public static void RemoveNode(Node<int> first, Node<int> rnd)
    {
        Node<int> prevNode;
        if(rnd == first)
            return;
        prevNode = first;
        while(prevNode.GetNext() != rnd)
        {
            prevNode = prevNode.GetNext();

        }
        prevNode.SetNext(rnd.GetNext());
    }
    public static void Main()
    {
        Node<int> first = CreateList();
        int num = 10;
        Console.WriteLine(IsNumInListR(first,num));
    }

}