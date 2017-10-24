using System;
using System.Collections.Generic;
using System.Globalization;
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
            string pattern = @"#TRANS (\d{4}) {} (-?\d*.\d*)";
                        
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

            var TransAccounts = new Dictionary<string, decimal>();
            var streamReader = File.OpenText(theFile);
            while (true)
            {
                var line = streamReader.ReadLine();
                if (line == null)
                    break;
                
                var match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    var accountId = match.Groups[1].Value;
                    var amount = decimal.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

                    if (TransAccounts.ContainsKey(accountId))
                    {
                        TransAccounts[accountId] += amount;
                    }
                    else
                        TransAccounts[accountId] = amount;
                }
                

            }

            Console.WriteLine($"Amount #TRANS accounts in the file are {counter}.");
            Console.WriteLine();
            foreach (var entry in TransAccounts.OrderBy(e => e.Key))
            {
                Console.WriteLine($"{entry.Key} {entry.Value.ToString("F2")}");
            }

            Console.WriteLine();
            Console.WriteLine("Summan av alla konton är:");
            Console.WriteLine(TransAccounts.Sum(e => e.Value));
            Console.ReadLine();
        }
    }
}
