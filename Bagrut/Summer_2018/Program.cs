using System;

class Program
{
    public static Node <char> Sod1(Node<char> lst, char ch)
    {
        if(lst == null)
            return null;
        if(lst.GetValue() == ch)
            return lst;
        return Sod1(lst.GetNext(), ch);
    }
    public static bool IsAdjacent(Node<char> lst)
    {
        if(Sod1(lst, 'a') !=null && Sod1(lst,'b')!=null)
            if(Sod1(lst, 'a').GetNext() == Sod1(lst,'b') || Sod1(lst,'b').GetNext() == Sod1(lst, 'a'))
                return true;
        return false;
    }
    public static bool TreeIsLessThanTree(BinNode<int> t1, BinNode<int> t2)
    {
        if (t1 == null)
            return true;
        if (LessThanTree(t2, t1.GetValue()) ==false)
            return false;
        return TreeIsLessThanTree(t1.GetLeft(), t2) && TreeIsLessThanTree(t1.GetRight(), t2);
    }

    public static bool LessThanTree(BinNode<int> t, int x)
    {
        if (t == null)
            return true; // An empty tree is trivially valid

        if (t.GetValue() <= x)
            return false; // If any value is greater than or equal to x, return false

        return LessThanTree(t.GetLeft(), x) && LessThanTree(t.GetRight(), x);
    }

    public static void Main()
    {
        // Constructing t1 (all values < 4)
        BinNode<int> t1 = new BinNode<int>(2);
        t1.SetLeft(new BinNode<int>(1));
        t1.SetRight(new BinNode<int>(3));

        // Constructing t2 (all values > 3)
        BinNode<int> t2 = new BinNode<int>(5);
        t2.SetLeft(new BinNode<int>(4));
        t2.SetRight(new BinNode<int>(6));

        Console.WriteLine(TreeIsLessThanTree(t1, t2)); // Expected output: True

        // Modify t1 to violate the condition
        t1.GetRight().SetValue(5); // Now t1 contains 5, which is not less than all values in t2

        Console.WriteLine(TreeIsLessThanTree(t1, t2)); // Expected output: False
    }

    public static void Code()
    {
        // Constructing the linked list: 'a' -> 'b' -> 'c'
        Node<char> lst = new Node<char>('a');
        lst.SetNext(new Node<char>('b'));
        lst.GetNext().SetNext(new Node<char>('c'));

        Console.WriteLine(IsAdjacent(lst)); // Expected output: True

        // Constructing the linked list: 'a' -> 'c' -> 'b'
        Node<char> lst2 = new Node<char>('a');
        lst2.SetNext(new Node<char>('c'));
        lst2.GetNext().SetNext(new Node<char>('b'));

        Console.WriteLine(IsAdjacent(lst2)); // Expected output: False

        // Constructing the linked list: 'b' -> 'a' -> 'c'
        Node<char> lst3 = new Node<char>('b');
        lst3.SetNext(new Node<char>('a'));
        lst3.GetNext().SetNext(new Node<char>('c'));

        Console.WriteLine(IsAdjacent(lst3)); // Expected output: True
    }

}