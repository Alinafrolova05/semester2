using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsControlWork;

public class Game
{
    List<int> arrayOfButtons;
    Random random;
    public object Controls { get; private set; }

    public Game()
    {
        for (int i = 1; i <= 9; ++i)
        {
            arrayOfButtons.Add(i);
        }
        random = new Random();
    }

    public void Button_Click(object sender, EventArgs e)
    {
        var clickedButton = sender as Button;
        if (clickedButton == null)
        {
            return;
        }

        clickedButton.Text = "x";
        arrayOfButtons.Remove((int)clickedButton.Tag);

        int NumbeOfFButtonPlayer2 = arrayOfButtons[random.Next(arrayOfButtons.Count)];
        arrayOfButtons.Remove(NumbeOfFButtonPlayer2);

        string buttonName = "button" + NumbeOfFButtonPlayer2.ToString();

        Control[] foundControls = this.Controls.Find(buttonName, true);
        if (foundControls.Length > 0 && foundControls[0] is Button buttton)
        {
            buttton.Text = "o";
        }
    }

    public bool IsWinRight()
    {
        int[,] array = new int[3, 3];
        string buttonName = string.Empty;

        Control[] foundControls = this.Controls.Find("button1", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button1)
        {
            array[0, 0] = int.Parse(button1.Text);
        }

        foundControls = this.Controls.Find("button2", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button2)
        {
            array[1, 0] = int.Parse(button2.Text);
        }

        foundControls = this.Controls.Find("button3", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button3)
        {
            array[2, 0] = int.Parse(button3.Text);
        }

        foundControls = this.Controls.Find("button4", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button4)
        {
            array[0, 1] = int.Parse(button4.Text);
        }

        foundControls = this.Controls.Find("button5", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button5)
        {
            array[1, 1] = int.Parse(button5.Text);
        }
        foundControls = this.Controls.Find("button6", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button6)
        {
            array[2, 1] = int.Parse(button6.Text);
        }

        foundControls = this.Controls.Find("button7", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button7)
        {
            array[0, 2] = int.Parse(button7.Text);
        }

        foundControls = this.Controls.Find("button8", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button8)
        {
            array[1, 2] = int.Parse(button8.Text);
        }

        foundControls = this.Controls.Find("button9", true);
        if (foundControls.Length > 0 && foundControls[0] is Button button9)
        {
            array[2, 2] = int.Parse(button9.Text);
        }
    }
}
