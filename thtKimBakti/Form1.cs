using Gecko;
using System;
using System.Net;
using System.Windows.Forms;                      // KÜKREYEN ŞU GÖKYÜZÜNDE KUŞUN KİLİTLİ KAFESİ!!!!!!!!!!!!

namespace thtKimBakti
{
    public partial class Form1 : Form  // AHU-YU FELEK MUM BEN ŞAMDAN DÜŞMEZ KALKMAZ BİR ALLAH'TIR UYAN, UYAN!!!!
    {
        public Form1()
        {
            // YAŞASIN MODİFİYE (:  https://www.youtube.com/watch?v=LQNq7uuk-PM   (Matkap's Special)
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Xpcom.Initialize("Firefox");
            new Giris().ShowDialog();
            textBox2.Text = System.IO.File.ReadAllText("link.data");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("link.data",textBox2.Text);
            label7.Text = "Çalışıyor.";
            fren = false;
            label5.Text = "yükleniyor..";
            timer1.Interval = 60000 * ((int)numericUpDown1.Value);
            geckoWebBrowser1.Navigate(textBox2.Text);
            timer1.Enabled = true;
        }
        WebClient wc = new WebClient();
        bool fren = false;
        string temp = "";
        int toP = 10;
        private void geckoWebBrowser1_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            if (fren == false)
            {
                fren = true;
                label5.Text = "yüklendi.";
                foreach(var profilePicture  in geckoWebBrowser1.Document.GetElementsByTagName("img"))
                {
                    if (profilePicture.GetAttribute("alt") == "Avatar")
                    {
                        wc.Headers.Add("user-agent","other");
                        wc.DownloadFile(profilePicture.GetAttribute("src"), "temp.gif");
                        pictureBox1.ImageLocation = "temp.gif";
                        break;
                    }
                }
                
                foreach (var nik in geckoWebBrowser1.Document.GetElementsByTagName("h1"))
                {
                    if (nik.GetAttribute("class").Contains("member-h1"))
                    {
                        label2.Text = "Rumuz" + Environment.NewLine +  nik.TextContent;
                        break;
                    }
                }
                foreach (var kidem in geckoWebBrowser1.Document.GetElementsByTagName("h2"))
                {
                    if (kidem.GetAttribute("class").Contains("member-h2"))
                    {
                        label3.Text = "Kıdem" + Environment.NewLine + kidem.TextContent;
                        break;
                    }
                }
                if (textBox1.Text != "")
                {
                    foreach (var lastVisitors in geckoWebBrowser1.Document.GetElementsByTagName("div"))
                    {
                        if (lastVisitors.GetAttribute("class") == "s-last-visitors-x")
                        {
                            var span = lastVisitors.GetElementsByTagName("span")[0];
                            temp += span.TextContent + Environment.NewLine;                            
                            if (textBox1.Text.Contains(span.TextContent) == false)
                            {
                                new Bildirim(span.TextContent, false, (toP)).Show();
                                toP += 225;
                                //MessageBox.Show(span.TextContent);
                            }
                            
                        }
                    }
                    textBox1.Text = temp;
                    temp = "";
                    toP = 223;
                }
                else
                {
                    foreach (var lastVisitors in geckoWebBrowser1.Document.GetElementsByTagName("div"))
                    {
                        if (lastVisitors.GetAttribute("class") == "s-last-visitors-x")
                        {
                            var span = lastVisitors.GetElementsByTagName("span")[0];
                            textBox1.Text += span.TextContent + Environment.NewLine;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            new Bildirim("Matkap's", true, (toP)).Show();
            toP += 225;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label7.Text = "Çalışmıyor.";
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fren = false;
            label5.Text = "yükleniyor..";
            geckoWebBrowser1.Navigate(textBox2.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fren = false;
            label5.Text = "yükleniyor..";
            geckoWebBrowser1.Navigate(textBox2.Text);
        }

        private void gösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
