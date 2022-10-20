using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Dosya_Klasör
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=BonusOkul;Integrated Security=True");
        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnLıstele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("UPDATE TBLKULUPLER set KULUPAD=@P1 where KULUPID=@P2", baglanti);
            komut2.Parameters.AddWithValue("@p2", textBox1.Text);
            komut2.Parameters.AddWithValue("@P1", textBox2.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Güncelleme Başarılı...");
            liste();


        }

        private void Btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komu = new SqlCommand("Insert into TBLKULUPLER (KULUPAD) VALUES (@P1)", baglanti);
            komu.Parameters.AddWithValue("@P1", textBox2.Text);
            komu.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Ekleme Tamamlandı...");
            liste();
        }

        private void Btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sılme=new SqlCommand("Delete from TBLKULUPLER where KULUPID=@p2",baglanti);
            sılme.Parameters.AddWithValue("@p2",textBox1.Text);
            sılme.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Silme İşlemi Tamamlandı...");
            liste();        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
