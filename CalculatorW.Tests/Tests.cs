using NUnit.Framework;
using System.Windows.Forms;
using CalculatorWindowsForms;

namespace CalculatorW.Tests;

public class Tests
{
    private TextBox textBox1;
    private TextBox textBox2;
    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        calculator = new Calculator(textBox1, textBox2);
    }

    [Test]
    public void TestAddition()
    {
        calculator.ButtonClick("5");
        calculator.ButtonClick("+");
        calculator.ButtonClick("3");
        calculator.ButtonClick("=");
        Assert.That(textBox1.Text, Is.EqualTo("8"));
        Assert.That(textBox2.Text, Is.EqualTo("5+3="));
    }

    [Test]
    public void TestSubtraction()
    {
        calculator.ButtonClick("10");
        calculator.ButtonClick("-");
        calculator.ButtonClick("4");
        calculator.ButtonClick("=");
        Assert.That(textBox1.Text, Is.EqualTo("6"));
        Assert.That(textBox2.Text, Is.EqualTo("10-4="));
    }

    [Test]
    public void TestMultiplication()
    {
        calculator.ButtonClick("7");
        calculator.ButtonClick("*");
        calculator.ButtonClick("6");
        calculator.ButtonClick("=");
        Assert.That(textBox1.Text, Is.EqualTo("42"));
        Assert.That(textBox2.Text, Is.EqualTo("7*6="));
    }

    [Test]
    public void TestDivision()
    {
        calculator.ButtonClick("8");
        calculator.ButtonClick("/");
        calculator.ButtonClick("2");
        calculator.ButtonClick("=");
        Assert.That(textBox1.Text, Is.EqualTo("4"));
        Assert.That(textBox2.Text, Is.EqualTo("8/2="));
    }

    [Test]
    public void TestDivisionByZero()
    {
        calculator.ButtonClick("5");
        calculator.ButtonClick("/");
        calculator.ButtonClick("0");
        calculator.ButtonClick("=");
        Assert.That(textBox1.Text, Is.EqualTo("Error!"));
        Assert.That(textBox2.Text, Is.EqualTo("5/0="));
    }

    [Test]
    public void TestClearFunctionality()
    {
        calculator.ButtonClick("5");
        calculator.ButtonClick("C");
        Assert.That(textBox1.Text, Is.EqualTo("0"));
        Assert.That(textBox2.Text, Is.Empty);
    }

    [Test]
    public void TestDeleteFunctionality()
    {
        calculator.ButtonClick("123");
        calculator.ButtonClick("Del");
        Assert.That(textBox1.Text, Is.EqualTo("12"));
    }

    [Test]
    public void TestInvalidOperation()
    {
        calculator.ButtonClick("5");
        calculator.ButtonClick("+");
        calculator.ButtonClick("abc");
        calculator.ButtonClick("=");
        Assert.That(textBox1.Text, Is.EqualTo("Error!"));
        Assert.That(textBox2.Text, Is.EqualTo("5+abc="));
    }
}
