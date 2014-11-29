using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TestHashTable
{
    public class hashT
    {
        public void testHashTableNull()
        {
            Hashtable ht = new Hashtable();
            ht.Add("lidayu", "lidayu@abchina.com");
            Console.WriteLine(ht["lidayu"]);
            try
            {
                Console.WriteLine(ht[null]);
            }catch(Exception e)
            {
                Console.WriteLine("Catch Exception when executing ht[null], excepiton info:"+e.ToString()+e.StackTrace);
            }


        }
    }
}
