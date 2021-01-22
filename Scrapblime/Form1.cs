using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrapblime
{
    public partial class Form1 : Form
    {
        int mov, x, y;
        public Form1()
        {
            InitializeComponent();
            saveAsAnItem.Click += SaveAsAnItem_Click;
            saveItem.Click += SaveItem_Click;
            openItem.Click += OpenItem_Click;
            
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text |*.txt";
            openFileDialog.FileName = "default.txt";
            openFileDialog.Title = "Abrir";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Não pegou o arquivo, por isso ele n vai conseguir ler nada
                //var result = System.IO.File.ReadAllText();
            }
        }

        private async void SaveItem_Click(object sender, EventArgs e)
        {
            
        }

        private async void SaveAsAnItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text |*.txt";
            saveFileDialog1.Title = "Salvar";
            saveFileDialog1.FileName = "default.txt";
            var content = GetContent();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileToSave = saveFileDialog1.FileName;

                System.IO.File.WriteAllText(fileToSave, content);
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
