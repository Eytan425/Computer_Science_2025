using System;
using System.IO.Pipelines;
using System.Security.Cryptography.X509Certificates;

class OrderedList
{
    private Node<NumCount> lst;

    public OrderedList()
    {
        this.lst = null;
    }

    public void InsertNum(int x)
    {
        Node<NumCount> addNode = new Node<NumCount>(new NumCount(x,1));
        if(lst == null) //Empty
        {
            lst = addNode;
            return;
        }
        
        Node<NumCount> pos = lst;
        while(pos.GetNext()!=null)
        {
            if(pos.GetValue().GetNum() == x) // He is in the list
            {
                pos.GetValue().SetCount(pos.GetValue().GetCount()+1);
                return;
               
            }
            else if(pos.GetValue().GetNum() < x && x < pos.GetNext().GetValue().GetNum())//Isn't in the list
            {
                addNode.SetNext(pos.GetNext());
                pos.SetNext(addNode);
                return ;
               
            }
            
            pos = pos.GetNext();
            
        }
        if(pos.GetValue().GetNum() == x)
        {
            pos.GetValue().SetCount(pos.GetValue().GetCount()+1);
            return ;
        }
        else
        {
            pos.SetNext(addNode);
            return ;
        }
    }
    public int ValueN(int n)
    {
        int count = 0;
        Node<NumCount> pos = lst;
        int num = 0;
        while(pos!=null)
        {
            count+=pos.GetValue().GetCount();
            if(count >= n)
            {
                num = pos.GetValue().GetNum();
                break;
            }
        }
        return num;
    }

    public void PrintList()
    {
        Node<NumCount> pos = lst;
        while (pos != null)
        {
            Console.WriteLine($"Number: {pos.GetValue().GetNum()}, Count: {pos.GetValue().GetCount()}");
            pos = pos.GetNext();
        }
    }

    
}