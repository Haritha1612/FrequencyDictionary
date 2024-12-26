// See https://aka.ms/new-console-template for more information
using System.Text;
using FrequencyDictionary;

Console.WriteLine("Word frequency application" + Environment.NewLine);
try
{
    if (args.Length != 2)
    {
        Console.WriteLine("Incorrect number of parameters. Expected 2.\nThe first parameter must be the name of input file and the second parameter must be the name of the file for the results .");
    }
    else
    {
        string inputFile = args[0];
        string outputFile = args[1];

        if (!FileHandler.IsTxtFile(inputFile) ||
            !FileHandler.IsTxtFile(outputFile))
        {
            throw new ArgumentException("The arguments passed are invalid. Please provide the files in .txt only.");
        }

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var enc1252 = Encoding.GetEncoding("windows-1252");
        // Read the input file contents
        string inputText = FileHandler.ReadAllText(inputFile, enc1252);

        Console.WriteLine("Starting the word processing...");
        // process words and its frequency.
        var wordCounts = WordProcessor.ProcessWordsFrequency(inputText);

        // Sort the word count by frequency in the descending order
        var results = wordCounts.OrderByDescending(kv => kv.Value).ToDictionary<string, int>();

        // Write the results to the output file
        FileHandler.WriteResults(outputFile, results, enc1252);

        Console.WriteLine($"The process completed successfully. The results are saved here - {outputFile}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    Console.WriteLine("\nPress any key to exit...");
    Console.ReadKey();
}
