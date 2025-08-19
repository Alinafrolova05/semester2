// <copyright file="CalculatorForm.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace CalculatorW;

using System;
using System.Windows.Forms;
using CalculatorWindowsForms;

/// <summary>
/// Represents an application form.
/// </summary>
public partial class CalculatorForm : Form
{
    private readonly Calculator calculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
    /// </summary>
    public CalculatorForm()
    {
        this.InitializeComponent();
        this.calculator = new Calculator(this.textBox1, this.textBox2);
        this.KeyDown += new KeyEventHandler(InputEventProcessor.Form1_KeyDown);
        this.KeyPreview = true;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        this.textBox1.Text = "0";
        this.textBox2.Clear();
    }

    private void Button_Click(object sender, EventArgs e)
    {
        var clickedButton = sender as System.Windows.Forms.Button;
        if (clickedButton == null)
        {
            return;
        }

        string buttonText = clickedButton.Text;
        this.calculator.ButtonClick(buttonText);
    }
}
