using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class LeftRotation
{
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);

        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp, System.Int32.Parse);

        for (int i = 0; i < n && k <= n; i++)
        {
            a[((i - (k)) < 0) ? a_temp.Length + (i - (k)) : (i - (k))] = Int32.Parse(a_temp[i]);
        }

        Console.WriteLine(String.Join(" ", a));
    }
}

