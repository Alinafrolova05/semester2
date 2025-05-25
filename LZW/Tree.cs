namespace LZW;

using System.Collections.Generic;

/// <summary>
/// This is a tree node.
/// </summary>
public class Node
{
    private char value;
    private int isEndOfWord;
    private List<Node> listOfTrees;

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="value"> The value Of node. </param>
    public Node(char value)
    {
        this.value = value;
        this.listOfTrees = new ();
    }

    /// <summary>
    /// Gets the value of the node.
    /// </summary>
    public char Value
    {
        get { return this.value; }
    }

    /// <summary>
    /// Gets or sets the number of the word that end at this node.
    /// </summary>
    public int IsEndOfWord
    {
        get { return this.isEndOfWord; }
        set { this.isEndOfWord = value; }
    }

    /// <summary>
    /// Gets children of the node.
    /// </summary>
    public List<Node> ListOfTrees
    {
        get { return this.listOfTrees; }
    }
}
