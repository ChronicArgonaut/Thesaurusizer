using System;
using System.Collections.Generic;

public class WordRandomizer
{
    static Random rnd = new Random();
    public WordRandomizer(string wordin,List<string> listin,out string wordout)
    {
        wordout = wordin;
        int r = rnd.Next(listin.Count);
        Random rnd1 = new Random();

        try
        {
            if (wordin.Length > 2)
            {
                if (rnd1.Next(0, 2) == 0)
                {
                    wordout = (string)listin[r];
                }
                else { }
            }
            else { }
        }
        catch (ArgumentOutOfRangeException)
        {
        }

    }
}
