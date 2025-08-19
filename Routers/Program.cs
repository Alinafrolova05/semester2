// <copyright file="Program.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

using Routers;

FileReader file = new FileReader("Test.txt");

Configuration algorithm = new Configuration(file);

Dictionary<int, Dictionary<int, int>> result = algorithm.ResultConfiguration();

file.WriteDictionary(result);
