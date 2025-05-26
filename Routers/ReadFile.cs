using System.Data.SqlTypes;

namespace Routers;

/// <summary>
/// Reads file.
/// </summary>
public class ReadFile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReadFile"/> class.
    /// </summary>
    /// <param name="filePath"> FilePath. </param>
    /// <exception cref="ArgumentNullException"> Returns exception when argument is null. </exception>
    /// <exception cref="InvalidOperationException"> Returns exception.</exception>
    public ReadFile(string filePath)
    {
        if (filePath == null)
        {
            throw new ArgumentNullException(nameof(filePath), "File is null.");
        }

        this.Dictionaries = new ();
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            if (line.IndexOf(':') == -1)
            {
                throw new InvalidOperationException("The string does not contain the character ':'.");
            }

            int indexOfLine = int.Parse(line.Substring(0, line.IndexOf(':')).Trim());
            int index = line.IndexOf(':') + 1;
            if (index == 0)
            {
                continue;
            }

            string edgeString = string.Empty;
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

                if (!this.Dictionaries.ContainsKey(indexOfLine))
                {
                    this.Dictionaries[indexOfLine] = new ();
                }

                if (!this.Dictionaries.ContainsKey(edge))
                {
                    this.Dictionaries[edge] = new ();
                }

                this.Dictionaries[indexOfLine][edge] = edgeWeight;
                index = line.IndexOf(',', index + 1);
            }
        }
    }

    /// <summary>
    /// Gets dictionaries.
    /// </summary>
    public Dictionary<int, Dictionary<int, int>> ArrayOfDictionaries => this.Dictionaries;

    private Dictionary<int, Dictionary<int, int>> Dictionaries { get; set; }

    /// <summary>
    /// Writes dictionary in console.
    /// </summary>
    /// <param name="arrayOfDictionaries"> Dictionaries. </param>
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
