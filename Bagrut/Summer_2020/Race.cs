using System;
using System.IO.Pipelines;
using System.Runtime.InteropServices.Marshalling;

class Race
{
    private Node<Competitor> lst;

    public Race()
    {
        this.lst = null;
    }
    public void Add(Competitor x)
    {
        Node<Competitor> newComp = new Node<Competitor>(x);
        Node<Competitor> pos = this.lst;
        Node<Competitor> prev = null;
        
        while(pos!=null && pos.GetValue().Before(x))
        {
            prev = pos;
            pos= pos.GetNext();
        }
        if(prev == null)
        {
            newComp.SetNext(lst);
        }
        else
        {
            prev.SetNext(newComp);
            newComp.SetNext(pos);
        }
    }
    public string Rank(int x)
    {
        int counter = 1;
        string name  = "";
        Node<Competitor> pos = this.lst;
        while(pos!=null)
        {
            if(counter == x)
            {
                name = pos.GetValue().GetName();
                break;
            }
            counter++;
            pos = pos.GetNext();
        }
        return name;
    }
}