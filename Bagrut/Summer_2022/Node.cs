using System;
using System.Collections.Generic;

class Node<T>
{
    private T value;
    private Node<T> next;

    public Node(T value)  
    {
        this.value = value;
        this.next = null;
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
    
}
