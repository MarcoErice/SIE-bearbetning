﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SIE_bearbetning;
using System.Linq;

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
        [TestMethod]
        public void CheckThatTRANS_SumEqualsZero()
        {
            //Arrange
            var content = File.ReadAllText(@"C:\Users\marco\Desktop\SIE.txt");
            string pattern = @"#TRANS (\d{4}) {} (-?\d*.\d*)";
            //Act
            var accounts = Program.account(pattern, content);
            var accountsSum = accounts.Sum(entry => entry.Value);
            //Assert
            Assert.AreEqual(0, accountsSum);
        }

    }
}
