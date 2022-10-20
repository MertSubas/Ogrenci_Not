using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dosya_Klasör
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup dr = new FrmKulup();
            dr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler dr = new FrmDersler();
            dr.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci dr =new FrmOgrenci();
            dr.Show();
            this.Hide();


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar ds= new FrmSinavNotlar();
            ds.Show();
            this.Hide();
        }
    }
}
