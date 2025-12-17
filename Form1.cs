using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplashScreen2
{
    public partial class Form1 : Form
    {
        // Yükleme Çubuğu Kontrol Değişkenleri
        private const int MaxProgressWidth = 500; // Çubuğun ulaşacağı maksimum piksel genişliği
        private const int MaxLoadCount = 100;     // Yüklemenin tamamlanacağı adım sayısı
        private int currentProgress = 0;          // Mevcut yükleme adımı
        public Form1()
        {
            InitializeComponent();
            // 1. Logo Ataması (Projeye eklediğiniz görsel adı)
            // this.pbLogo.Image = global::ProjeAdiniz.Properties.Resources.ZenithLogo;

            // 2. Yükleme Çubuğu Başlangıç Ayarları
            pnlProgress.Width = 0; // Başlangıçta görünmez (genişlik 0)
            pnlProgress.Height = 10; // Çubuk kalınlığı (tasarımınıza göre ayarlayın)

            // Yükleme çubuğunu formun yatay olarak ortasına ve dikeyde 300. piksele konumlandırır.
            pnlProgress.Location = new Point((this.Width - MaxProgressWidth) / 2, 300);

            // 3. Timer Ayarları
            timer1.Interval = 50; // 50 milisaniyede bir Tick olayı tetiklenir (Hız)
            timer1.Start();       // Zamanlayıcıyı hemen başlat.
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentProgress++;

            // Yükleme çubuğunun genişliğini her adımda orantılı olarak artırır.
            int newWidth = (int)((double)currentProgress / MaxLoadCount * MaxProgressWidth);

            if (newWidth <= MaxProgressWidth)
            {
                pnlProgress.Width = newWidth;
            }

            // Yükleme bitti mi kontrolü (100. adımdan sonra)
            if (currentProgress > MaxLoadCount)
            {
                timer1.Stop(); // Zamanlayıcıyı durdurur.

                // **ANA FORMU AÇMA BÖLÜMÜ**
                // AnaForm mainForm = new AnaForm(); // Ana formunuzun sınıf adını yazın
                // mainForm.Show();

                this.Close(); // Splash screen'i kapatır.
            }
            }
    }
}
