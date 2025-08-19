// <copyright file="Interface1.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>
namespace Routers;

using System.Collections.Generic;

/// <summary>
/// Interface for reading files and providing data in a structured format.
/// </summary>
public interface IFileReader
{
    /// <summary>
    /// Reads lines from the specified file.
    /// </summary>
    /// <param name="filePath">The path to the file to read.</param>
    /// <returns>An array of strings representing the lines in the file.</returns>
    string[] ReadLines(string filePath);

    /// <summary>
    /// Gets the dictionaries that represent the parsed data from the file.
    /// </summary>
    /// <returns>A dictionary where the key is an integer and the value is another dictionary of integers.</returns>
    Dictionary<int, Dictionary<int, int>> GetDictionaries();
}
