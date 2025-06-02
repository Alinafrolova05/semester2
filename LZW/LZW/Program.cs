// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections;
using System.Collections.Generic;

using LZW;

NewFile newFile = new();
newFile.ChangeFile("text.txt", "-c");
newFile.ChangeFile("text.zipped", "-u");
