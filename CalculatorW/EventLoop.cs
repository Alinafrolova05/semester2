namespace CalculatorWindowsForms;

using CalculatorW;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Processes events.
/// </summary>
public static class EventLoop
{
    /// <summary>
    /// Processes events.
    /// </summary>
    /// <param name="sender"> Object. </param>
    /// <param name="e"> KeyEventArgs.</param>
    public static void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        ProcessEvent(sender, e);
    }

    private static void ProcessEvent(object sender, KeyEventArgs e)
    {
        if (sender is Form1 form)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                var button = form.Controls.Find("button" + (e.KeyValue - 48), true)[0] as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                var button = form.Controls.Find("button" + (e.KeyCode - Keys.NumPad0), true).FirstOrDefault() as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode == Keys.Add)
            {
                var button = form.Controls.Find("buttonPlus", true)[0] as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                var button = form.Controls.Find("buttonMinus", true)[0] as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                var button = form.Controls.Find("buttonMultiply", true)[0] as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode == Keys.Divide)
            {
                var button = form.Controls.Find("buttonDivide", true)[0] as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                var button = form.Controls.Find("buttonEquals", true)[0] as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode == Keys.Back)
            {
                var button = form.Controls.Find("buttonBackspace", true)[0] as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                var button = form.Controls.Find("buttonClear", true)[0] as Button;
                button?.PerformClick();
            }
            else if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                var button = form.Controls.Find("buttonDot", true)[0] as Button;
                button?.PerformClick();
            }
        }
    }
}
