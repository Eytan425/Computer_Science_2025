using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

class Node<T>
{
    private T value;
    private Node<T> next;

    public Node(T value)  
    {
        this.value = value;
        this.next = null;
    }
    public Node(T x, Node<T> next)
    {
        this.value = x;
        this.next = next;
    }
    public T GetValue()
    {
        return this.value;
    }
    public Node<T> GetNext()
    {
        return this.next;
    }
    public void SetValue(T value)
    {
        this.value = value;
    }
    public void SetNext(Node<T> next)
    {
        this.next = next;
    }
    public bool hasNext()
    {
        return this.next != null;
    }
    public override string ToString()
    {
        return this.value.ToString();
    }
    
}
