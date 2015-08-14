namespace SalesAndInventorySystemUI.UI
{
    partial class frmInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showAllButton = new System.Windows.Forms.Button();
            this.addToCateButton = new System.Windows.Forms.Button();
            this.resultListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.barCodeTextBox = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.txtSaleQty = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtAvailableQty = new System.Windows.Forms.TextBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.txtPaymentDue = new System.Windows.Forms.TextBox();
            this.txtTotalPayment = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.payment = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.txtTaxAmt = new System.Windows.Forms.TextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.txtTaxPer = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showAllButton);
            this.groupBox1.Controls.Add(this.addToCateButton);
            this.groupBox1.Controls.Add(this.resultListView);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.barCodeTextBox);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.Label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Label11);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.totalPriceTextBox);
            this.groupBox1.Controls.Add(this.discountTextBox);
            this.groupBox1.Controls.Add(this.txtSaleQty);
            this.groupBox1.Controls.Add(this.Label9);
            this.groupBox1.Controls.Add(this.txtAvailableQty);
            this.groupBox1.Location = new System.Drawing.Point(6, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1076, 566);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // showAllButton
            // 
            this.showAllButton.Location = new System.Drawing.Point(985, 79);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(75, 23);
            this.showAllButton.TabIndex = 109;
            this.showAllButton.Text = "Show All";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.showAllButton_Click);
            // 
            // addToCateButton
            // 
            this.addToCateButton.Location = new System.Drawing.Point(873, 79);
            this.addToCateButton.Name = "addToCateButton";
            this.addToCateButton.Size = new System.Drawing.Size(75, 23);
            this.addToCateButton.TabIndex = 108;
            this.addToCateButton.Text = "Add to Cart";
            this.addToCateButton.UseVisualStyleBackColor = true;
            this.addToCateButton.Click += new System.EventHandler(this.addToCateButton_Click);
            // 
            // resultListView
            // 
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader5,
            this.columnHeader6});
            this.resultListView.ContextMenuStrip = this.contextMenuStrip1;
            this.resultListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultListView.FullRowSelect = true;
            this.resultListView.GridLines = true;
            this.resultListView.Location = new System.Drawing.Point(14, 121);
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(1056, 442);
            this.resultListView.TabIndex = 107;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            this.resultListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.resultListView_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Category";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Unit Price";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Size";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Quantity";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 107;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Total Price";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 130;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 106;
            this.label1.Text = "BareCode";
            // 
            // barCodeTextBox
            // 
            this.barCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barCodeTextBox.Location = new System.Drawing.Point(2, 79);
            this.barCodeTextBox.Name = "barCodeTextBox";
            this.barCodeTextBox.Size = new System.Drawing.Size(105, 20);
            this.barCodeTextBox.TabIndex = 0;
            this.barCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.barCodeTextBox.TextChanged += new System.EventHandler(this.barCodeTextBox_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(417, 79);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(113, 20);
            this.txtPrice.TabIndex = 104;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(454, 59);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(35, 17);
            this.Label10.TabIndex = 103;
            this.Label10.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(738, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 102;
            this.label2.Text = "Total Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(631, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 102;
            this.label3.Text = "Discount";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(538, 59);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(57, 17);
            this.Label11.TabIndex = 102;
            this.Label11.Text = "Sale Qty.";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(181, 59);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(87, 17);
            this.Label5.TabIndex = 1;
            this.Label5.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(111, 79);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(229, 20);
            this.txtProductName.TabIndex = 94;
            this.txtProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Location = new System.Drawing.Point(719, 79);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.Size = new System.Drawing.Size(117, 20);
            this.totalPriceTextBox.TabIndex = 96;
            this.totalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // discountTextBox
            // 
            this.discountTextBox.Location = new System.Drawing.Point(614, 79);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.Size = new System.Drawing.Size(96, 20);
            this.discountTextBox.TabIndex = 96;
            this.discountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.discountTextBox.TextChanged += new System.EventHandler(this.discountTextBox_TextChanged);
            // 
            // txtSaleQty
            // 
            this.txtSaleQty.Location = new System.Drawing.Point(535, 79);
            this.txtSaleQty.Name = "txtSaleQty";
            this.txtSaleQty.Size = new System.Drawing.Size(64, 20);
            this.txtSaleQty.TabIndex = 96;
            this.txtSaleQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSaleQty.TextChanged += new System.EventHandler(this.txtSaleQty_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(339, 59);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(81, 17);
            this.Label9.TabIndex = 99;
            this.Label9.Text = "Available Qty";
            // 
            // txtAvailableQty
            // 
            this.txtAvailableQty.Location = new System.Drawing.Point(345, 79);
            this.txtAvailableQty.Name = "txtAvailableQty";
            this.txtAvailableQty.ReadOnly = true;
            this.txtAvailableQty.Size = new System.Drawing.Size(67, 20);
            this.txtAvailableQty.TabIndex = 97;
            this.txtAvailableQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Panel2
            // 
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.clearAllButton);
            this.Panel2.Controls.Add(this.saveButton);
            this.Panel2.Controls.Add(this.txtPaymentDue);
            this.Panel2.Controls.Add(this.txtTotalPayment);
            this.Panel2.Controls.Add(this.Label19);
            this.Panel2.Controls.Add(this.payment);
            this.Panel2.Controls.Add(this.txtTotal);
            this.Panel2.Controls.Add(this.Label16);
            this.Panel2.Controls.Add(this.txtTaxAmt);
            this.Panel2.Controls.Add(this.Label24);
            this.Panel2.Controls.Add(this.txtTaxPer);
            this.Panel2.Controls.Add(this.Label15);
            this.Panel2.Controls.Add(this.txtSubTotal);
            this.Panel2.Controls.Add(this.Label14);
            this.Panel2.Location = new System.Drawing.Point(1088, 250);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(271, 442);
            this.Panel2.TabIndex = 110;
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(10, 414);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(75, 23);
            this.clearAllButton.TabIndex = 100;
            this.clearAllButton.Text = "Clear All";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(105, 251);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(81, 23);
            this.saveButton.TabIndex = 99;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // txtPaymentDue
            // 
            this.txtPaymentDue.Location = new System.Drawing.Point(105, 154);
            this.txtPaymentDue.Name = "txtPaymentDue";
            this.txtPaymentDue.ReadOnly = true;
            this.txtPaymentDue.Size = new System.Drawing.Size(81, 20);
            this.txtPaymentDue.TabIndex = 98;
            this.txtPaymentDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPayment
            // 
            this.txtTotalPayment.Location = new System.Drawing.Point(105, 120);
            this.txtTotalPayment.Name = "txtTotalPayment";
            this.txtTotalPayment.Size = new System.Drawing.Size(81, 20);
            this.txtTotalPayment.TabIndex = 1;
            this.txtTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPayment.TextChanged += new System.EventHandler(this.txtTotalPayment_TextChanged);
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(7, 159);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(46, 17);
            this.Label19.TabIndex = 96;
            this.Label19.Text = "Return";
            // 
            // payment
            // 
            this.payment.AutoSize = true;
            this.payment.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment.Location = new System.Drawing.Point(7, 120);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(89, 17);
            this.payment.TabIndex = 95;
            this.payment.Text = "Total Payment";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(105, 82);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(81, 20);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(8, 83);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(75, 17);
            this.Label16.TabIndex = 94;
            this.Label16.Text = "Grand Total";
            // 
            // txtTaxAmt
            // 
            this.txtTaxAmt.Location = new System.Drawing.Point(161, 47);
            this.txtTaxAmt.Name = "txtTaxAmt";
            this.txtTaxAmt.ReadOnly = true;
            this.txtTaxAmt.Size = new System.Drawing.Size(80, 20);
            this.txtTaxAmt.TabIndex = 2;
            this.txtTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.BackColor = System.Drawing.Color.White;
            this.Label24.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(136, 47);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(23, 21);
            this.Label24.TabIndex = 92;
            this.Label24.Text = "%";
            // 
            // txtTaxPer
            // 
            this.txtTaxPer.Location = new System.Drawing.Point(77, 48);
            this.txtTaxPer.Name = "txtTaxPer";
            this.txtTaxPer.Size = new System.Drawing.Size(52, 20);
            this.txtTaxPer.TabIndex = 0;
            this.txtTaxPer.Text = "0";
            this.txtTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTaxPer.TextChanged += new System.EventHandler(this.txtTaxPer_TextChanged);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(8, 50);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(55, 17);
            this.Label15.TabIndex = 90;
            this.Label15.Text = "VAT+ST";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(75, 13);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(184, 20);
            this.txtSubTotal.TabIndex = 7;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(8, 16);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(61, 17);
            this.Label14.TabIndex = 77;
            this.Label14.Text = "Sub Total";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::SalesAndInventorySystemUI.Properties.Resources.cancelButton1;
            this.button1.Location = new System.Drawing.Point(1315, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 28);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Discount";
            this.columnHeader1.Width = 86;
            // 
            // frmInvoice
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInvoice";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtProductName;
        internal System.Windows.Forms.TextBox txtSaleQty;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtAvailableQty;
        internal System.Windows.Forms.TextBox txtPrice;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox barCodeTextBox;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.Button addToCateButton;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TextBox txtPaymentDue;
        internal System.Windows.Forms.TextBox txtTotalPayment;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label payment;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox txtTaxAmt;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.TextBox txtTaxPer;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox txtSubTotal;
        internal System.Windows.Forms.Label Label14;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}