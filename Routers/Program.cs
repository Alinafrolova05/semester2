// <copyright file="Program.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

using Routers;

FileReader file = new FileReader("text.txt");

Configuration algoritm = new Configuration(file);

Dictionary<int, Dictionary<int, int>> result = algoritm.ResultConfiguration();

file.WriteDictionary(result);
