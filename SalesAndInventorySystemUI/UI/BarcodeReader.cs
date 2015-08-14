using System;
using System.Drawing;
using System.Windows.Forms;
using BarcodeLib;

namespace SalesAndInventorySystemUI.UI
{
    public partial class BarcodeReader : Form
    {
        Barcode barcodeLib=new Barcode();
        public BarcodeReader()
        {
            InitializeComponent();
        }

        private void BarcodeReader_Load(object sender, EventArgs e)
        {
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int width = Convert.ToInt32(txtWidth.Text.Trim());
            int height = Convert.ToInt32(txtHeight.Text.Trim());
            barcodeLib.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

            try
            {
                barcodeLib.IncludeLabel = true;
                barcodeLib.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                barcode.BackgroundImage = barcodeLib.Encode(type, txtData.Text.Trim(), Color.Black, Color.White, width,
                    height);
                txtEncoded.Text = barcodeLib.EncodedValue;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbRotateFlip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbBarcodeAlign_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnForeColor_Click(object sender, EventArgs e)
        {

        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {

        }

        private void chkGenerateLabel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
               sfd.Filter = "BMP (*.bmp)|*.bmp";
                sfd.FilterIndex = 1;
                sfd.AddExtension = true;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BarcodeLib.SaveTypes saveTypes = BarcodeLib.SaveTypes.BMP;
                    barcodeLib.SaveImage(sfd.FileName, saveTypes);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        
    }
}
