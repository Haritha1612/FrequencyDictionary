using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDictionary
{
    public class WordProcessor
    {
        /// <summary>
        /// Method to process word counting
        /// </summary>
        /// <param name="text">string or the data on which the word count is to be performed.</param>
        /// <returns>returns a collection of words with its frequency in the given text.</returns>
        public static Dictionary<string, int> ProcessWordsFrequency(string text)
        {
            var wordCounter = new ConcurrentDictionary<string, int>(StringComparer.OrdinalIgnoreCase); //considering case insensitive

            //1. split the text by space and new lines.
            var words = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            //2. process each words from the array.
            Parallel.ForEach(words, word =>
            {
                var wordInvariant = word.ToUpperInvariant();
                wordCounter.AddOrUpdate(wordInvariant, 1, (key, oldValue) => oldValue + 1);
            });

            return wordCounter.ToDictionary();
        }
    }
}
