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

namespace udemy_11._1
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=Emircet\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            bağlantı.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_Personel", bağlantı);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                label2.Text = dr1[0].ToString();
            }
            bağlantı.Close();

            //evli sayısı
            bağlantı.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=1", bağlantı);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                label4.Text = dr2[0].ToString();
            }
            bağlantı.Close();

            //bekar perspnel sayısı
            bağlantı.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=0", bağlantı);
            SqlDataReader dr3=komut3.ExecuteReader();
            while(dr3.Read())
            {
                label6.Text = dr3[0].ToString();
            }
            bağlantı.Close();

            //şehir sayısı
            bağlantı.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(perşehir))from Tbl_Personel", bağlantı);
            SqlDataReader dr4= komut4.ExecuteReader();
            while (dr4.Read())
            {
                label8.Text= dr4[0].ToString();
            }
            bağlantı.Close();

            //toplam maaş
            bağlantı.Open();
            SqlCommand komut5 = new SqlCommand("select sum(Permaaş) from Tbl_Personel", bağlantı);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label10.Text= dr5[0].ToString();
            }
            bağlantı.Close();

            //ortalama maaş
            bağlantı.Open();
            SqlCommand komut6 = new SqlCommand("select avg(Permaaş) from Tbl_Personel", bağlantı);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while(dr6.Read())
            {
                label12.Text= dr6[0].ToString();
            }
            bağlantı.Close();
        }
    }
}
