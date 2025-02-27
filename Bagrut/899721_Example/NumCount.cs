class NumCount
{
    private int num;
    private int count;

    public NumCount(int num, int count)
    {
        this.num = num;
        this.count = count;
    }
    public int GetNum()
    {
        return this.num;
    }
    public int GetCount()
    {
        return this.count;
    }
    public void SetNum(int num)
    {
        this.num = num;
    }
    public void SetCount(int count)
    {
        this.count = count;
    }

}
class OrderedList
{
    private Node<NumCount> lst;
    public OrderedList()
    {
        lst = null;
    }
    public Node<NumCount> GetNode()
    {
        return lst;
    }
    public void SetNode(Node<NumCount> nodes)
    {
        lst = nodes;
    }

    //Second Question Part 1
    public void InsertNum(int x)
    {
        Node<NumCount> pos = lst;
        NumCount newCount = new NumCount(x,1);
        Node<NumCount> newNode = new Node<NumCount>(newCount);
        //If the list is null
        if(pos == null)
        {
            
            lst = newNode;
            return ;
        }
        //If the x is smaller than the first value
        if(x < pos.GetValue().GetNum())
        {
            newNode.SetNext(pos);
            lst = newNode;
            return ;
        }
        //If x is in the middle 
        while(pos.GetNext()!=null)
        {
            //Brand new number
            if(x > pos.GetValue().GetNum() && x < pos.GetNext().GetValue().GetNum())
            {
                newNode.SetNext(pos.GetNext());
                pos.SetNext(newNode);
                return ;
            }
            //Somewhere in there
            if(x == pos.GetValue().GetNum())
            {
                pos.GetValue().SetCount(pos.GetValue().GetCount()+1);
                return;
                
            }
            //last one and isn't in the list
            
            pos = pos.GetNext();
        }
        if(x > pos.GetValue().GetNum() && pos.GetNext() == null)
        {
            pos.SetNext(newNode);
            
            
        }
    }
    //Second question part 2
    public int ValueN(int n)
    {
        int sum = 0;
        Node<NumCount> pos = lst;
        int num = -1100;
        while(pos.GetValue()!=null)
        {
            int count = pos.GetValue().GetCount();
            sum += count;
            if(sum == n)
            {
                num = pos.GetValue().GetNum();
                break;
            }
            pos = pos.GetNext();
        }
        return num;
    }

}