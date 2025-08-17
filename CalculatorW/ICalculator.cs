// <copyright file="Interface1.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace CalculatorW;

/// <summary>
/// Interface for calculator.
/// </summary>
public interface ICalculator
{
    /// <summary>
    /// Clicks on button.
    /// </summary>
    /// <param name="buttonText"> Text of button. </param>
    public void ButtonClick(string buttonText);
}
