using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;
using Font = System.Drawing.Font;

namespace SalesAndInventorySystemUI.UI
{
    public partial class frmInvoice : Form
    {
        ProductGateway productGateway=new ProductGateway();
        CategoryGateway categoryGateway=new CategoryGateway();
        CompanyGateway companyGateway=new CompanyGateway();
        InvoiceGateway invoiceGateway = new InvoiceGateway();
        List<Product> byeProducts=new List<Product>();
        private Product product = null;
        private int invoiceID = 0;
        private int serialNo = 0;
        private StreamReader reader;
        private Font verdana10Font;

        //public delegate void AddressUpdateHandler(object sender, AddressUpdateEventArgs e);

        // add an event of the delegate type
        //public event AddressUpdateHandler AddressUpdated;


        public frmInvoice()
        {
            InitializeComponent();
            
        }

        private void Subscribe(frmProductsRecord form2)
        {
            form2.dataSender += new frmProductsRecord.DataSender(GetDataFromForm2);
        }

        private void GetDataFromForm2(Product aNewProduct)
        {
            if (aNewProduct != null)
            {
                txtProductName.Text = aNewProduct.ProductName;
                txtAvailableQty.Text = aNewProduct.Quantity.ToString();
                txtSaleQty.Text = "1";
                discountTextBox.Text = aNewProduct.Discount.ToString();
                txtPrice.Text = aNewProduct.Price.ToString();
                totalPriceTextBox.Text = (aNewProduct.Price - (aNewProduct.Price * aNewProduct.Discount / 100)).ToString();
                barCodeTextBox.Text = aNewProduct.BarCode;
            }
        }

        

