using System;

class Competitor
{
    private int minutes;
    private int seconds;
    private string name;

    public Competitor(int minutes, int seconds, string name)
    {
        this.minutes = minutes;
        this.seconds = seconds;
        this.name = name;
    }
    public int GetMinutes()
    {
        return this.minutes;
    }
    public int GetSeconds()
    {
        return this.seconds;
    }
    public string GetName()
    {
        return this.name;
    }
    public bool Before(Competitor other)
    {
        int otherTime = (60*other.GetMinutes()) + other.GetSeconds();
        int thisTime = (this.minutes*60) + this.seconds;
        return otherTime> thisTime;
    }
}