using System;

class Time
{
    private int hour;
    private int minute;
    private int second;

    public Time(int hour, int minute, int second)
    {
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

    public Time(Time t)
    {
        this.hour = t.hour;
        this.minute = t.minute;
        this.second = t.second;
    }

    public int getHour()
    {
        return this.hour;
    }

    public void setHour(int hour)
    {
        this.hour = hour;
    }

    public int getMinute()
    {
        return this.minute;
    }

    public void setMinute(int minute)
    {
        this.minute = minute;
    }

    public int getSecond()
    {
        return this.second;
    }

    public void setSecond(int second)
    {
        this.second = second;
    }

    public void setTime(int h, int m, int s)
    {
        this.hour = h;
        this.minute = m;
        this.second = s;
    }
    public double convertToSeconds()
    {
        return this.hour * 3600 + this.minute * 60 + this.second;
    }
    public Time DifferenceHour(Time t)
    {
        int diffHours = this.hour - t.hour;
        int diffMinutes = this.minute - t.minute;
        int diffSeconds = this.second - t.second;

        if (diffSeconds < 0)
        {
            diffSeconds += 60;
            diffMinutes--;
        }

        if (diffMinutes < 0)
        {
            diffMinutes += 60;
            diffHours--;
        }

        if (diffHours < 0)
        {
            diffHours += 24; // Assuming a 24-hour format
        }

        return new Time(diffHours, diffMinutes, diffSeconds);
    }

    public void showTime()
    {
        Console.WriteLine("{0}:{1}:{2}", hour, minute, second);
    }
}