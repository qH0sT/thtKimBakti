using Gecko;
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
namespace thtKimBakti
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            geckoWebBrowser1.Navigate("https://www.turkhackteam.org/#login");    
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Başarılı bir şekilde giriş yaptım.","Giriş",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
