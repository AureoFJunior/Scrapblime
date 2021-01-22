using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Scrapblime
{
    public partial class helpForm : Form
    {
        public helpForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            var a = new ProcessStartInfo(@"https://github.com/AureoFJunior");
            a.UseShellExecute = true;
            a.Verb = "open";
            Process.Start(a); 
            //Hi stranger! if you are here, maybe should consider a star in my profile or maybe a contact too!
        }
    }
}
