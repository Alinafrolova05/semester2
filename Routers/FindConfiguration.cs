namespace Routers;

/// <summary>
/// Finds configuration.
/// </summary>
public class Configuration
{
    private ReadFile readFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="Configuration"/> class.
    /// <param name="readFileInstance"> file. </param>
    /// <exception cref="ArgumentNullException"> If file doesn't find. </exception>
    public Configuration(ReadFile readFileInstance)
    {
        this.readFile = readFileInstance ?? throw new ArgumentNullException(nameof(readFileInstance), "ReadFile instance cannot be null.");
    }

    /// <summary>
    /// Returns the result configuration.
    /// </summary>
    /// <returns> Dictionary with configuration. </returns>
    public Dictionary<int, Dictionary<int, int>> ResultConfiguration()
    {
        return this.Algorithm(this.readFile.ArrayOfDictionaries.Count);
    }

    private static (int, int, int) FindMax(Dictionary<int, Dictionary<int, int>> edges, List<int> visited)
    {
        int isElementInVisited = 0;
        int maxEdge = -1;
        int maxWeight = 0;

        foreach (var element in visited)
        {
            foreach (var edge in edges[element])
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

    private Dictionary<int, Dictionary<int, int>> Algorithm(int countOfEdges)
    {
        List<int> visited = new ();
        Dictionary<int, Dictionary<int, int>> newArrayOfDictionaries = new ();
        int currentEdge = 1;

        while (visited.Count < countOfEdges - 1)
        {
            visited.Add(currentEdge );

            var (isElementInVisited, edge, edgeWeight) = FindMax(this.readFile.ArrayOfDictionaries, visited);

            if (edge != -1)
            {
                if (!newArrayOfDictionaries.ContainsKey(isElementInVisited))
                {
                    newArrayOfDictionaries[isElementInVisited] = new ();
                }

                newArrayOfDictionaries[isElementInVisited][edge] = edgeWeight;
                currentEdge = edge;
            }
            else
            {
                break;
            }
        }

        return newArrayOfDictionaries;
    }
}
