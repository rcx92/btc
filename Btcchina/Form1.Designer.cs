namespace Btcchina
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Begin = new System.Windows.Forms.Button();
            this.end = new System.Windows.Forms.Button();
            this.buyBox = new System.Windows.Forms.TextBox();
            this.sellBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.secretK = new System.Windows.Forms.TextBox();
            this.publicK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Begin
            // 
            this.Begin.Location = new System.Drawing.Point(68, 70);
            this.Begin.Name = "Begin";
            this.Begin.Size = new System.Drawing.Size(75, 25);
            this.Begin.TabIndex = 0;
            this.Begin.Text = "Begin";
            this.Begin.UseVisualStyleBackColor = true;
            this.Begin.Click += new System.EventHandler(this.Begin_Click);
            // 
            // end
            // 
            this.end.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.end.Location = new System.Drawing.Point(164, 70);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(75, 25);
            this.end.TabIndex = 1;
            this.end.Text = "End";
            this.end.UseVisualStyleBackColor = true;
            this.end.Click += new System.EventHandler(this.end_Click);
            // 
            // buyBox
            // 
            this.buyBox.Location = new System.Drawing.Point(68, 102);
            this.buyBox.Name = "buyBox";
            this.buyBox.Size = new System.Drawing.Size(75, 20);
            this.buyBox.TabIndex = 2;
            // 
            // sellBox
            // 
            this.sellBox.Location = new System.Drawing.Point(164, 102);
            this.sellBox.Name = "sellBox";
            this.sellBox.Size = new System.Drawing.Size(75, 20);
            this.sellBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "买";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "卖";
            // 
            // secretK
            // 
            this.secretK.Location = new System.Drawing.Point(68, 183);
            this.secretK.Name = "secretK";
            this.secretK.Size = new System.Drawing.Size(100, 20);
            this.secretK.TabIndex = 6;
            // 
            // publicK
            // 
            this.publicK.Location = new System.Drawing.Point(68, 157);
            this.publicK.Name = "publicK";
            this.publicK.Size = new System.Drawing.Size(100, 20);
            this.publicK.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Public";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Secret";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.publicK);
            this.Controls.Add(this.secretK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sellBox);
            this.Controls.Add(this.buyBox);
            this.Controls.Add(this.end);
            this.Controls.Add(this.Begin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Begin;
        private System.Windows.Forms.Button end;
        private System.Windows.Forms.TextBox buyBox;
        private System.Windows.Forms.TextBox sellBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox secretK;
        private System.Windows.Forms.TextBox publicK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

