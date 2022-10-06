
namespace BattleshipTheGame
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.UNamesContent = new System.Windows.Forms.Label();
            this.USContent = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.YourScore = new System.Windows.Forms.Label();
            this.UNames = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UNamesContent
            // 
            this.UNamesContent.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UNamesContent.Location = new System.Drawing.Point(141, 154);
            this.UNamesContent.Name = "UNamesContent";
            this.UNamesContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UNamesContent.Size = new System.Drawing.Size(245, 250);
            this.UNamesContent.TabIndex = 0;
            this.UNamesContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // USContent
            // 
            this.USContent.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.USContent.Location = new System.Drawing.Point(396, 154);
            this.USContent.Name = "USContent";
            this.USContent.Size = new System.Drawing.Size(245, 250);
            this.USContent.TabIndex = 1;
            this.USContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(189, 49);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(400, 35);
            this.Title.TabIndex = 2;
            this.Title.Text = "RECORDS TABLE";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YourScore
            // 
            this.YourScore.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YourScore.Location = new System.Drawing.Point(141, 84);
            this.YourScore.Name = "YourScore";
            this.YourScore.Size = new System.Drawing.Size(500, 30);
            this.YourScore.TabIndex = 3;
            this.YourScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UNames
            // 
            this.UNames.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UNames.Location = new System.Drawing.Point(141, 124);
            this.UNames.Name = "UNames";
            this.UNames.Size = new System.Drawing.Size(245, 30);
            this.UNames.TabIndex = 4;
            this.UNames.Text = "Name";
            this.UNames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(396, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Score";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UNames);
            this.Controls.Add(this.YourScore);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.USContent);
            this.Controls.Add(this.UNamesContent);
            this.Font = new System.Drawing.Font("Garamond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship: The Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UNamesContent;
        private System.Windows.Forms.Label USContent;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label YourScore;
        private System.Windows.Forms.Label UNames;
        private System.Windows.Forms.Label label1;
    }
}