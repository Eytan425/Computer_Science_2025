using System;

class Range
{
    private int low;
    private int high;

    public Range(int low, int high)
    {
        this.low = low;
        this.high = high;
    }
    public int GetHigh()
    {
        return high;
    }
    public int GetLow()
    {
        return low;
    }
    
}