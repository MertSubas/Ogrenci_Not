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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        //Data Source=.;Initial Catalog=BonusOkul;Integrated Security=True
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        public string textadi;
        public string adi;
        public string soyadi;

        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAM,DURUM FROM TBLNOTLAR inner join TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID = @P1", baglanti);
           SqlCommand textad= new SqlCommand("SELECT *from TBLOGRENCILER where OGRID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            textad.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter za=new SqlDataAdapter(textad);
            DataTable dz= new DataTable();
            za.Fill(dz);
            dataGridView2.DataSource=dz;



         
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            adi = dataGridView2.Rows[0].Cells[1].Value.ToString();
            soyadi = dataGridView2.Rows[0].Cells[2].Value.ToString();
            this.Text = " Öğrenci Adı:" +" "+adi +" "+ soyadi+" | "+ "Numarası:"+" "+ numara;


        }
    }
}
