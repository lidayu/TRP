using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TechResearchPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add("lidayu", "lidayu@abchina.com");
            Console.WriteLine(ht["lidayu"]);
            Console.ReadKey();

        }
    }
}
