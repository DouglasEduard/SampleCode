using System;
using System.Collections.Generic;
using System.Linq;

public class Class1
{
    static void Main(string[] args)
    {      
        Console.WriteLine(Anagrams("cde", "abc"));
    }

    static int Anagrams(string a, string b)
    {
        List<string> aList = new List<string>();
        List<string> bList = new List<string>();

        aList.AddRange(a.Select(c => c.ToString()));
        bList.AddRange(b.Select(c => c.ToString()));

        int iResult = 0;

        for (int i = 0; i < aList.Count(); i++) {
            if (bList.IndexOf(aList[i].ToString()) == -1) {
                iResult++;
            }
            else {
                bList.RemoveAt(bList.IndexOf(aList[i]));
            }
        }

        for (int j = 0; j < bList.Count(); j++) {
            iResult++;
        }

        return iResult;
    }
}
