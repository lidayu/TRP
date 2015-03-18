using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using System.Text;

namespace XElementTester
{
    class Program
    {
        static void Main(string[] args)
        {

            string xmlText = @"<ap><person>&lt;name&gt;doylee&lt;/name&gt;<sex>male</sex></person><work><salary>1000000</salary><name>CEO</name></work></ap>";
            string xmlText2 = @"<ap><name>lidayu</name></ap>";

            XElement el = XElement.Parse(xmlText);
            Console.WriteLine(el);
            Console.ReadKey();
        }
    }
}
