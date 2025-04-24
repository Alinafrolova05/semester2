using LZW;
using System.Collections;
using System.Collections.Generic;

Coding task = new();

task.CompressData("text.txt");


foreach (var c in task.dictionary)
{
    Console.WriteLine($" key = {c.Key}, value = {c.Value} ");
}
