using System;

class Job
{
    private int code;
    private int timeForWork;

    public Job(int code, int timeForWork)
    {
        this.code = code;
        this.timeForWork = timeForWork;
    }

    public int getCode()
    {
        return this.code;
    }

    public void setCode(int code)
    {
        this.code = code;
    }

    public int getTimeForWork()
    {
        return this.timeForWork;
    }

    public void setTimeForWork(int timeForWork)
    {
        this.timeForWork = timeForWork;
    }
    
}