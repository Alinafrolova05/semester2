namespace CalculatorW;

using System;
using System.Windows.Forms;
using CalculatorWindowsForms;

/// <summary>
/// Represents an application form.
/// </summary>
public partial class Form1 : Form
{
    private readonly Calculator calculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="Form1"/> class.
    /// </summary>
    public Form1()
    {
        this.InitializeComponent();
        this.textBox1.ReadOnly = true;
        this.textBox2.ReadOnly = true;
        this.calculator = new (this.textBox1, this.textBox2);
        this.KeyPreview = true;
        this.KeyDown += new KeyEventHandler(EventLoop.Form1_KeyDown);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void Button_Click(object sender, EventArgs e)
    {
        this.calculator.Button_Click(sender, e);
    }
}
