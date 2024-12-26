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
    public class WordProcessorTests
    {
        [TestMethod()]
        public void ProcessWordsFrequencyTest()
        {
            var text = "This is a sample word frequency application called Word Frequency Dictionary.";
            var result = WordProcessor.ProcessWordsFrequency(text);

            Assert.AreEqual(1, result["THIS"]);
            Assert.AreEqual(2, result["FREQUENCY"]);
            Assert.AreEqual(2, result["WORD"]);
        }
    }
}