using System;
using System.Windows.Forms;

namespace WindowsFormsControlWork;

public partial class Form1 : Form
{
    private Game game;
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void Button_Click(object sender, EventArgs e)
    {
        this.game.Button_Click(sender, e);
    }

}
