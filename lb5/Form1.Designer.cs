namespace lb5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            cashRegisterNameLabel = new Label();
            cashRegisterValueLabel = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(418, 131);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(419, 256);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Left;
            textBox1.Location = new Point(0, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(406, 466);
            textBox1.TabIndex = 2;
            // 
            // cashRegisterNameLabel
            // 
            cashRegisterNameLabel.AutoSize = true;
            cashRegisterNameLabel.Location = new Point(412, 9);
            cashRegisterNameLabel.Name = "cashRegisterNameLabel";
            cashRegisterNameLabel.Size = new Size(81, 15);
            cashRegisterNameLabel.TabIndex = 3;
            cashRegisterNameLabel.Text = "Cash Register:";
            // 
            // cashRegisterValueLabel
            // 
            cashRegisterValueLabel.AutoSize = true;
            cashRegisterValueLabel.Location = new Point(413, 35);
            cashRegisterValueLabel.Name = "cashRegisterValueLabel";
            cashRegisterValueLabel.Size = new Size(19, 15);
            cashRegisterValueLabel.TabIndex = 4;
            cashRegisterValueLabel.Text = "0$";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 466);
            Controls.Add(cashRegisterValueLabel);
            Controls.Add(cashRegisterNameLabel);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label cashRegisterNameLabel;
        private Label cashRegisterValueLabel;
    }
}