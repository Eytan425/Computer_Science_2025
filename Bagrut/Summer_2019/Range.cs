using System;

class Range
{
    private int low;
    private int high;
    //high > low

    public Range(int low, int high)
    {
        this.low = low;
        this.high = high;
    }
    public int GetLow()
    {
        return this.low;
    }
    public void SetLow(int low)
    {
        this.low = low;
    }
    public int GetHigh()
    {
        return this.high;
    }
    public void SetHigh(int high)
    {
        this.high = high;
    }
}