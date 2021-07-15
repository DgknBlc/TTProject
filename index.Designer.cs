
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
            this.cbisOpen = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResult.Location = new System.Drawing.Point(3, 92);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(317, 143);
            this.lbResult.TabIndex = 0;
            this.lbResult.Text = "Sonuç : ";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(124, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Zar At";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbDiceRoller
            // 
            this.txbDiceRoller.Dock = System.Windows.Forms.DockStyle.Top;
            this.txbDiceRoller.Location = new System.Drawing.Point(3, 3);
            this.txbDiceRoller.Multiline = true;
            this.txbDiceRoller.Name = "txbDiceRoller";
            this.txbDiceRoller.Size = new System.Drawing.Size(317, 24);
            this.txbDiceRoller.TabIndex = 2;
            // 
            // cbisOpen
            // 
            this.cbisOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbisOpen.AutoSize = true;
            this.cbisOpen.Location = new System.Drawing.Point(128, 33);
            this.cbisOpen.Name = "cbisOpen";
            this.cbisOpen.Size = new System.Drawing.Size(66, 17);
            this.cbisOpen.TabIndex = 3;
            this.cbisOpen.Text = "Açık Zar";
            this.cbisOpen.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbisOpen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txbDiceRoller, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbResult, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.54839F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.45161F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 235);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(323, 235);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "index";
            this.Text = "index";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbDiceRoller;
        private System.Windows.Forms.CheckBox cbisOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

