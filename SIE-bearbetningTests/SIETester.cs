using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SIE_bearbetning;

namespace SIE_bearbetningTests
{
    [TestClass]
    public class SIETester
    {
        [TestMethod]
        public void RegexMatchCounter()
        {
            var content = File.ReadAllText(@"C:\Users\marco\Desktop\SIE.txt");
            string pattern = @"#TRANS";
            
            var lineCount = Program.CountLines(content, pattern);
            Assert.AreEqual(498, lineCount);
        }
    }
}
