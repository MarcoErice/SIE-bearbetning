using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bokföring
{
    class Bokforing
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please add a path to the SIE-file:");
            var theFile = Console.ReadLine();  //  C:\Users\marco\Desktop\SIE.txt
            string pattern = @"(#TRANS)";

            var counter = 0;
            var content = File.ReadAllText(theFile);
            var reader = new StringReader(content);
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                        break;
                    if (Regex.Match(line, pattern).Success)
                    {
                        counter++;
                    }
                }
            

            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
