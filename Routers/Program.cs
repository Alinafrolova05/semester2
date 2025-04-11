using NUnit.Framework;
using Routers;

ReadFile file = new ReadFile("text.txt");

AlgoritmPrima algoritm = new AlgoritmPrima(file);

Dictionary<int, Dictionary<int, int>> result = algoritm.ResultOfAlgoritmPrima();

file.WriteDictionary(result);
