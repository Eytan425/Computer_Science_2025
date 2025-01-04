using System;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Net;

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
            pos = pos.GetNext();
        }
    }
    public static bool IsNumInList(Node<int> first, int num)
    {
        Node<int> pos = first;
        while(pos!=null)
        {
            if(pos.GetNext().GetValue() == num)
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

    public static int HowMany<T>(Node<T> first, T value)
    {
        Node<T> pos = first;
        int counter = 0;
        while(pos != null)
        {
            if(pos.GetValue().Equals(value))
                counter++;
            pos = pos.GetNext();
        }
        return counter;
    }
    public static Node<T> LastNodeWithValue<T>(Node<T> first, T value)
    {
        Node<T> pos = first;
        Node<T> lastNode = null;
        while(pos!=null)
        {
            if(pos.GetValue().Equals(value))
                lastNode = pos;
            pos = pos.GetNext();
        }
        return lastNode;
    }
    //Start of the revision
    public static int T2(Node<int> first, int num)
    {
        int counter = 0;
        Node<int> pos = first;
        if(pos == null)
            return 0;
        while(pos != null)
        {
            if(pos.GetValue() == num && pos.GetNext().GetValue() != num)
                counter++;
            pos = pos.GetNext();
        }
        return counter;
    }
    public static int GetSize(Node<int> first)
    {
        int counter = 0;
        Node<int> pos = first;
        while(pos != null)
        {
            counter++;
            pos = pos.GetNext();
        }
        return counter;
    }
    public static void T11(Node<int> first, int num)
    {
        if (first == null)
            return;

        
        while (first != null && first.GetValue() == num)
        {
            first = first.GetNext();
        }

        Node<int> pos = first;
        while (pos != null && pos.GetNext() != null)
        {
            Node<int> place = pos.GetNext();
            if (place.GetValue() == num)
            {
                pos.SetNext(place.GetNext());
            }
            else
            {
                pos = pos.GetNext();
            }
        }
    }
    public static bool Exists<T>(Node<T> first, T num)
    {
        Node<T> pos = first;
        bool exists = false;

        while(pos != null)
        {
            if(pos.GetValue().Equals(num))
                exists = true;
            pos = pos.GetNext();
        }
        return exists;
    }
    public static Node<int> T12(Node<int> first)
    {
        if (first == null)
            return null;

        Node<int> pos = first;
        Node<int> newNode = new Node<int>(pos.GetValue());
        Node<int> newPos = newNode;

        while (pos != null)
        {
            if (!Exists(newNode, pos.GetValue()))
            {
                newPos.SetNext(new Node<int>(pos.GetValue()));
                newPos = newPos.GetNext();
            }
            pos = pos.GetNext();
        }
        return newNode;
    }


    public static Node<int> T13(Node<int> first)
    {
        Node<int> pos = first;
        Node<int> firstNode = null;
        Node<int> secondNode = null;
        if(first == null)
            return null;
        int size = GetSize(first);
        int counter = 0;
        if(size % 2 == 0)
        {
            while(pos != null)
            {
                counter++;
                if(counter == (size / 2) - 1)
                {
                    firstNode = pos;
                }
                if(counter == (size / 2) + 1)
                {
                    secondNode = pos;
                }
                pos = pos.GetNext();
            }
            if(firstNode != null&& secondNode != null)
                firstNode.SetNext(secondNode.GetNext());
        }
        else if(size %2 == 1)
        {
            first = first.GetNext();
            while(pos != null && pos.GetNext() != null)
            {
                counter++;
                if(counter == size - 1)
                {
                    secondNode = pos;
                    if(secondNode != null)
                        secondNode.SetNext(null);
                }
                pos = pos.GetNext();
            }
        }
        
        return first;
    }
    public static Node<int> T34(Node<int> first, Node<int> second)
    {
        if (first == null) return second;
        if (second == null) return first;

        Node<int> mergedHead = null;
        Node<int> mergedTail = null;

        if (first.GetValue() < second.GetValue())
        {
            mergedHead = first;
            first = first.GetNext();
        }
        else
        {
            mergedHead = second;
            second = second.GetNext();
        }

        mergedTail = mergedHead;

        while (first != null && second != null)
        {
            if (first.GetValue() < second.GetValue())
            {
                mergedTail.SetNext(first);
                first = first.GetNext();
            }
            else
            {
                mergedTail.SetNext(second);
                second = second.GetNext();
            }
            mergedTail = mergedTail.GetNext();
        }

        if (first != null)
        {
            mergedTail.SetNext(first);
        }
        else
        {
            mergedTail.SetNext(second);
        }

        return mergedHead;
    }
    public static Node<int> Even(Node<int> chain)//Adds all the even values to a new list
    {
        Node<int> newNode = null;
        while(chain!=null)
        {
            if(chain.GetValue()%2 == 0)
            {
                if(newNode != null)
                {
                    newNode.SetNext(chain);
                }
                else
                {
                    newNode = chain;
                }
            }
            chain = chain.GetNext();
        }
        return newNode;
    }
    public static Node<int> RemoveNodes(Node<int> first, int num)
    {
        
        Node<int> prev = null;
        while(first.GetValue() == num && first.GetNext() != null)
        {
            first = first.GetNext();
        }
        Node<int> pos = first;
        while(pos.GetNext()!=null)
        {
           if(pos.GetNext().GetValue() == num  )
           {
              prev = pos;
              prev.SetNext(pos.GetNext().GetNext());
           }
           pos = pos.GetNext();
        }
        return first;
    }
    public static Node<int> MultiplyDuplicates(Node<int> first) //{4,4,4,3,9,9} => {12,3,18}
    {
        int counter = 0;
        Node<int> pos = first;
        Node<int> lastNode = null;
        while(pos != null)
        {
            int value = pos.GetValue();
            counter = HowMany(pos, value);
            pos.SetValue(value * counter);
            lastNode = LastNodeWithValue(first, value);
            pos.SetNext(lastNode.GetNext());
            pos = pos.GetNext();
        }
        return first;
    }
    public static Node<char> RemoveWhatIsntInTheSecond(Node<char> n1, Node<char> n2)
    {
       while(!Exists(n2,n1.GetValue()))
       {
            n1 = n1.GetNext();
       }
       Node<char> pos = n1;
       while(pos.HasNext())
       {
           if(!Exists(n2, pos.GetNext().GetValue()))
           {
               pos.SetNext(pos.GetNext().GetNext());
           }
       }
       return n1;
    }
    public static bool IsUpOrder(Node<int> first)//Checks if the list is in ascending order - works with int or char
    {
        while(first.HasNext())
        {
            if(first.GetValue() >= first.GetNext().GetValue())
                return false;
            first = first.GetNext();
        }
        return true;
    }
    public static bool IsUpOrderString(Node<string> first)//Checks if the list is in ascending order - works with int or char
    {
        while(first.HasNext())
        {
            if(first.GetValue().CompareTo(first.GetNext().GetValue()) >= 0)
                return false;
            first = first.GetNext();
        }
        return true;
    }
    //Combine 2 lists
    public static Node<int> Combine(Node<int> lst1, Node<int> lst2)
    {
        Node<int> chain = null;
        Node<int> last = null;
        if(lst1.GetValue() < lst2.GetValue())
        {
            chain = lst1;
            lst1 = lst1.GetNext();
        }
        else
        {
            chain = lst2;
            lst2 = lst2.GetNext();
        }
        last = chain;//last is the last node of the chain
        while(lst1 != null && lst2 != null)
        {
            if(lst1.GetValue() < lst2.GetValue())
            {
                last.SetNext(lst1);
                lst1 = lst1.GetNext();
            }
            else
            {
                last.SetNext(lst2);
                lst2 = lst2.GetNext();
            }
            last = last.GetNext();
        }
        while(lst1 != null)
        {
            last.SetNext(lst1);
            lst1 = lst1.GetNext();
            last = last.GetNext();
        }
        while(lst2 != null)
        {
            last.SetNext(lst2);
            lst2 = lst2.GetNext();
            last = last.GetNext();
        }
        return chain;
    }

    public static void Main()
    {
        Node<int> first = CreateList();
        string test = "test";
        test.CompareTo("test");
        // Node<int> second = CreateList();
        // Node<int> third = T34(first, second)
        Node<int> third = MultiplyDuplicates(first);
        ShowList(third);
    }

}