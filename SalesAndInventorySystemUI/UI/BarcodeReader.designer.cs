namespace SalesAndInventorySystemUI.UI
{
    partial class BarcodeReader
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeReader));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveXML = new System.Windows.Forms.Button();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.txtEncoded = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEncodingTime = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.barcode = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(81, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 46);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "&Save As";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.Location = new System.Drawing.Point(166, 283);
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Size = new System.Drawing.Size(77, 23);
            this.btnSaveXML.TabIndex = 71;
            this.btnSaveXML.Text = "Save &XML";
            this.btnSaveXML.UseVisualStyleBackColor = true;
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Location = new System.Drawing.Point(166, 306);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(77, 23);
            this.btnLoadXML.TabIndex = 72;
            this.btnLoadXML.Text = "Load XML";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(7, 283);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(69, 46);
            this.btnEncode.TabIndex = 60;
            this.btnEncode.Text = "&Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // txtEncoded
            // 
            this.txtEncoded.Location = new System.Drawing.Point(7, 141);
            this.txtEncoded.Multiline = true;
            this.txtEncoded.Name = "txtEncoded";
            this.txtEncoded.ReadOnly = true;
            this.txtEncoded.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEncoded.Size = new System.Drawing.Size(238, 36);
            this.txtEncoded.TabIndex = 62;
            this.txtEncoded.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Encoded Value";
            // 
            // lblEncodingTime
            // 
            this.lblEncodingTime.AutoSize = true;
            this.lblEncodingTime.Location = new System.Drawing.Point(83, 222);
            this.lblEncodingTime.Name = "lblEncodingTime";
            this.lblEncodingTime.Size = new System.Drawing.Size(0, 13);
            this.lblEncodingTime.TabIndex = 70;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(7, 24);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(194, 20);
            this.txtData.TabIndex = 58;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // barcode
            // 
            this.barcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.barcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcode.Location = new System.Drawing.Point(0, 0);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(503, 371);
            this.barcode.TabIndex = 36;
            this.barcode.TabStop = false;
            this.barcode.Text = "Barcode Image";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveXML);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadXML);
            this.splitContainer1.Panel1.Controls.Add(this.btnEncode);
            this.splitContainer1.Panel1.Controls.Add(this.txtEncoded);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblEncodingTime);
            this.splitContainer1.Panel1.Controls.Add(this.txtData);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.barcode);
            this.splitContainer1.Size = new System.Drawing.Size(757, 371);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 39;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtWidth);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtHeight);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(12, 63);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(231, 49);
            this.groupBox4.TabIndex = 78;
            this.groupBox4.TabStop = false;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(54, 21);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(41, 20);
            this.txtWidth.TabIndex = 43;
            this.txtWidth.Text = "300";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Height";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(181, 20);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(49, 20);
            this.txtHeight.TabIndex = 44;
            this.txtHeight.Text = "150";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Value to Encode";
            // 
            // BarcodeReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(757, 371);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BarcodeReader";
            this.Text = "Barcode Generator";
            this.Load += new System.EventHandler(this.BarcodeReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveXML;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.TextBox txtEncoded;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEncodingTime;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox barcode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label9;

    }
}

