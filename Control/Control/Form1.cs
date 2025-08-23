using System;
using System.Drawing;
using System.Windows.Forms;

namespace Control;

/// <summary>
/// Main form.
/// </summary>
public partial class Form1 : Form
{
    private const int SafeDistance = 100;

    private const int ButtonSpeed = 15;

    private Timer cursorCheckTimer;

    /// <summary>
    /// Initializes a new instance of the <see cref="Form1"/> class.
    /// </summary>
    public Form1()
    {
        this.InitializeComponent();
        this.SetupTimer();
    }

    private void SetupTimer()
    {
        this.cursorCheckTimer = new Timer();
        this.cursorCheckTimer.Interval = 50;
        this.cursorCheckTimer.Tick += this.CursorCheckTimer_Tick;
        this.cursorCheckTimer.Start();
    }

    private void CursorCheckTimer_Tick(object sender, EventArgs e)
    {
        var button = this.Controls[0] as Button;
        if (button == null)
        {
            return;
        }

        Point cursorPosition = this.PointToClient(Cursor.Position);

        Point buttonCenter = new Point(
            button.Location.X + (button.Width / 2),
            button.Location.Y + (button.Height / 2));

        double distance = this.CalculateDistance(cursorPosition, buttonCenter);

        if (distance < SafeDistance)
        {
            this.MoveButtonAway(button, cursorPosition);
        }
    }

    private double CalculateDistance(Point point1, Point point2)
    {
        int dx = point1.X - point2.X;
        int dy = point1.Y - point2.Y;
        return Math.Sqrt((dx * dx) + (dy * dy));
    }

    private void MoveButtonAway(Button button, Point cursorPosition)
    {
        Point buttonCenter = new Point(
            button.Location.X + (button.Width / 2),
            button.Location.Y + (button.Height / 2));

        double dx = buttonCenter.X - cursorPosition.X;
        double dy = buttonCenter.Y - cursorPosition.Y;

        double length = Math.Sqrt((dx * dx) + (dy * dy));
        if (length > 0)
        {
            dx /= length;
            dy /= length;
        }

        int newX = button.Location.X + (int)(dx * ButtonSpeed);
        int newY = button.Location.Y + (int)(dy * ButtonSpeed);

        newX = Math.Max(0, Math.Min(this.ClientSize.Width - button.Width, newX));
        newY = Math.Max(0, Math.Min(this.ClientSize.Height - button.Height, newY));

        button.Location = new Point(newX, newY);
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        this.cursorCheckTimer.Stop();

        MessageBox.Show("Exit", "You win!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        Application.Exit();
    }
}
