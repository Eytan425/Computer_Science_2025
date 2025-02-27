using System;
using System.Collections.Generic;

public class BiList
{
    private List<int> lst1;
    private List<int> lst2;

    public BiList()
    {
        lst1 = new List<int>();
        lst2 = new List<int>();
    }

    public void AddNum(int num, int codeList)
    {
        if (codeList == 1)
        {
            lst1.Add(num);
        }
        else if (codeList == 2)
        {
            lst2.Add(num);
        }
        else
        {
            throw new ArgumentException("Invalid codeList value. Use 1 or 2.");
        }
    }
    
    
}