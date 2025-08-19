// <copyright file="Tests.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace CalculatorWindowsForms.Tests;

using System.Windows.Forms;

/// <summary>
/// Tests.
/// </summary>
[TestFixture]
public class Tests
{
    private TextBox textBox1 = new TextBox();
    private TextBox textBox2 = new TextBox();
    private Calculator calculator;

    /// <summary>
    /// Sets up value for calculator.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.calculator = new Calculator(this.textBox1, this.textBox2);
    }

    /// <summary>
    /// Test Addition.
    /// </summary>
    [Test]
    public void TestAddition()
    {
        this.calculator.ButtonClick("5");
        this.calculator.ButtonClick("+");
        this.calculator.ButtonClick("3");
        this.calculator.ButtonClick("=");
        Assert.That(this.textBox1.Text, Is.EqualTo("8"));
        Assert.That(this.textBox2.Text, Is.EqualTo("5+3="));
    }

    /// <summary>
    /// Test Subtraction.
    /// </summary>
    [Test]
    public void TestSubtraction()
    {
        this.calculator.ButtonClick("10");
        this.calculator.ButtonClick("-");
        this.calculator.ButtonClick("4");
        this.calculator.ButtonClick("=");
        Assert.That(this.textBox1.Text, Is.EqualTo("6"));
        Assert.That(this.textBox2.Text, Is.EqualTo("10-4="));
    }

    /// <summary>
    /// Test Multiplication.
    /// </summary>
    [Test]
    public void TestMultiplication()
    {
        this.calculator.ButtonClick("7");
        this.calculator.ButtonClick("*");
        this.calculator.ButtonClick("6");
        this.calculator.ButtonClick("=");
        Assert.That(this.textBox1.Text, Is.EqualTo("42"));
        Assert.That(this.textBox2.Text, Is.EqualTo("7*6="));
    }

    /// <summary>
    /// Test Division.
    /// </summary>
    [Test]
    public void TestDivision()
    {
        this.calculator.ButtonClick("8");
        this.calculator.ButtonClick("/");
        this.calculator.ButtonClick("2");
        this.calculator.ButtonClick("=");
        Assert.That(this.textBox1.Text, Is.EqualTo("4"));
        Assert.That(this.textBox2.Text, Is.EqualTo("8/2="));
    }

    /// <summary>
    /// Test DivisionByZero.
    /// </summary>
    [Test]
    public void TestDivisionByZero()
    {
        this.calculator.ButtonClick("5");
        this.calculator.ButtonClick("/");
        this.calculator.ButtonClick("0");
        this.calculator.ButtonClick("=");
        Assert.That(this.textBox1.Text, Is.EqualTo("Error!"));
        Assert.That(this.textBox2.Text, Is.EqualTo("5/0="));
    }

    /// <summary>
    /// Test Clear Functionality.
    /// </summary>
    [Test]
    public void TestClearFunctionality()
    {
        this.calculator.ButtonClick("5");
        this.calculator.ButtonClick("C");
        Assert.That(this.textBox1.Text, Is.EqualTo("0"));
        Assert.That(this.textBox2.Text, Is.Empty);
    }

    /// <summary>
    /// Test Delete Functionality.
    /// </summary>
    [Test]
    public void TestDeleteFunctionality()
    {
        this.calculator.ButtonClick("123");
        this.calculator.ButtonClick("Del");
        Assert.That(this.textBox1.Text, Is.EqualTo("12"));
    }

    /// <summary>
    /// Test Invalid Operation.
    /// </summary>
    [Test]
    public void TestInvalidOperation()
    {
        this.calculator.ButtonClick("5");
        this.calculator.ButtonClick("+");
        this.calculator.ButtonClick("abc");
        this.calculator.ButtonClick("=");
        Assert.That(this.textBox1.Text, Is.EqualTo("Error!"));
        Assert.That(this.textBox2.Text, Is.EqualTo("5+abc="));
    }
}
