namespace CalculatorWindowsForms;

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// The main function.
/// </summary>
public class Calculator
{
    private readonly TextBox textBox1;
    private readonly TextBox textBox2;
    private double result = 0;
    private string operation = string.Empty;
    private bool operationPressed = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="Calculator"/> class.
    /// </summary>
    /// <param name="textBox1"> textBox1. </param>
    /// <param name="textBox2"> textBox2. </param>
    public Calculator(TextBox textBox1, TextBox textBox2)
    {
        this.textBox1 = textBox1;
        this.textBox2 = textBox2;
    }

    /// <summary>
    /// Clicks on button.
    /// </summary>
    /// <param name="sender"> Object. </param>
    /// <param name="e"> EventArgs. </param>
    public void Button_Click(object sender, EventArgs e)
    {
        var clickedButton = sender as Button;
        if (clickedButton == null)
        {
            return;
        }

        string buttonText = clickedButton.Text;
        this.ButtonClick(buttonText);
    }

    private void ButtonClick(string buttonText)
    {
        if (this.IfClickedDelete(buttonText) ||
            this.IfErrorOrMinusFirst(buttonText))
        {
            return;
        }

        if (double.TryParse(buttonText, out _) || buttonText == ".")
        {
            if (this.operationPressed)
            {
                this.textBox1.Text = buttonText == "." ? "0." : buttonText;
                this.operationPressed = false;
            }
            else
            {
                if (buttonText == "." && this.textBox1.Text.Contains('.'))
                {
                    return;
                }
                else if (buttonText == "." && this.textBox1.Text == string.Empty)
                {
                    this.textBox1.Text = "0";
                    this.textBox2.Text = "0";
                }

                this.textBox1.Text += buttonText;
            }

            this.textBox2.Text += buttonText;
        }
        else if (buttonText == "=")
        {
            this.CalculateResult();
            this.textBox2.Text += "=";
        }
        else
        {
            if (!this.operationPressed)
            {
                if (double.TryParse(this.textBox1.Text, out this.result))
                {
                    this.operation = buttonText;
                    this.operationPressed = true;
                    this.textBox2.Text += buttonText;
                }
                else
                {
                    this.textBox1.Text = "Error!";
                }
            }
        }
    }

    private bool IfClickedDelete(string buttonText)
    {
        if (buttonText == "Del" && this.textBox1.Text != "0" && this.textBox1.Text.Length > 0)
        {
            this.textBox1.Text = this.textBox1.Text.Substring(0, this.textBox1.Text.Length - 1);
            return true;
        }

        if (buttonText == "C")
        {
            this.ButtonClearClick();
            return true;
        }

        return false;
    }

    private bool IfErrorOrMinusFirst(string buttonText)
    {
        if ((this.textBox2.Text.EndsWith('=') || this.textBox2.Text == string.Empty) && buttonText == "=")
        {
            return true;
        }

        if (this.textBox1.Text == "0" ||
            this.textBox1.Text == "Error!" ||
            this.textBox2.Text.EndsWith('='))
        {
            this.ButtonClearClick();
            this.textBox1.Clear();
            if (buttonText == "-" && this.textBox2.Text == string.Empty)
            {
                this.textBox1.Text += buttonText;
                this.textBox2.Text += buttonText;
                return true;
            }
        }

        return false;
    }

    private void ButtonClearClick()
    {
        this.textBox1.Text = "0";
        this.textBox2.Clear();
        this.result = 0;
        this.operation = string.Empty;
        this.operationPressed = false;
    }

    private void CalculateResult()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        if (!double.TryParse(this.textBox1.Text, out double secondOperand))
        {
            this.textBox1.Text = "Error!";
            return;
        }

        switch (this.operation)
        {
            case "+":
                this.result += secondOperand;
                break;
            case "-":
                this.result -= secondOperand;
                break;
            case "*":
                this.result *= secondOperand;
                break;
            case "/":
                if (secondOperand == 0)
                {
                    this.textBox1.Text = "Error!";
                    return;
                }

                this.result /= secondOperand;
                break;
        }

        this.textBox1.Text = this.result.ToString();
        this.operation = string.Empty;
    }
}
