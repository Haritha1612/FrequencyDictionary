using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrequencyDictionary;

namespace FrequencyDictionary
{
    public class FileHandler
    {
        public static bool IsTxtFile(string filepath)
        {
            return Path.GetExtension(filepath).Equals(".txt", StringComparison.OrdinalIgnoreCase);
        }

        public static string ReadAllText(string filepath, Encoding? encodingType)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"The file at the path {filepath} was not found. Please try again.");
            }

            encodingType ??= Encoding.UTF8; //defaults to UTF-8

            return File.ReadAllText(filepath, encodingType);
        }

        public static void WriteResults(string filepath, IDictionary<string, int>? results, Encoding? encodingType)
        {
            if (results == null || results?.Count == 0)
            {
                throw new NoElementsException("The collection is empty.");
            }

            encodingType ??= Encoding.UTF8; //defaults to UTF-8

            if (File.Exists(filepath))
                File.Delete(filepath);

            results?.ToList().ForEach(item => File.AppendAllText(filepath, $"{item.Key},{item.Value}\n", encodingType));
        }
    }
}
