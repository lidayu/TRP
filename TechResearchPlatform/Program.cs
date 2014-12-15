using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TestHashTable;

namespace TechResearchPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable atble = new Hashtable();
            atble.Add("开户信息/币种", "美元");
            atble.Add("kaihuxin.name", "lidayu");
            atble["开户信息/金额"] = 1000;
            Console.WriteLine(atble["开户信息/金额"].ToString());
            Console.WriteLine(atble["开户信息/币种"].ToString());
            Console.WriteLine(atble["kaihuxin.name"].ToString());
            //Program aP = new Program();
            //object aIn=new object();
            //object aOut=new object();
            //aP.TestRef(ref aIn, ref aOut);
            //hashT HasTable = new hashT();
            //HasTable.testHashTableNull();
            Console.ReadKey();

        }

        public void TestRef(ref object input1, ref object output1)
        {
            output1 = null;
        }
    }
}
