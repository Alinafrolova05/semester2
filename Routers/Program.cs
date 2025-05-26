using NUnit.Framework;
using Routers;

ReadFile file = new ReadFile("text.txt");

Configuration algoritm = new Configuration(file);

Dictionary<int, Dictionary<int, int>> result = algoritm.ResultConfiguration();

file.WriteDictionary(result);
