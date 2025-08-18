// <copyright file="Program.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

using System.Collections;
using System.Collections.Generic;

using LZW;

BorLZW newFile = new();

Console.WriteLine("Write '-c' - to compress, '-u' - to decompress:\n");
string? key = Console.ReadLine();

if (key == "-c")
{
    newFile.Compress("text.txt");
}

if (key == "-u")
{
    newFile.Decompress("text.txt");
}
