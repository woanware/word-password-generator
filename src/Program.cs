//https://github.com/schollz/mnemonicode/blob/master/word_list.go

using System.CommandLine;
using System.Security.Cryptography;
using word_password_generator;

// Create some options:
Option numWords = new Option<int>(new string[] { "-w", "--words" },
                                  getDefaultValue: () => 3,
                                  description: "Number of words");

Option delimiter = new Option<string>(new string[] { "-d", "--delimiter" },
                                  getDefaultValue: () => "-",
                                  description: "Delimiter");

var rootCommand = new RootCommand{ numWords, delimiter };
rootCommand.Description = "Generates word based passwords using mnemonicodes";

rootCommand.SetHandler((int numWords, string delimiter) =>
{
    if (numWords == 0)
    {
        Console.WriteLine($"Word parameter must be greater than zero");
        return;
    }

    var min = 1;
    var max = Words.words.Length;

    HashSet<string> words = new();
    while (words.Count < numWords)
    {        
        var randomNumber = RandomNumberGenerator.GetInt32(min, max);
        if (words.Contains(Words.words[randomNumber]) == true)
        {
            continue;
        }

        words.Add(Words.words[randomNumber]);
    }

    Console.WriteLine(string.Empty);
    Console.WriteLine(string.Join(delimiter, words.ToArray()));

}, numWords, delimiter);

// Parse the incoming args and invoke the handler
return rootCommand.Invoke(args);


