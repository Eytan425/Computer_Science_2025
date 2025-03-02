using System;

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
    
    public void SetNum(int num1)
    {
        this.num = num1;
    }

    public int GetCount()
    {
        return this.count;
    }

    public void SetCount(int count1)
    {
        this.count = count1;
    }
}