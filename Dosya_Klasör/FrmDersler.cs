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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void Btnekle_Click(object sender, EventArgs e)
        {
            ds.dersekle(textBox2.Text);
            MessageBox.Show("Ders Ekleme İşlemi Başarılı...");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnLıstele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void Btnsil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(textBox1.Text));
            MessageBox.Show("Ders Silme İşlemi Başarılı...");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(textBox2.Text, byte.Parse(textBox1.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Başarılı...");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
