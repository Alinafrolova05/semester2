using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW;

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
    /// 
    /// </summary>
    public char Value
    {
        get { return this.value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public int IsEndOfWord
    {
        get { return this.isEndOfWord; }
        set { this.isEndOfWord = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public List<Node> ListOfTrees
    {
        get { return this.listOfTrees; }
    }
}
