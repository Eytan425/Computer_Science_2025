using System;
using System.Globalization;

class Program
{
    public static int GetListSize<T>(Node<T> head)
    {
        int size = 0;
        Node<T> current = head;
        while (current != null)
        {
            size++;
            current = current.GetNext();
        }
        return size;
    }
    
    //Question 4
    public static bool IsIncluded(Node<int> lst1, Node<Range> lst2)
    {
        Node<int> pos1 = lst1;
        Node<Range> pos2 = lst2;
        int counter = 0;
        int size = GetListSize(lst1);
        while (pos1 != null && pos2 != null)
        {
            int num = pos1.GetValue();
            if (pos2.GetValue().GetLow() <= num && pos2.GetValue().GetHigh() >= num)
            {
                counter++;
                pos1 = pos1.GetNext();
            }
            else
            {
                pos2 = pos2.GetNext();
            }
        }
        return counter == size;
    }

    //Question 7
    public static bool isPrime(int num)
    {
        if (num <= 1)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static string EraseFirst(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        return str.Substring(1);
    }

    public static bool WordFromRoot(BinNode<char> tree, string str)
    {
        if (tree == null)
            return false;
        if (str == "")
            return true;
        if(tree.GetValue() != str[0])
            return false;
        if (tree.GetValue() == str[0])
            str = EraseFirst(str);
        return WordFromRoot(tree.GetLeft(), str) || WordFromRoot(tree.GetRight(), str);
    }

    public static void Main()
    {
        // Create test data for lst1
        Node<int> lst1 = new Node<int>(5);
        lst1.SetNext(new Node<int>(10));
        lst1.GetNext().SetNext(new Node<int>(15));

        // Create test data for lst2
        Node<Range> lst2 = new Node<Range>(new Range(0, 9));
        lst2.SetNext(new Node<Range>(new Range(10, 30)));

        // Run the IsIncluded method
        bool result = IsIncluded(lst1, lst2);

        // Print the result
        Console.WriteLine("IsIncluded result: " + result);

        // Create test data for WordFromRoot
        BinNode<char> root = new BinNode<char>('a');
        root.SetLeft(new BinNode<char>('b'));
        root.SetRight(new BinNode<char>('c'));
        root.GetLeft().SetLeft(new BinNode<char>('d'));
        root.GetLeft().SetRight(new BinNode<char>('e'));
        root.GetRight().SetLeft(new BinNode<char>('f'));
        root.GetRight().SetRight(new BinNode<char>('g'));

        // Test WordFromRoot method
        string testString = "ab";
        bool wordResult = WordFromRoot(root, testString);
        Console.WriteLine("WordFromRoot result: " + wordResult);
    }
}