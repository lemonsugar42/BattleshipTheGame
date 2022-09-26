
namespace BattleshipTheGame
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.SystemColors.Window;
            this.Canvas.Location = new System.Drawing.Point(3, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(777, 455);
            this.Canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // ListBox
            // 
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 19;
            this.ListBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.ListBox.Location = new System.Drawing.Point(19, 14);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(46, 232);
            this.ListBox.TabIndex = 1;
            // 
            // Button
            // 
            this.Button.BackColor = System.Drawing.SystemColors.Window;
            this.Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button.Location = new System.Drawing.Point(84, 14);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(63, 35);
            this.Button.TabIndex = 2;
            this.Button.Text = "Next";
            this.Button.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.Canvas);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Garamond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship: The Game";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.Button Button;
    }
}