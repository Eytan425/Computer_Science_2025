using System;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Net;
using System.Threading.Channels;

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
        while(pos.HasNext())
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
    public static Node<int> Combine(Node<int> lst1, Node<int> lst2)//Ascending order
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
    public static int T37(Node<int> list1, Node<int> list2)
    {
        int min1 = int.MaxValue;
        int min2 = int.MaxValue;
        Node<int> pos1 = list1;
        Node<int> pos2 = list2;
        while(pos1.HasNext() && pos2.HasNext())
        {
            int num1 = pos1.GetValue();
            int num2 = pos2.GetValue();
            if(IsNumInList(list2, num1) && num1 < min1)
            {
                return num1;
            } 
            if(IsNumInList(list1, num2) && num2 < min2)
            {
                return num2;
            } 
            pos1 = pos1.GetNext();
            pos2 = pos2.GetNext();
        }
        
        return -999;    

    }
    public static void T38(Node<int> list1, Node<int> list2)
    {
        Node<int> pos1 = list1;
        Node<int> pos2 = list2;
        Node<int> chain = Combine(list1, list2);
        int count = 0;
        while(chain.HasNext())
        {
            int num = chain.GetValue();
            if(HowMany(chain, num) >=2)
                Console.Write($"{num} ");
            chain = chain.GetNext();
        }
    }
    public static int T43(Node<int> first, Node<int> node)
    {
        return T43(node, null, 0);
    }

    public static int T43(Node<int> current, Node<int> end, int counter)
    {
        if (current == null || current == end)
            return counter;

        if (current.GetValue() % 2 == 0)
            counter++;
        current = current.GetNext();
        return T43(current, end, counter);
    }
    public static void T44(Node<int> first)
    {
        T44(first, null, 1);
    }
    public static void T44(Node<int> first, Node<int> last, int counter)
    {
        if (first == null || first == last)
            return ;
        if(counter%2 == 0)
            Console.Write($"{first.GetValue()} ");
        T44(first.GetNext(), last, counter+1);
    }
    public static int T45(Node<int> first, Node<int> p, Node<int> q)
    {
        return T45(first,p,q,0);
    }
    public static int T45(Node<int> first, Node<int> p, Node<int> q, int sum)//Doesn't include q
    {
        if(p == null || p == q)
            return sum;
        sum += p.GetValue();
        return T45(first, p.GetNext(), q, sum);
    }

    

    public static int T45PT1(Node<int> first, Node<int> p, Node<int> q, int sum)//Includes q
    {
        if (p == null)
            return sum;
        sum += p.GetValue();
        if (p == q)
            return sum;
        return T45(first, p.GetNext(), q, sum);
    }
    public static int T46(Node<int> first, Node<int> second)
    {
        return T46(first, second, 0, 0);
    }
    public static int T46(Node<int> first, Node<int> second, int sizeFirst, int sizeSecond)
    {
        if(first == null && second == null)
            return Math.Abs(sizeFirst - sizeSecond);
        if(first!=null)
            sizeFirst++;
        if(second!=null)
            sizeSecond++;
        return T46(first?.GetNext(), second?.GetNext(), sizeFirst, sizeSecond);//? is to return null and not nullReference
    }

    public static Node<int> WhatA(Node<int> lst, int x) {
        if (lst == null) {
            return null;
        }
        Node<int> temp = WhatA(lst.GetNext(), x);
        if (lst.GetValue() == x) {
            return temp;
        }
        lst.SetNext(temp);
        return lst;
    }
    public static Node<int> Tar2(Node<int> first)
    {
        if(first == null || first.GetNext() == null)
            return first;
        Node<int> pos = first;
        while(pos!= null && pos.HasNext())
        {
            int num1 = pos.GetValue();
            pos = pos.GetNext();
            int num2 = pos.GetValue();
            int sum = num1+num2;
            Node<int> newNode = new Node<int>(sum);
            Node<int> nextNode = pos.GetNext();


            pos.SetNext(newNode);
            newNode.SetNext(nextNode);

            pos = nextNode;
        }
        return first;
    }
    public static int Tar1(int n)
{
    if (n <= 3)
        return 1;
    return Tar1(n, 1, 1, 1, 1, 1);
}

    public static int Tar1(int n, int a, int b, int c, int counter, int num)
    {
        if (counter > n)
            return num;
        if (counter <= 3)
        {
            num = 1;
        }
        else
        {
            num = a + b + c;
            a = b;
            b = c;
            c = num;
        }
        return Tar1(n, a, b, c, counter + 1, num);
    }
    public static bool IsEven(Node<int> nodes)
    {
        Node<int> pos = nodes;
        int remainder = 0;
        while(pos != null)
        {
            remainder = (remainder + 1) % 2;
            pos = pos.GetNext();
        }
        return remainder == 0;
    }
    //Get the last letter of the first half and the first letter of the last half
    public static Node<char> Question(Node<char> nodes)
    {
        Node<char> firstOut;
        Node<char> pos1 = nodes;
        Node<char> pos2 = nodes;
        while(pos2.GetNext().GetNext() != null)
        {
            pos1 = pos1.GetNext();
            pos2 = pos2.GetNext().GetNext();
        }
        firstOut = new Node<char>(pos1.GetValue());
        firstOut.SetNext(new Node<char>(pos1.GetNext().GetValue()));
        return firstOut;
        
    }
    public static Node<T> GetPrev<T>(Node<T> first, Node<T> pos)
    {
        if(pos == first)
            return null;
        Node<T> pos1 = first;
        while(pos1 != null && pos1.GetNext()!=pos)
            pos1 = pos.GetNext();
        return pos1;
    }
    public static Node<char> QuestionAnotherWay(Node<char> nodes)
    {
        Node<char> firstOut;
        Node<char> pos1 = nodes;
        Node<char> pos2 = nodes;
        while(pos1.GetNext()!=null)
            pos1 = pos1.GetNext();
        while(pos2.GetNext()!=pos1)
        {
            pos2 = pos2.GetNext();
            pos1 = GetPrev(nodes, pos1);
        }
        firstOut = new Node<char>(pos1.GetValue());
        firstOut.SetNext(new Node<char>(pos2.GetValue()));
        return firstOut;
    }
    // public static void Main()
    // {
    //     // Create linked list: 1 -> 4 -> 6 -> 7 -> 10
    //     Node<int> first = new Node<int>(1);
    //     Node<int> second = new Node<int>(4);
    //     Node<int> third = new Node<int>(6);
    //     Node<int> fourth = new Node<int>(7);
    //     Node<int> fifth = new Node<int>(10);

    //     first.SetNext(second); 
    //     second.SetNext(third);
    //     third.SetNext(fourth);
    //     fourth.SetNext(fifth);

    //     // // Test starting from `second` (4) to the end of the list
    //     // int count = T43(first, second);

    //     // Console.WriteLine("Count of multiples of 2 from the given node: " + count);
    //     // // Expected output: 3 (4, 6, 10 are multiples of 2)
    //     Node<int> nodes = CreateList();
    //     T44(nodes);
    // }

    public static void Main()
    {
        // Node<int> first = CreateList();
        // ShowList(Tar2(first));

        Console.WriteLine(Tar1(6));
    }

}