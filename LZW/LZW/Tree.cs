// <copyright file="Tree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace LZW;

using System.Collections.Generic;

/// <summary>
/// This is a tree node.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Tree"/> class.
/// </remarks>
/// <param name="value"> The value Of node. </param>
public class Tree(char value)
{
    private readonly char value = value;
    private readonly List<Tree> listOfTrees = [];
    private int isEndOfWord;

    /// <summary>
    /// Gets the value of the node.
    /// </summary>
    public char Value => this.value;

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
    public List<Tree> ListOfTrees
    {
        get { return this.listOfTrees; }
    }
}