        public frmInvoice(Product product): this()
        {
            this.product = product;
            if (product != null)
            {
                txtProductName.Text = product.ProductName;
                txtAvailableQty.Text = product.Quantity.ToString();
                txtSaleQty.Text = "1";
                discountTextBox.Text = product.Discount.ToString();
                txtPrice.Text = product.Price.ToString();
                totalPriceTextBox.Text = (product.Price - (product.Price * product.Discount / 100)).ToString();
                barCodeTextBox.Text = product.BarCode;
                addToCateButton.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void barCodeTextBox_TextChanged(object sender, EventArgs e)
       {
            string barCode = barCodeTextBox.Text;
            if (barCode!=string.Empty)
            {
                product = productGateway.GetDataBarCode(barCode);
                if (product==null)
                {
                    Reset();
                    return;
                }
                product.Category = categoryGateway.GetCategoryByID(product.CategoryID);
                if (product.Category==null)
                {
                    //Reset();
                    return;
                }
                
                product.Category.PersonType = companyGateway.GetCompaniesByID(product.Category.CompanyID);
                if (product!=null)
                {
                    txtProductName.Text = product.ProductName;
                    txtAvailableQty.Text = product.Quantity.ToString();
                    txtSaleQty.Text = "1";
                    discountTextBox.Text = product.Discount.ToString();
                    txtPrice.Text = product.Price.ToString();
                    //if ()
                    //{
                        
                    //}
                    totalPriceTextBox.Text = (product.Price - (product.Price * product.Discount/100)).ToString();
                    addToCateButton.PerformClick();
                }
                else
                {
                    Reset();
                }
                
            }
            else
            {
                Reset();
            }
            
        }

        private void Reset()
        {
            txtProductName.Text = string.Empty;
            txtAvailableQty.Text = string.Empty;
            txtSaleQty.Text = string.Empty;
            txtPrice.Text = string.Empty;
            barCodeTextBox.Text = string.Empty;
            totalPriceTextBox.Text = string.Empty;
            discountTextBox.Text=String.Empty;

        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height-10;
            this.Location = new Point(0, 0);
            //resultListView.Width = w - 40;
            Size = Screen.PrimaryScreen.WorkingArea.Size;

            MaximizeBox = true;




            //this.WindowState = FormWindowState.Maximized;
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //Size = new Size(w, h-10);
            //MaximizeBox = false;
        }

        private void txtSaleQty_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            double val3 = 0;
            int.TryParse(txtPrice.Text, out val1);
            int.TryParse(txtSaleQty.Text, out val2);
            double.TryParse(discountTextBox.Text, out val3);
            int I = (val1 * val2);
            totalPriceTextBox.Text = (I - (I* val3/100) ).ToString();
        }

        private void addToCateButton_Click(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtSaleQty.Text, out val1);
            int.TryParse(txtAvailableQty.Text, out val2);
            if (product!=null && Convert.ToInt32(val1)>0 && Convert.ToInt32(val2)>0 )
            {
                if (resultListView.Items.Count == 0 && CheckProductQuantity() == true)
                {
                    ListViewItem item = new ListViewItem(product.ProductName);
                    item.Tag = product;
                    //item.SubItems.Add(product.ProductName);
                    item.SubItems.Add(product.Category.PersonType.Name);
                    item.SubItems.Add(txtPrice.Text);
                    item.SubItems.Add(discountTextBox.Text);
                    item.SubItems.Add(product.Size);
                    item.SubItems.Add(txtSaleQty.Text);
                    item.SubItems.Add(totalPriceTextBox.Text);
                    //+ (Double.Parse(discountTextBox.Text) *
                    resultListView.Items.Add(item);
                    txtSubTotal.Text = subtot().ToString();
                    if (txtTaxPer.Text != "")
                    {
                        txtTaxAmt.Text = Convert.ToInt32((Convert.ToDouble(txtSubTotal.Text) * Convert.ToDouble(txtTaxPer.Text) / 100)).ToString();
                        txtTotal.Text = (Convert.ToInt32(txtSubTotal.Text) + Convert.ToInt32(txtTaxAmt.Text)).ToString();
                    }
                    barCodeTextBox.Focus();
                    Reset();
                    serialNo++;
                    return;
                }
                

                for (int i = 0; i < resultListView.Items.Count; i++)
                {
                    //var a = Convert.ToInt32(resultListView.Items[i].SubItems[4].Text);
                    if (resultListView.Items[i].SubItems[0].Text==product.ProductName  )
                    {
                        if (Convert.ToInt32(resultListView.Items[i].SubItems[5].Text) + Convert.ToInt32(txtSaleQty.Text) <= Convert.ToInt32(txtAvailableQty.Text))
                        {
                            int x = (Convert.ToInt32(resultListView.Items[i].SubItems[5].Text) + Convert.ToInt32(txtSaleQty.Text));
                            resultListView.Items[i].SubItems[5].Text = x.ToString();
                            resultListView.Items[i].SubItems[6].Text =(double.Parse(resultListView.Items[i].SubItems[6].Text) + Double.Parse(totalPriceTextBox.Text)).ToString();
                            txtSubTotal.Text = subtot().ToString();
                            if (txtTaxPer.Text != "")
                            {
                                txtTaxAmt.Text = Convert.ToInt32((Convert.ToDouble(txtSubTotal.Text) * Convert.ToDouble(txtTaxPer.Text) / 100)).ToString();
                                txtTotal.Text = (Convert.ToInt32(txtSubTotal.Text) + Convert.ToInt32(txtTaxAmt.Text)).ToString();
                            }
                            txtTotal.Text = (Convert.ToInt32(txtSubTotal.Text) + Convert.ToInt32(txtTaxAmt.Text)).ToString();
                            barCodeTextBox.Focus();
                            Reset();
                            return;
                        }
                        else
                        {
                            barCodeTextBox.Focus();
                            Reset();
                            MessageBox.Show("Not available more than stock quantity");
                            return;
                        }
                        
                    }
                }
                if (CheckProductQuantity())
                {
                    ListViewItem aItem = new ListViewItem(product.ProductName);
                    aItem.Tag = product;
                    //aItem.SubItems.Add(product.ProductName);
                    aItem.SubItems.Add(product.Category.PersonType.Name);
                    aItem.SubItems.Add(product.Price.ToString());
                    aItem.SubItems.Add(product.Discount.ToString());
                    aItem.SubItems.Add(product.Size);
                    aItem.SubItems.Add(txtSaleQty.Text);
                    aItem.SubItems.Add(totalPriceTextBox.Text);
                    resultListView.Items.Add(aItem);
                    txtSubTotal.Text = subtot().ToString();
                    if (txtTaxPer.Text != "")
                    {
                        txtTaxAmt.Text = Convert.ToInt32((Convert.ToDouble(txtSubTotal.Text) * Convert.ToDouble(txtTaxPer.Text) / 100)).ToString();
                        txtTotal.Text = (Convert.ToInt32(txtSubTotal.Text) + Convert.ToInt32(txtTaxAmt.Text)).ToString();
                    }
                    barCodeTextBox.Focus();
                    Reset();
                    serialNo++;
                    return;
                }
            }
            else
            {
                barCodeTextBox.Focus();
            }
        }

        private bool CheckProductQuantity()
        {
            if (int.Parse(txtAvailableQty.Text)>=int.Parse(txtSaleQty.Text))
            {
                return true;
            }
            return false;
        }


        public double subtot()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            try
            {
                j = resultListView.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToInt32(resultListView.Items[i].SubItems[6].Text);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }

        private void txtTotalPayment_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int I = 0;
            int.TryParse(txtTotal.Text, out val1);
            int.TryParse(txtTotalPayment.Text, out val2);
            if (val2 >= val1)
            {
               I = (val2 - val1);
            }
            txtPaymentDue.Text = I.ToString();
        }

