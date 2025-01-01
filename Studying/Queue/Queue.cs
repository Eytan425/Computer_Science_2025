using System;

class Queue<T>
{
    private Node<T> first;
    private Node<T> last;

    public Queue()
    {
        this.first = null;
        this.last = null;
    }
    public bool IsEmpty()
    {
        return this.last==null;
    }
    public void Insert(T x)
    {
        Node<T> nd  = new Node<T>(x);
        if(this.first == null)
            this.first = nd;
        else
            this.last.SetNext(nd);
        this.last = nd;    
    }
    public T Remove()
    {
        T x = this.first.GetValue();
        this.first = this.first.GetNext();
        if(this.first == null)
            this.last = null;
        return x;
    }
    public T Head()
    {
        return first.GetValue();
    }
    //My function
    public override string ToString()
    {
        if(this.IsEmpty()) return "[]";
        Queue<T> temp = new Queue<T>();
        while(!this.IsEmpty())
        {
            temp.Insert(this.Remove());
        }
        string s = "[";
        while(!temp.IsEmpty())
        {
            s = s +temp.Head() + ',';
            this.Insert(temp.Remove());
        }
        s = s.Substring(0, s.Length-1) + "]";
        return s;
    }
}