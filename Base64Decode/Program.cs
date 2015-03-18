using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Base64Decode
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToBeDecoded = "jNuqqAcdBVjwn2Zaivpc";
            string s1 = System.Text.Encoding.GetEncoding("UTF-8").GetString(Convert.FromBase64String(stringToBeDecoded)); 
            File.AppendAllText("D:\\result.txt", s1 + Environment.NewLine);
        }
    }
}
