Application Description: 

To Create a console application to perform word count for a given text file.

Application Overview:

1. Input File - this is a text file (*.txt) containing words separated by spaces and/or new line characters. the content of this source file is expected to be encoded in Windows-1252 format.

2. Word Processing - Once the data is identified, the process starts interpretting the occurrence of each word identified and is stored in a dictionary as a key value pair. Word followed by its occurrence count.

3. Sorting - Once the counting of words is completed, we then sort the collection in the descending order.

4. OutputFile - the results are then saved to the given output file (*.txt) in the encoded windows 1252 format.

5. Error Handling - to ensure the arguments provided are valid and that the file and the file path is valid. to capture errors.


Key Components:

1. WordProcessor - this components handles the logic of identifying Words and counting their occurrences. 
				   The method ProcessWordsFrequency process the given contents to the array of words, separated by a space or a new line character and then perofrms counting on each word identified.
				   The method uses Prallel.ForEach to process words. When using large file contents, using Parallel.Foreach manages tasks, threads and handles the complexity of scheduling and managing tassk. hence also improves the performance.
				   And by using Concurrent Dictionary, there is no need for the manual lock mechanism while updating the word count.

2. FileHandler - this component handles the logic of simple IO operations.
				 The IsTxtFile method verifies whether the input file is in txt format.
				 The ReadAllText method reads the contents of teh text file for the given encoding format, which also defaults to UTF-8 if no encoding is specified. This metod throws FileNotFound exception if the filepath is invalid or no longer exists.
				 The WriteResults method saves the contents of the dictionary containing words and their frequencies or occurrences. The data is saved as per the given encoding format. The method throws NoElementsException if the collection is empty.
				 
3. Program.cs - this the entry of the application where it reads the parameters passed with the application, validates the arguments, performs word count and controls the execution.

4. Unit tests - This component includes arious unit tests written for the above key components/logic being performed in the application. this way it helps us to verify if there are any erros/ code breaks when the application is modified or is being provided with a different set of data.


Improvements

This application can further be extended to perform word count of an array of files. Can be extended to further include various encoding formats, file formats, more controlled asnych processing of the data.
