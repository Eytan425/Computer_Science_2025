using System;
using Node;
class Program
{
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
            Console.Write($"{pos.GetValue()},");
            pos.GetNext();
        }
    }
    public static void Main()
    {
        Node<int> first = CreateList();
        ShowList(first);
    }
}