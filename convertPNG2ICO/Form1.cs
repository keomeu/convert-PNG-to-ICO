using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace convertPNG2ICO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string pngFilePath = "";
        string icoFileName = "";

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Please select a PNG file";
            //dialog.InitialDirectory = "D:\\";       
            dialog.Filter = "PNG File(*.png)|*.png";
            dialog.ShowHelp = false;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pngFilePath = dialog.FileName;
            }
            if (File.Exists(pngFilePath))
            {
                this.textBox1.Text = pngFilePath;
                string fileName = Path.GetFileNameWithoutExtension(pngFilePath);
                icoFileName = fileName + ".ico";
                string filePath = Path.GetDirectoryName(pngFilePath);
                this.textBox2.Text = filePath + "\\" + icoFileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(this.textBox1.TextLength<1)
            {
                MessageBox.Show("Please fill in the PNG first");
                return;
            }
            this.textBox2.Text = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.SelectedPath + "\\" + icoFileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pngFile = this.textBox1.Text;
            string icoFile = this.textBox2.Text;
            if(pngFile.Length<1 || icoFile.Length<1)
            {
                MessageBox.Show("Please fill in the PNG and ICO file first");
                return;
            }
            if (File.Exists(pngFile))
            {
                if (File.Exists(icoFile)) { File.Delete(icoFile); }
                bool isSuccess = FileHelper.ConvertPNGToIcon(pngFile, icoFile);
                if (isSuccess)
                {
                    MessageBox.Show("Convert Successful ! ");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
