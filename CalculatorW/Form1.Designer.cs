namespace CalculatorW;

partial class Form1
{
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        buttonDot = new System.Windows.Forms.Button();
        button6 = new System.Windows.Forms.Button();
        button7 = new System.Windows.Forms.Button();
        button8 = new System.Windows.Forms.Button();
        buttonEquals = new System.Windows.Forms.Button();
        button10 = new System.Windows.Forms.Button();
        button11 = new System.Windows.Forms.Button();
        button12 = new System.Windows.Forms.Button();
        buttonPlus = new System.Windows.Forms.Button();
        buttonDivide = new System.Windows.Forms.Button();
        buttonMultiply = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        buttonMinus = new System.Windows.Forms.Button();
        buttonBackspace = new System.Windows.Forms.Button();
        buttonClear = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button0
        // 
        button4.Location = new System.Drawing.Point(15, 412);
        button4.Name = "button0";
        button4.Size = new System.Drawing.Size(70, 50);
        button4.TabIndex = 3;
        button4.Text = "0";
        button4.UseVisualStyleBackColor = true;
        button4.Click += Button_Click;
        // 
        // button1
        // 
        button3.Location = new System.Drawing.Point(15, 340);
        button3.Name = "button1";
        button3.Size = new System.Drawing.Size(70, 50);
        button3.TabIndex = 2;
        button3.Text = "1";
        button3.UseVisualStyleBackColor = true;
        button3.Click += Button_Click;
        // 
        // button2
        // 
        button6.Location = new System.Drawing.Point(98, 340);
        button6.Name = "button2";
        button6.Size = new System.Drawing.Size(70, 50);
        button6.TabIndex = 6;
        button6.Text = "2";
        button6.UseVisualStyleBackColor = true;
        button6.Click += Button_Click;
        // 
        // button3
        // 
        button10.Location = new System.Drawing.Point(185, 340);
        button10.Name = "button3";
        button10.Size = new System.Drawing.Size(70, 50);
        button10.TabIndex = 10;
        button10.Text = "3";
        button10.UseVisualStyleBackColor = true;
        button10.Click += Button_Click;
        // 
        // button4
        // 
        button2.Location = new System.Drawing.Point(15, 273);
        button2.Name = "button4";
        button2.Size = new System.Drawing.Size(70, 50);
        button2.TabIndex = 1;
        button2.Text = "4";
        button2.UseVisualStyleBackColor = true;
        button2.Click += Button_Click;
        // 
        // button5
        // 
        button7.Location = new System.Drawing.Point(98, 273);
        button7.Name = "button5";
        button7.Size = new System.Drawing.Size(70, 50);
        button7.TabIndex = 5;
        button7.Text = "5";
        button7.UseVisualStyleBackColor = true;
        button7.Click += Button_Click;
        // 
        // button6
        // 
        button11.Location = new System.Drawing.Point(185, 273);
        button11.Name = "button6";
        button11.Size = new System.Drawing.Size(70, 50);
        button11.TabIndex = 9;
        button11.Text = "6";
        button11.UseVisualStyleBackColor = true;
        button11.Click += Button_Click;
        // 
        // button7
        // 
        button1.Location = new System.Drawing.Point(15, 209);
        button1.Name = "button7";
        button1.Size = new System.Drawing.Size(70, 50);
        button1.TabIndex = 0;
        button1.Text = "7";
        button1.UseVisualStyleBackColor = true;
        button1.Click += Button_Click;
        // 
        // button8
        // 
        button8.Location = new System.Drawing.Point(98, 209);
        button8.Name = "button8";
        button8.Size = new System.Drawing.Size(70, 50);
        button8.TabIndex = 4;
        button8.Text = "8";
        button8.UseVisualStyleBackColor = true;
        button8.Click += Button_Click;
        // 
        // button9
        // 
        button12.Location = new System.Drawing.Point(185, 209);
        button12.Name = "button9";
        button12.Size = new System.Drawing.Size(70, 50);
        button12.TabIndex = 8;
        button12.Text = "9";
        button12.UseVisualStyleBackColor = true;
        button12.Click += Button_Click;
        // 
        // buttonDot
        // 
        buttonDot.Location = new System.Drawing.Point(98, 412);
        buttonDot.Name = "buttonDot";
        buttonDot.Size = new System.Drawing.Size(70, 50);
        buttonDot.TabIndex = 7;
        buttonDot.Text = ".";
        buttonDot.UseVisualStyleBackColor = true;
        buttonDot.Click += Button_Click;
        // 
        // buttonPlus
        // 
        buttonPlus.Location = new System.Drawing.Point(275, 412);
        buttonPlus.Name = "buttonPlus";
        buttonPlus.Size = new System.Drawing.Size(70, 50);
        buttonPlus.TabIndex = 14;
        buttonPlus.Text = "+";
        buttonPlus.UseVisualStyleBackColor = true;
        buttonPlus.Click += Button_Click;
        // 
        // buttonMinus
        // 
        buttonMinus.Location = new System.Drawing.Point(275, 340);
        buttonMinus.Name = "buttonMinus";
        buttonMinus.Size = new System.Drawing.Size(70, 50);
        buttonMinus.TabIndex = 28;
        buttonMinus.Text = "-";
        buttonMinus.UseVisualStyleBackColor = true;
        buttonMinus.Click += Button_Click;
        // 
        // buttonDivide
        // 
        buttonDivide.Location = new System.Drawing.Point(275, 273);
        buttonDivide.Name = "buttonDivide";
        buttonDivide.Size = new System.Drawing.Size(70, 50);
        buttonDivide.TabIndex = 13;
        buttonDivide.Text = "/";
        buttonDivide.UseVisualStyleBackColor = true;
        buttonDivide.Click += Button_Click;
        // 
        // buttonMultiply
        // 
        buttonMultiply.Location = new System.Drawing.Point(275, 209);
        buttonMultiply.Name = "buttonMultiply";
        buttonMultiply.Size = new System.Drawing.Size(70, 50);
        buttonMultiply.TabIndex = 12;
        buttonMultiply.Text = "*";
        buttonMultiply.UseVisualStyleBackColor = true;
        buttonMultiply.Click += Button_Click;
        // 
        // buttonEquals
        // 
        buttonEquals.Location = new System.Drawing.Point(185, 412);
        buttonEquals.Name = "buttonEquals";
        buttonEquals.Size = new System.Drawing.Size(70, 50);
        buttonEquals.TabIndex = 11;
        buttonEquals.Text = "=";
        buttonEquals.UseVisualStyleBackColor = true;
        buttonEquals.Click += Button_Click;
        // 
        // textBox1
        // 
        textBox1.BackColor = System.Drawing.SystemColors.Control;
        textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
        textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
        textBox1.Location = new System.Drawing.Point(12, 41);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(333, 83);
        textBox1.TabIndex = 0;
        textBox1.Text = "0";
        textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // textBox2
        // 
        textBox2.BackColor = System.Drawing.SystemColors.HighlightText;
        textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
        textBox2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
        textBox2.Location = new System.Drawing.Point(12, 24);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(333, 20);
        textBox2.TabIndex = 27;
        textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // buttonBackspace
        // 
        buttonBackspace.Location = new System.Drawing.Point(185, 145);
        buttonBackspace.Name = "buttonBackspace";
        buttonBackspace.Size = new System.Drawing.Size(160, 50);
        buttonBackspace.TabIndex = 30;
        buttonBackspace.Text = "Del";
        buttonBackspace.UseVisualStyleBackColor = true;
        buttonBackspace.Click += Button_Click;
        // 
        // buttonClear
        // 
        buttonClear.Location = new System.Drawing.Point(15, 144);
        buttonClear.Name = "buttonClear";
        buttonClear.Size = new System.Drawing.Size(153, 50);
        buttonClear.TabIndex = 29;
        buttonClear.Text = "C";
        buttonClear.UseVisualStyleBackColor = true;
        buttonClear.Click += Button_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.ControlLightLight;
        ClientSize = new System.Drawing.Size(363, 486);
        Controls.Add(buttonBackspace);
        Controls.Add(buttonClear);
        Controls.Add(buttonMinus);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(buttonPlus);
        Controls.Add(buttonDivide);
        Controls.Add(buttonMultiply);
        Controls.Add(buttonEquals);
        Controls.Add(button10);
        Controls.Add(button11);
        Controls.Add(button12);
        Controls.Add(buttonDot);
        Controls.Add(button6);
        Controls.Add(button7);
        Controls.Add(button8);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button buttonDot;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button buttonEquals;
    private System.Windows.Forms.Button button10;
    private System.Windows.Forms.Button button11;
    private System.Windows.Forms.Button button12;
    private System.Windows.Forms.Button buttonPlus;
    private System.Windows.Forms.Button buttonDivide;
    private System.Windows.Forms.Button buttonMultiply;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Button buttonMinus;
    private System.Windows.Forms.Button buttonBackspace;
    private System.Windows.Forms.Button buttonClear;
}