        private void txtTaxPer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTaxPer.Text))
                {
                    txtTaxAmt.Text = "";
                    txtTotal.Text = "";
                    return;
                }
                txtTaxAmt.Text = Convert.ToInt32((Convert.ToInt32(txtSubTotal.Text) * Convert.ToDouble(txtTaxPer.Text) / 100)).ToString();
                txtTotal.Text = (Convert.ToInt32(txtSubTotal.Text) + Convert.ToInt32(txtTaxAmt.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CreatePDF(Invoice invoice, List<Product>productsList)
        {
            try
            {
                string shopName = "RICEMAN LUBNAN";
                string address = "Shop#100, Comila Sadar, Comila, Dhaka, Bangladesh-1200";

                iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font font8B = iTextSharp.text.FontFactory.GetFont("Arial", 08, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font font08 = iTextSharp.text.FontFactory.GetFont("Arial", 08, iTextSharp.text.Font.NORMAL);



                var pgSize = new iTextSharp.text.Rectangle(288, 700);
                var doc = new iTextSharp.text.Document(pgSize, 0, 0, 0, 0);
                //Document doc1 = new Document(iTextSharp.text.PageSize.A5, 10, 10, 0, 35);
                PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream(@"D:\abc.pdf", FileMode.OpenOrCreate));
                doc.Open();
                doc.Add(new Paragraph("\n\n"));
                Paragraph p = new Paragraph(shopName, font10) { SpacingBefore = 0 };
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);
                doc.Add(new Paragraph(address, font08) { SpacingAfter = 0, IndentationLeft = 30, IndentationRight = 30, Alignment = 1, PaddingTop = 0 });
                doc.Add(new Paragraph("------------------------------------------------------------------") { SpacingAfter = 0, IndentationLeft = 10, IndentationRight = 10, Alignment = 1, PaddingTop = 0 });
                //1st table
                PdfPTable table = new PdfPTable(2);
                PdfPCell cell = new PdfPCell(new Phrase("Date : " + DateTime.Now.ToString("dd-MM-yyyy"), font08)) { HorizontalAlignment = 0, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Time : " + DateTime.Now.ToString("HH:mm:ss tt"), font08)) { HorizontalAlignment = 2, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Name :", font08)) { HorizontalAlignment = 0, Border = 0, Colspan = 2 };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Invoice : "+ invoice.InvoiceNo, font08)) { HorizontalAlignment = 1, Border = 0, Colspan = 2 };
                table.AddCell(cell);
                doc.Add(table);
                //2nd table 
                int[] width = new int[] { 100, 20, 50, 25, 25, 60 };
                table = new PdfPTable(6) { WidthPercentage = 96 };
                table.SetWidths(width);
                cell = new PdfPCell(new Phrase("Itams", font8B)) { HorizontalAlignment = 0, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 1 };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Qty", font8B)) { HorizontalAlignment = 0, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 1 };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Price", font8B)) { HorizontalAlignment = 0, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 1 };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Dis%", font8B)) { HorizontalAlignment = 0, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 1 };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Vat%", font8B)) { HorizontalAlignment = 0, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 1 };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Total", font8B)) { HorizontalAlignment = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 1 };
                table.AddCell(cell);
                doc.Add(table);
                table=new PdfPTable(6){WidthPercentage = 96};
                table.SetWidths(width);
                foreach (Product product1 in productsList)
                {
                    cell = new PdfPCell(new Phrase(product1.ProductName, font8B)) { HorizontalAlignment = 0, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 };
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(product1.Quantity.ToString(), font8B)) { HorizontalAlignment = 0, Border = 0};
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(product1.Price.ToString(), font8B)) { HorizontalAlignment = 0, Border = 0};
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Dis%", font8B)) { HorizontalAlignment = 0, Border = 0};
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Vat%", font8B)) { HorizontalAlignment = 0, Border = 0};
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(product1.Price.ToString(), font8B)) { HorizontalAlignment = 2, Border = 0};
                    table.AddCell(cell);
                    
                }

                doc.Add(table);
                doc.Add(new Paragraph("abcsa hhiokp hutyf giuy9urtf jguydrtjoj jgiuyf hiuyhyudt jgyufyuj[p dtydyhk fygy"));
                doc.Close();

            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }

        

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<Product> productsList = GetAllProductONListView();
                if (productsList.Count==0)
                {
                    return;
                }
                int i = 1;
               // StreamWriter sw = null;

                //sw = new StreamWriter("D://Print//Summary.txt", false );
                //sw.
                
                
                string invoiceNo = getInvoiceNo();
                Invoice invoice = new Invoice() { InvoiceID = invoiceID, InvoiceNo = invoiceNo, vat = Convert.ToDouble(txtTaxPer.Text), CostPrice = Convert.ToDouble(txtSubTotal.Text), InvoiceDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy")), Due = Convert.ToDouble(txtPaymentDue.Text), TotalPrice = Convert.ToDouble(txtTotal.Text)};



                if (invoiceGateway.AddInvoice(invoice, productsList))
                {
                    //sw.Write("MONGOL BAROTA" + "\t" + invoice.InvoiceNo + Environment.NewLine + "COMILLA" + "\t\t" + DateTime.Now.ToString("dd-MM-yyyy") + Environment.NewLine + Environment.NewLine);
                    //sw.Write("{0,2}{1,20}{2,5}{3,6}{4,7}{5,0}", "SL", "Name", "Qty","Size", "Price", Environment.NewLine);
                    //sw.Write(Environment.NewLine+Environment.NewLine);
                    //foreach (Product product1 in productsList)
                    //{
                    //    sw.Write("{0,2}{1,20}{2,5}{3,6}{4,7}{5,0}", i, product1.ProductName, product1.Quantity,product1.Size.ToString(), product1.Price.ToString(), Environment.NewLine);
                    //    i++;
                    //}
                    //sw.Write("{0,0}{1,0}{2,0}{3,24}{4,10}", Environment.NewLine, "-----------------------------------", Environment.NewLine, "Total", invoice.CostPrice);
                    //sw.Write("{0,0}{1,24}{2,10}",  Environment.NewLine, "Vat", invoice.vat);
                    //sw.Write("{0,0}{1,24}{2,10}",  Environment.NewLine, "Due", invoice.Due);
                    //sw.Write("{0,0}{1,0}{2,0}{3,24}{4,10}", Environment.NewLine, "-----------------------------------", Environment.NewLine, "Total", invoice.TotalPrice);

                    
                    //sw.WriteLine();
                    //sw.Close();
                    //PrintPage();
                    CreatePDF(invoice,productsList);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void PrintPage()
        {
            ProcessStartInfo info = new ProcessStartInfo("D://print//Summary.txt");
            info.Verb = "Print";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.UseShellExecute = true;
            Process p=new Process();
            p.StartInfo = info;
            p.Start();
            //Process.Start(info);
        }
        

        private string getInvoiceNo()
        {
            try
            {
                return "INV" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            
        }

        private List<Product> GetAllProductONListView()
        {
            List<Product> allProducts=new List<Product>();
            try
            {
                if (resultListView.Items.Count>0)
                {
                    for (int i = 0; i < resultListView.Items.Count; i++)
                    {
                        ListViewItem item = resultListView.Items[i];
                        Product newProduct = (Product)item.Tag;
                        Product aProduct = new Product() { ProductID = newProduct.ProductID, ProductName = newProduct.ProductName, BarCode = newProduct.BarCode, CategoryID = newProduct.CategoryID, Description = newProduct.Description, InsertDate = newProduct.InsertDate, UpdateDate = newProduct.UpdateDate, Price = Convert.ToDouble(resultListView.Items[i].SubItems[6].Text), Quantity = Convert.ToInt32(resultListView.Items[i].SubItems[5].Text), Size = resultListView.Items[i].SubItems[4].Text, Discount = Convert.ToDouble(resultListView.Items[i].SubItems[3].Text) };
                        allProducts.Add(aProduct);
                    }
                }
                return allProducts;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private void resultListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Product selectProduct = GetSelectedProduct();
            //frmInvoice frmInvoice=new frmInvoice(selectProduct);

        }


        private Product GetSelectedProduct()
        {
            int index = resultListView.SelectedIndices[0];
            ListViewItem item = resultListView.Items[index];
            return (Product)item.Tag;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            serialNo = 0;

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            removeToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product selectProduct = GetSelectedProduct();
            int selectedIndex = resultListView.SelectedIndices[0];
            ListViewItem item = resultListView.Items[selectedIndex];
            int x= int.Parse(item.SubItems[4].Text);
            resultListView.Items.RemoveAt(selectedIndex);
            txtSubTotal.Text =(double.Parse(txtSubTotal.Text) - (selectProduct.Price*x)).ToString();
            txtTotal.Text = (double.Parse(txtTotal.Text) - selectProduct.Price * x).ToString();
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            frmProductsRecord productsRecord = new frmProductsRecord();
            //productsRecord.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
            Subscribe(productsRecord);
            productsRecord.Show();
           // Hide();
        }

        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void discountTextBox_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtPrice.Text, out val1);
            int.TryParse(discountTextBox.Text, out val2);
            int I = (val1 * val2)/100;
            totalPriceTextBox.Text =(val1- I).ToString();
        }

        
    }
}
