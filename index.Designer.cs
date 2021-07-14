
namespace TTProject
{
    partial class index
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
            this.lbResult = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txbDiceRoller = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(12, 70);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(47, 13);
            this.lbResult.TabIndex = 0;
            this.lbResult.Text = "Sonuç : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Zar At";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbDiceRoller
            // 
            this.txbDiceRoller.Location = new System.Drawing.Point(15, 13);
            this.txbDiceRoller.Name = "txbDiceRoller";
            this.txbDiceRoller.Size = new System.Drawing.Size(296, 20);
            this.txbDiceRoller.TabIndex = 2;
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 133);
            this.Controls.Add(this.txbDiceRoller);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbResult);
            this.Name = "index";
            this.Text = "index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbDiceRoller;
    }
}

