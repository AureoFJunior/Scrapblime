using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Scrapblime
{
    public partial class Form1 : Form
    {

        int mov, x, y;
        private String mPath = String.Empty;
        public Form1()
        {
            InitializeComponent();
            saveAsAnItem.Click += SaveAsAnItem_Click;
            saveItem.Click += SaveItem_Click;
            openItem.Click += OpenItem_Click;
            newItem.Click += NewItem_Click;
            helpItem.Click += HelpItem_Click;
            
        }

        private void HelpItem_Click(object sender, EventArgs e)
        {
            helpForm newSc = new helpForm();
            newSc.ShowDialog();
        }

        private void NewItem_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.Show();
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text |*.txt|Imagem |*.png";
            openFileDialog.FileName = "default.txt";
            openFileDialog.Title = "Abrir";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mPath = openFileDialog.FileName;
                var  a  = new FileInfo(mPath);
                var b = a.Extension;

                if (b == ".png" || b == ".rtf")
                {
                    OpenFileDialog openFileDialog2 = new OpenFileDialog();
                    openFileDialog2.Filter = "PNG | *.png | JPEG *.jpeg";

                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        Clipboard.SetImage(Image.FromFile(openFileDialog2.FileName));
                        richTextBox1.Paste();
                    }
                    var file = File.Open(openFileDialog.FileName, System.IO.FileMode.Open);
                //
                var str = new StreamReader(file);
                var result = str.ReadToEnd();
                //
                str.Close();
                richTextBox1.Text = result.ToString();
            }
            
            }
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(mPath))
            {
                SalvarArquivoComo();
            }
            else
            {
                SalvarArquivo(mPath);
            }
            
            
        }

        private void SaveAsAnItem_Click(object sender, EventArgs e)
        {
            SalvarArquivoComo();
        }

        private void SalvarArquivo(String path)
        {
            var content = GetContent();
            mPath = path;
            File.WriteAllText(path, content);
        }

        private void SalvarArquivoComo()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text |*.txt";
            saveFileDialog1.Title = "Salvar";
            saveFileDialog1.FileName = "default.txt";
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileToSave = saveFileDialog1.FileName;
                SalvarArquivo(fileToSave);
                
            }
        }



        private String GetContent()
        {
            var contTex = richTextBox1.Text;
            return contTex;
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            x = e.X;
            y = e.Y;
        }


    }
}
