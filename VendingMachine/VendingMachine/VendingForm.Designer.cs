namespace VendingMachine
{
    partial class VendingForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grpButton = new System.Windows.Forms.GroupBox();
            this.cmbMoney = new System.Windows.Forms.ComboBox();
            this.btnPut = new System.Windows.Forms.Button();
            this.grpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "サイダー";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "お茶";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(274, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "コーラ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // grpButton
            // 
            this.grpButton.Controls.Add(this.button3);
            this.grpButton.Controls.Add(this.button1);
            this.grpButton.Controls.Add(this.button2);
            this.grpButton.Location = new System.Drawing.Point(12, 32);
            this.grpButton.Name = "grpButton";
            this.grpButton.Size = new System.Drawing.Size(440, 178);
            this.grpButton.TabIndex = 3;
            this.grpButton.TabStop = false;
            // 
            // cmbMoney
            // 
            this.cmbMoney.FormattingEnabled = true;
            this.cmbMoney.Location = new System.Drawing.Point(211, 292);
            this.cmbMoney.Name = "cmbMoney";
            this.cmbMoney.Size = new System.Drawing.Size(121, 23);
            this.cmbMoney.TabIndex = 4;
            // 
            // btnPut
            // 
            this.btnPut.Location = new System.Drawing.Point(367, 292);
            this.btnPut.Name = "btnPut";
            this.btnPut.Size = new System.Drawing.Size(85, 46);
            this.btnPut.TabIndex = 3;
            this.btnPut.Text = "入金";
            this.btnPut.UseVisualStyleBackColor = true;
            // 
            // VendingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 422);
            this.Controls.Add(this.btnPut);
            this.Controls.Add(this.cmbMoney);
            this.Controls.Add(this.grpButton);
            this.Name = "VendingForm";
            this.Text = "Form1";
            this.grpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox grpButton;
        private System.Windows.Forms.ComboBox cmbMoney;
        private System.Windows.Forms.Button btnPut;
    }
}

