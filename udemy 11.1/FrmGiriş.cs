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
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=Emircet\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_yönetici where kullanıcıadı=@p1 and şifre=@p2",bağlantı);
            komut.Parameters.AddWithValue("@p1", txtkullanıcıad.Text);
            komut.Parameters.AddWithValue("@p2", txtşifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("girdiler hatalı!!!");
            }
            bağlantı.Close();
        }
    }
}
