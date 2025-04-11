using System.Data.SqlTypes;

namespace Routers;
public class ReadFile
{
    public const int MaxHeight = 256;
    public const int MaxWidth = 256;

    public Dictionary<int, Dictionary<int, int>> arrayOfDictionaries { get; set; }

    public ReadFile(string filePath)
    {
        if (filePath == null)
        {
            throw new ArgumentNullException(nameof(filePath), "File is null.");
        }
        arrayOfDictionaries = new();
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            if (line.IndexOf(':') == -1)
            {
                throw new InvalidOperationException("The string does not contain the character ':'.");
            }
            int indexOfLine = int.Parse(line.Substring(0, line.IndexOf(':')).Trim()); ;
            int index = line.IndexOf(':') + 1;
            if (index == 0)
            {
                continue;
            }

            string edgeString = "";
            int edge = 0;
            int edgeWeight = 0;
           
            while (index != -1)
            {
                if (line.IndexOf('(', index) == -1)
                {
                    throw new InvalidOperationException("The string does not contain the character '('.");
                }

                edgeString = line.Substring(index + 1, line.IndexOf('(', index) - index - 1).Trim();
                if (int.TryParse(edgeString, out int resultNE))
                {
                    edge = int.Parse(edgeString);
                }
                else
                {
                    throw new InvalidOperationException("The graph number is not a number.");
                }
               
                if (line.IndexOf(')', index) == -1)
                {
                    throw new InvalidOperationException("The string does not contain the character ')'.");
                }
                
                edgeString = line.Substring(line.IndexOf('(', index) + 1,
                    line.IndexOf(')', index) - line.IndexOf('(', index) - 1).Trim();

                if (int.TryParse(edgeString, out int resultEW))
                {
                    edgeWeight = int.Parse(edgeString);
                }
                else
                {
                    throw new InvalidOperationException("Bandwidth is not a number.");
                }

                if (!arrayOfDictionaries.ContainsKey(indexOfLine))
                {
                    arrayOfDictionaries[indexOfLine] = new();
                }

                if (!arrayOfDictionaries.ContainsKey(edge))
                {
                    arrayOfDictionaries[edge] = new();
                }

                arrayOfDictionaries[indexOfLine][edge] = edgeWeight;
                index = line.IndexOf(',', index + 1);
            }
        }
    }

    public void WriteDictionary(Dictionary<int, Dictionary<int, int>> arrayOfDictionaries)
    {
        foreach (var line in arrayOfDictionaries)
        {
            Console.WriteLine($"{line.Key}:");
            foreach (var element in line.Value)
            {
                Console.WriteLine($"  {element.Key} ({element.Value})");
            }
        }
    }
}
