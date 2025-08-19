// <copyright file="Program.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace CalculatorW;

using System;
using System.Windows.Forms;

/// <summary>
/// Provides the result.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new CalculatorForm());
    }
}
