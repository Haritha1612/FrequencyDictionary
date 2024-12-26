using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrequencyDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDictionary.Tests
{
    [TestClass()]
    public class FileHandlerTests
    {
        [TestMethod()]
        public void IsTxtFileTest()
        {
            string fileName = "textFile.txt";
            Assert.IsTrue(FileHandler.IsTxtFile(fileName));

            fileName = "InvalidFile.pdf";
            Assert.IsFalse(FileHandler.IsTxtFile(fileName));
        }

        [TestMethod()]
        public void ReadAllTextTest()
        {
            string fileName = "InvalidFile.txt";

            Assert.ThrowsException<FileNotFoundException>(() => FileHandler.ReadAllText(fileName, null));
        }

        [TestMethod()]
        public void WriteResultsTest()
        {
            string fileName = "InvalidFile.txt";

            Assert.ThrowsException<NoElementsException>(() => FileHandler.WriteResults(fileName, null, null));
        }
    }
}