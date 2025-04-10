namespace Routers;
public class ReadFile
{
    public const int MaxHeight = 256;
    public const int MaxWidth = 256;

    public Dictionary<int, Dictionary<int, int>> arrayOfDictionaries { get; set; }

    public ReadFile(string filePath)
    {
        arrayOfDictionaries = new();
        var lines = File.ReadAllLines(filePath);
        int indexOfLine = 0;

        foreach (var line in lines)
        {
            int index = line.IndexOf(':') + 1;

            if (index == 0 || !line.Contains('(') || !line.Contains(')'))
            {
                continue;
            }

            int edge = int.Parse(line.Substring(index, line.IndexOf('(') - index).Trim());
            int edgeWeight = int.Parse(line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - line.IndexOf('(') - 1).Trim());

            if (!arrayOfDictionaries.ContainsKey(indexOfLine))
            {
                arrayOfDictionaries[indexOfLine] = new();
            }

            if (!arrayOfDictionaries.ContainsKey(edge))
            {
                arrayOfDictionaries[edge] = new();
            }

            arrayOfDictionaries[indexOfLine][edge] = edgeWeight;

            index = line.IndexOf(',', index);
            while (index != -1)
            {
                int nextEdge = int.Parse(line.Substring(index + 1, line.IndexOf('(', index) - index - 1).Trim());
                int nextEdgeWeight = int.Parse(line.Substring(line.IndexOf('(', index) + 1, 
                    line.IndexOf(')', index) - line.IndexOf('(', index) - 1).Trim());

                arrayOfDictionaries[indexOfLine][nextEdge] = nextEdgeWeight;
                index = line.IndexOf(',', index + 1);
            }
            indexOfLine++;
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
