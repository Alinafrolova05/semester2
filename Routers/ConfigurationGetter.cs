// <copyright file="ConfigurationCreater.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Generates optimal network configuration using maximum spanning tree algorithm.
/// </summary>
public class ConfigurationGetter : IConfigurationGetter
{
    private readonly FileReader readFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationGetter"/> class.
    /// </summary>
    /// <param name="filePath"> Path to the topology file. </param>
    public ConfigurationGetter(string filePath)
    {
        this.readFile = new(filePath);
    }

    /// <summary>
    /// Generates and validates the network configuration.
    /// </summary>
    /// <returns> Configuretion graph. </returns>
    public Dictionary<int, Dictionary<int, int>> GetConfiguration()
    {
        if (!this.IsGraphConnected(this.readFile.NetworkSegmentsGraph))
        {
            Console.Error.WriteLine("The network is not connected.");
            Environment.ExitCode = -1;
            return null;
        }

        return this.CreateConfiguration(this.readFile.NetworkSegmentsGraph);
    }

    /// <summary>
    /// Checks if all network segments are reachable using BFS traversal.
    /// </summary>
    /// <param name="graph"> Network graph with nodes and connections. </param>
    /// <returns> True if graph is fully connected, false otherwise. </returns>
    private bool IsGraphConnected(Dictionary<int, Dictionary<int, int>> graph)
    {
        if (graph.Count == 0)
        {
            return true;
        }

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(graph.Keys.First());

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            visited.Add(current);

            foreach (var neighbor in graph[current].Keys)
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return visited.Count == graph.Count;
    }

    /// <summary>
    /// Creates a maximum spanning tree configuration using Prim's algorithm.
    /// </summary>
    /// <param name="graph"> Network graph with nodes and weighted connections. </param>
    /// <returns> Maximal configuration of a spanning tree in the form of a graph. </returns>
    private Dictionary<int, Dictionary<int, int>> CreateConfiguration(Dictionary<int, Dictionary<int, int>> graph)
    {
        Dictionary<int, Dictionary<int, int>> maxConfigurationGraph = new();
        HashSet<int> visited = new();
        PriorityQueue<(int From, int To, int Weight), int> edges = new();

        if (graph.Count == 0)
        {
            return maxConfigurationGraph;
        }

        int start = graph.Keys.First();
        visited.Add(start);

        foreach (var neighbor in graph[start])
        {
            edges.Enqueue((start, neighbor.Key, neighbor.Value), -neighbor.Value);
        }

        while (visited.Count < graph.Count && edges.Count > 0)
        {
            var (from, to, weight) = edges.Dequeue();

            if (visited.Contains(to))
            {
                continue;
            }

            if (!maxConfigurationGraph.ContainsKey(from))
            {
                maxConfigurationGraph[from] = new();
            }

            maxConfigurationGraph[from][to] = weight;

            visited.Add(to);

            foreach (var neighbor in graph[to])
            {
                if (!visited.Contains(neighbor.Key))
                {
                    edges.Enqueue((to, neighbor.Key, neighbor.Value), -neighbor.Value);
                }
            }
        }

        return maxConfigurationGraph;
    }
}
