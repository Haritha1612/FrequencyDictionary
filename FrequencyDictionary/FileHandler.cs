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
        /// <summary>
        /// Method that validates the file extension type.
        /// </summary>
        /// <param name="filepath">Filepath with extension.</param>
        /// <returns></returns>
        public static bool IsTxtFile(string filepath)
        {
            return Path.GetExtension(filepath).Equals(".txt", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Method to read the contents of the file.
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <param name="encodingType">File encoding type</param>
        /// <returns>returns the content of the file as a string.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string ReadAllText(string filepath, Encoding? encodingType)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"The file at the path {filepath} was not found. Please try again.");
            }

            encodingType ??= Encoding.UTF8; //defaults to UTF-8

            return File.ReadAllText(filepath, encodingType);
        }

        /// <summary>
        /// Method to save the data ot the results to the file.
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <param name="results">Key vlue collection to be saved to the file.</param>
        /// <param name="encodingType"></param>
        /// <exception cref="NoElementsException">Throws exception when the results are empty.</exception>
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
