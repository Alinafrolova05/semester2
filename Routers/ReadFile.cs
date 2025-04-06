namespace Routers;

class ReadFile
{
    public const int MaxHeight = 256;
    public const int MaxWidth = 256;

    public Dictionary<int, int>[] arrayOfDictionaries { get; set; } = new Dictionary<int, int>[3];

    public void Read()
    {
        var lines = File.ReadAllLines("text.txt");
        for (int y = 0; y < MaxHeight && y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < MaxWidth && x < line.Length; x++)
            {
                char c = line[x];






            }
        }
    }

    public int FindMax(Dictionary<int, int> arrayOfDictionaries, List<int> visited)
    {
        int maxWeight = 0;
        int maxEdge = 0;

        foreach (var c in arrayOfDictionaries)
        {
            if (c.Key > maxWeight && !visited.Contains(c.Value))
            {
                maxWeight = c.Key;
                maxEdge = c.Value;
            }
        }
        return maxEdge;
    }

    public void AlgorithmPrima (int countOfEdges)
    {
        List<int> visited = new();
        int currentEdge = 1;
        for (var i = 0; i < countOfEdges; ++i)
        {
            visited.Add(currentEdge);
            currentEdge = FindMax(arrayOfDictionaries[currentEdge], visited);
        }
    }
}
