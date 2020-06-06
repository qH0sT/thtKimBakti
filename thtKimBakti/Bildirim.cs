using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace thtKimBakti   //Matkap's
{
    public partial class Bildirim : Form
    {
        SoundPlayer sp;
        public Bildirim(string rumuz, bool sesli_mi, int top)
        {
            InitializeComponent();
            Screen ekran = Screen.FromPoint(Location);
            Location = new Point(ekran.WorkingArea.Right - Width, ekran.WorkingArea.Bottom - Height - top);
            if (sesli_mi == true) { sp = new SoundPlayer("notify.wav"); sp.Play(); }
            label2.Text = rumuz;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Alarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp != null) { sp.Stop(); sp.Dispose(); }
        }
    }
}