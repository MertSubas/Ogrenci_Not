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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLOGRENCILERTableAdapter ds= new DataSet1TableAdapters.TBLOGRENCILERTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void Btnekle_Click(object sender, EventArgs e)
        {
            string c=" ";
            if (radioButton1.Checked==true)
            {
                c = "Kız";
            }
            if (radioButton2.Checked==true)
            {
                c = "Erkek";
            }
            ds.OgrenciEkle(textBox2.Text, textBox3.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme İşlemi Başarılı...");
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void BtnLıstele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }
        
        
      

        private void Btnsil_Click(object sender, EventArgs e)
        {

         
            ds.OgrenciSil(int.Parse(textBox1.Text));
     

            MessageBox.Show("Öğrenci Silme İşlemi Başarılı...");
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox1.Text = comboBox1.SelectedValue.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Kız")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton1.Checked = false;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()=="Erkek")
            {
                radioButton2.Checked = true;

            }
            else
            {
                radioButton2.Checked = false;
            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            string c = " ";
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }

            ds.OgrenciGuncelle(textBox2.Text, textBox3.Text,byte.Parse(comboBox1.SelectedValue.ToString()), c, byte.Parse(textBox1.Text));
            MessageBox.Show("Öğrenci Güncelleme İşlemi Başarılı...");
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciAra(textBox4.Text);
        }
    }
}
