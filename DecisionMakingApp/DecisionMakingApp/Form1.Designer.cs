namespace DecisionMakingApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.goal_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.criteria_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.options_textBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.next_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // goal_textBox
            // 
            this.goal_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goal_textBox.Location = new System.Drawing.Point(395, 3);
            this.goal_textBox.Multiline = true;
            this.goal_textBox.Name = "goal_textBox";
            this.goal_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.goal_textBox.Size = new System.Drawing.Size(335, 75);
            this.goal_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 81);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите через запятую КРИТЕРИИ, по которым необходимо \r\nсравнивать  варианты (нап" +
    "ример, цена, объем оперативной памяти и т.д.)\r\n      [по каким признакам сравнив" +
    "ать?]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // criteria_textBox
            // 
            this.criteria_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.criteria_textBox.Location = new System.Drawing.Point(395, 84);
            this.criteria_textBox.Multiline = true;
            this.criteria_textBox.Name = "criteria_textBox";
            this.criteria_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.criteria_textBox.Size = new System.Drawing.Size(335, 75);
            this.criteria_textBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 82);
            this.label3.TabIndex = 4;
            this.label3.Text = "Введите через запятую ВАРИАНТЫ, среди которых необходимо выбрать \r\nнаилучший (нап" +
    "ример,  LG D295, Samsung Galaxy Ace)\r\n                                     [из ч" +
    "его выбрать?]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // options_textBox
            // 
            this.options_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.options_textBox.Location = new System.Drawing.Point(395, 165);
            this.options_textBox.Multiline = true;
            this.options_textBox.Name = "options_textBox";
            this.options_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.options_textBox.Size = new System.Drawing.Size(335, 76);
            this.options_textBox.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.next_button);
            this.panel1.Location = new System.Drawing.Point(12, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 347);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 287);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.goal_textBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.criteria_textBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.options_textBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(733, 244);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите ЦЕЛЬ принятия решения (например, покупка телефона)\r\n      [что Вы хотите " +
    "сделать?]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // next_button
            // 
            this.next_button.Location = new System.Drawing.Point(670, 321);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(75, 23);
            this.next_button.TabIndex = 8;
            this.next_button.Text = "Далее";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(774, 367);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Decision-making app";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox goal_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox criteria_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox options_textBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Panel panel2;
    }
}

