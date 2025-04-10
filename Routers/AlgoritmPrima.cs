namespace Routers;

public class AlgoritmPrima
{
    private ReadFile readFile;

    public AlgoritmPrima(ReadFile readFileInstance)
    {
        readFile = readFileInstance ?? throw new ArgumentNullException(nameof(readFileInstance), "ReadFile instance cannot be null.");
    }

    public Dictionary<int, Dictionary<int, int>> ResultOfAlgoritmPrima()
    {
        return Algorithm(readFile.arrayOfDictionaries.Count);
    }

    private Dictionary<int, Dictionary<int, int>> Algorithm(int countOfEdges)
    {
        List<int> visited = new();
        Dictionary<int, Dictionary<int, int>> newArrayOfDictionaries = new();
        int currentEdge = 0;

        while (visited.Count < countOfEdges - 1)
        {
            visited.Add(currentEdge + 1);

            var (isElementInVisited, edge, edgeWeight) = FindMax(readFile.arrayOfDictionaries, visited);

            if (edge != -1)
            {
                if (!newArrayOfDictionaries.ContainsKey(isElementInVisited))
                    newArrayOfDictionaries[isElementInVisited] = new();

                newArrayOfDictionaries[isElementInVisited][edge] = edgeWeight;
                currentEdge = edge - 1;
            }
            else
            {
                break;
            }
        }

        return newArrayOfDictionaries;
    }

    static private (int, int, int) FindMax(Dictionary<int, Dictionary<int, int>> edges, List<int> visited)
    {
        int isElementInVisited = 0;
        int maxEdge = -1;
        int maxWeight = 0;

        foreach (var element in visited)
        {
            foreach (var edge in edges[element - 1])
            {
                if (edge.Value > maxWeight && !visited.Contains(edge.Key))
                {
                    isElementInVisited = element;
                    maxEdge = edge.Key;
                    maxWeight = edge.Value;
                }
            }
        }
        return (isElementInVisited, maxEdge, maxEdge == -1 ? 0 : maxWeight);
    }
}
