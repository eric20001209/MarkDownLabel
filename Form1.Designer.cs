namespace MarkDownLabel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.btnScan = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lblPrice = new System.Windows.Forms.Label();
			this.btnReload = new System.Windows.Forms.Button();
			this.btnConfig = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.Label();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.txtMarkdownPrice = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblMDBarcode = new System.Windows.Forms.Label();
			this.lblCode = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblUsedBy = new System.Windows.Forms.Label();
			this.lblBestBefore = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Barcode/Code";
			// 
			// txtBarcode
			// 
			this.txtBarcode.Location = new System.Drawing.Point(95, 18);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(267, 20);
			this.txtBarcode.TabIndex = 1;
			this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
			// 
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point(377, 16);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(75, 23);
			this.btnScan.TabIndex = 2;
			this.btnScan.Text = "Scan";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblUsedBy);
			this.panel1.Controls.Add(this.lblBestBefore);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.lblPrice);
			this.panel1.Controls.Add(this.btnReload);
			this.panel1.Controls.Add(this.btnConfig);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.lblName);
			this.panel1.Controls.Add(this.txtQty);
			this.panel1.Controls.Add(this.txtMarkdownPrice);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.lblMDBarcode);
			this.panel1.Controls.Add(this.lblCode);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(15, 59);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(437, 248);
			this.panel1.TabIndex = 3;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(258, 95);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(146, 71);
			this.textBox1.TabIndex = 3;
			this.textBox1.Visible = false;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// lblPrice
			// 
			this.lblPrice.AutoSize = true;
			this.lblPrice.Location = new System.Drawing.Point(106, 60);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Size = new System.Drawing.Size(40, 13);
			this.lblPrice.TabIndex = 0;
			this.lblPrice.Text = "$99.99";
			// 
			// btnReload
			// 
			this.btnReload.Location = new System.Drawing.Point(79, 220);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(75, 23);
			this.btnReload.TabIndex = 2;
			this.btnReload.Text = "Reload";
			this.btnReload.UseVisualStyleBackColor = true;
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// btnConfig
			// 
			this.btnConfig.Location = new System.Drawing.Point(2, 220);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(75, 23);
			this.btnConfig.TabIndex = 2;
			this.btnConfig.Text = "Config";
			this.btnConfig.UseVisualStyleBackColor = true;
			this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(359, 222);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Location = new System.Drawing.Point(161, 180);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(75, 23);
			this.btnPrint.TabIndex = 2;
			this.btnPrint.Text = "Print Label";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(106, 38);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(43, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "123456";
			// 
			// txtQty
			// 
			this.txtQty.Location = new System.Drawing.Point(125, 121);
			this.txtQty.Name = "txtQty";
			this.txtQty.Size = new System.Drawing.Size(111, 20);
			this.txtQty.TabIndex = 1;
			this.txtQty.Text = "1";
			this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
			// 
			// txtMarkdownPrice
			// 
			this.txtMarkdownPrice.Location = new System.Drawing.Point(125, 95);
			this.txtMarkdownPrice.Name = "txtMarkdownPrice";
			this.txtMarkdownPrice.Size = new System.Drawing.Size(111, 20);
			this.txtMarkdownPrice.TabIndex = 1;
			this.txtMarkdownPrice.TextChanged += new System.EventHandler(this.txtMarkdownPrice_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 124);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Print Qty";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(106, 98);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "$";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 98);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Markdown Price";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Normal Price";
			// 
			// lblMDBarcode
			// 
			this.lblMDBarcode.AutoSize = true;
			this.lblMDBarcode.Location = new System.Drawing.Point(122, 153);
			this.lblMDBarcode.Name = "lblMDBarcode";
			this.lblMDBarcode.Size = new System.Drawing.Size(43, 13);
			this.lblMDBarcode.TabIndex = 0;
			this.lblMDBarcode.Text = "123456";
			// 
			// lblCode
			// 
			this.lblCode.AutoSize = true;
			this.lblCode.Location = new System.Drawing.Point(106, 16);
			this.lblCode.Name = "lblCode";
			this.lblCode.Size = new System.Drawing.Size(43, 13);
			this.lblCode.TabIndex = 0;
			this.lblCode.Text = "123456";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 153);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(93, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Markdown barode";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Description";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Product Code";
			// 
			// lblUsedBy
			// 
			this.lblUsedBy.AutoSize = true;
			this.lblUsedBy.Location = new System.Drawing.Point(344, 38);
			this.lblUsedBy.Name = "lblUsedBy";
			this.lblUsedBy.Size = new System.Drawing.Size(0, 13);
			this.lblUsedBy.TabIndex = 4;
			// 
			// lblBestBefore
			// 
			this.lblBestBefore.AutoSize = true;
			this.lblBestBefore.Location = new System.Drawing.Point(344, 16);
			this.lblBestBefore.Name = "lblBestBefore";
			this.lblBestBefore.Size = new System.Drawing.Size(0, 13);
			this.lblBestBefore.TabIndex = 5;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(255, 38);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 13);
			this.label11.TabIndex = 6;
			this.label11.Text = "Used By";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(255, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(62, 13);
			this.label12.TabIndex = 7;
			this.label12.Text = "Best Before";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 323);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnScan);
			this.Controls.Add(this.txtBarcode);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "MarkDown Label Print";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtQty;
		private System.Windows.Forms.TextBox txtMarkdownPrice;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblCode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblMDBarcode;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnConfig;
		private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblUsedBy;
        private System.Windows.Forms.Label lblBestBefore;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

