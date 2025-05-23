using System.Drawing;

namespace WindowsFormsControlWork
{
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 111);
            this.button1.TabIndex = 0;
            this.button1.Text = "";
            button1.Font = new Font(button1.Font.FontFamily, 20);
            this.button1.UseVisualStyleBackColor = true;
            this.Controls.Add(button1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 100);
            this.button2.TabIndex = 1;
            this.button2.Text = "";
            button2.Font = new Font(button1.Font.FontFamily, 20);
            this.button2.UseVisualStyleBackColor = true;
            this.Controls.Add(button2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 2;
            this.button3.Text = "";
            button3.Font = new Font(button1.Font.FontFamily, 20);
            this.button3.UseVisualStyleBackColor = true;
            this.Controls.Add(button3);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(152, 289);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 100);
            this.button4.TabIndex = 5;
            this.button4.Text = "";
            button4.Font = new Font(button1.Font.FontFamily, 20);
            this.button4.UseVisualStyleBackColor = true;
            this.Controls.Add(button4);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(152, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 100);
            this.button5.TabIndex = 4;
            this.button5.Text = "";
            button5.Font = new Font(button1.Font.FontFamily, 20);
            this.button5.UseVisualStyleBackColor = true;
            this.Controls.Add(button5);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(152, 22);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 111);
            this.button6.TabIndex = 3;
            this.button6.Text = "";
            button6.Font = new Font(button1.Font.FontFamily, 20);
            this.button6.UseVisualStyleBackColor = true;
            this.Controls.Add(button3);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(289, 289);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 100);
            this.button7.TabIndex = 8;
            this.button7.Text = "";
            button7.Font = new Font(button1.Font.FontFamily, 20);
            this.button7.UseVisualStyleBackColor = true;
            this.Controls.Add(button7);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(289, 161);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 100);
            this.button8.TabIndex = 7;
            this.button8.Text = "";
            button8.Font = new Font(button1.Font.FontFamily, 20);
            this.button8.UseVisualStyleBackColor = true;
            this.Controls.Add(button8);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(289, 22);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 111);
            this.button9.TabIndex = 6;
            this.button9.Text = "";
            button9.Font = new Font(button1.Font.FontFamily, 20);
            this.button9.UseVisualStyleBackColor = true;
            this.Controls.Add(button9);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 410);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

