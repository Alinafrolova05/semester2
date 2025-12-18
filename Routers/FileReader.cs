// <copyright file="FileReader.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Reads and parses network topology from file.
/// </summary>
public class FileReader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileReader"/> class.
    /// </summary>
    /// <param name="filePath">Path to the topology file.</param>
    /// <exception cref="ArgumentNullException">Thrown when file path is null.</exception>
    /// <exception cref="FileNotFoundException">Thrown when file doesn't exist.</exception>
    /// <exception cref="InvalidDataException">Thrown when file format is invalid.</exception>
    public FileReader(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        this.NetworkSegmentsGraph = this.ParseFile(filePath);
    }

    /// <summary>
    /// Gets the parsed network topology graph.
    /// </summary>
    public Dictionary<int, Dictionary<int, int>> NetworkSegmentsGraph { get; }

    /// <summary>
    /// Prints dictionary to console.
    /// </summary>
    /// <param name="graph">Graph to print.</param>
    public void PrintDictionary(Dictionary<int, Dictionary<int, int>> graph)
    {
        foreach (var (node, connections) in graph)
        {
            Console.WriteLine($"{node}:");
            foreach (var (target, weight) in connections)
            {
                Console.WriteLine($"  {target} ({weight})");
            }
        }
    }

    /// <summary>
    /// Parses the file and constructs the graph.
    /// </summary>
    /// <param name="filePath">Path to the file.</param>
    /// <returns>Parsed graph structure.</returns>
    private Dictionary<int, Dictionary<int, int>> ParseFile(string filePath)
    {
        var graph = new Dictionary<int, Dictionary<int, int>>();
        var lines = File.ReadAllLines(filePath);

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (string.IsNullOrEmpty(line))
            {
                throw new InvalidDataException($"Line {i + 1} is empty.");
            }

            try
            {
                this.ParseLine(line, graph, i + 1);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"Error parsing line {i + 1}: {ex.Message}", ex);
            }
        }

        return graph;
    }

    /// <summary>
    /// Parses a single line of the file.
    /// </summary>
    /// <param name="line">Line to parse.</param>
    /// <param name="graph">Graph to populate.</param>
    /// <param name="lineNumber">Line number for error reporting.</param>
    private void ParseLine(string line, Dictionary<int, Dictionary<int, int>> graph, int lineNumber)
    {
        var colonIndex = line.IndexOf(':');
        if (colonIndex == -1)
        {
            throw new InvalidDataException("Line must contain a colon separator.");
        }

        var nodePart = line.Substring(0, colonIndex).Trim();
        if (!int.TryParse(nodePart, out int node))
        {
            throw new InvalidDataException($"Invalid node format: '{nodePart}'");
        }

        var connectionsPart = line.Substring(colonIndex + 1).Trim();
        if (string.IsNullOrEmpty(connectionsPart))
        {
            return;
        }

        var connections = connectionsPart.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (var connection in connections)
        {
            this.ParseConnection(connection.Trim(), node, graph, lineNumber);
        }
    }

    /// <summary>
    /// Parses a single connection entry.
    /// </summary>
    /// <param name="connection">Connection string to parse.</param>
    /// <param name="sourceNode">Source node of the connection.</param>
    /// <param name="graph">Graph to populate.</param>
    /// <param name="lineNumber">Line number for error reporting.</param>
    private void ParseConnection(string connection, int sourceNode, 
        Dictionary<int, Dictionary<int, int>> graph,
        int lineNumber)
    {
        var openParenIndex = connection.IndexOf('(');
        var closeParenIndex = connection.IndexOf(')');

        if (openParenIndex == -1 || closeParenIndex == -1 || closeParenIndex <= openParenIndex)
        {
            throw new InvalidDataException($"Invalid connection format: '{connection}'");
        }

        var targetNodePart = connection.Substring(0, openParenIndex).Trim();
        if (!int.TryParse(targetNodePart, out int targetNode))
        {
            throw new InvalidDataException($"Invalid target node: '{targetNodePart}'");
        }

        var weightPart = connection.Substring(openParenIndex + 1, closeParenIndex - openParenIndex - 1).Trim();
        if (!int.TryParse(weightPart, out int weight) || weight <= 0)
        {
            throw new InvalidDataException($"Invalid weight value: '{weightPart}'");
        }

        this.EnsureNodeExists(graph, sourceNode);
        this.EnsureNodeExists(graph, targetNode);

        graph[sourceNode][targetNode] = weight;
        graph[targetNode][sourceNode] = weight;
    }

    /// <summary>
    /// Ensures a node exists in the graph.
    /// </summary>
    /// <param name="graph">Graph to check.</param>
    /// <param name="node">Node to ensure exists.</param>
    private void EnsureNodeExists(Dictionary<int, Dictionary<int, int>> graph, int node)
    {
        if (!graph.ContainsKey(node))
        {
            graph[node] = new Dictionary<int, int>();
        }
    }
}
