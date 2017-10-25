using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIE_bearbetning
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej, var god ange sökvägen till en SIE-fil");
            var theFile = Console.ReadLine();
            string pattern = @"#TRANS (\d{4}) {} (-?\d*.\d*)";

            
            var content = File.ReadAllText(theFile);
            int counter = CountLines(content, pattern);
            
            var accounts = account(pattern,content);

            Console.WriteLine($"Antal #TRANS som finns i filen är: {counter}");

            foreach (var entry in accounts.OrderBy(e => e.Key))
            {
                Console.WriteLine($"{entry.Key} {entry.Value.ToString("F2")}");
            }
            Console.WriteLine();
            Console.WriteLine("Summan av alla konton är:");
            Console.WriteLine(accounts.Sum(entry => entry.Value));
            Console.ReadLine();
        }

        public static Dictionary<string, decimal> account(string pattern, string content)
        {
            StringReader reader;
            reader = new StringReader(content);

            var accounts = new Dictionary<string, decimal>();

            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;

                var match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    var accountId = match.Groups[1].Value;
                    var amount = decimal.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

                    if (accounts.ContainsKey(accountId))
                    {
                        accounts[accountId] += amount;
                    }
                    else
                        accounts[accountId] = amount;
                }

            }return accounts;
        }

        public static int CountLines(string content, string pattern)
        {
            var counter = 0;
            
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
            return counter;
        }
    }
}
