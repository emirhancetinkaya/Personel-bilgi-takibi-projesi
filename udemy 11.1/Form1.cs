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
    public partial class Form1 : Form
    {
        SqlConnection bağlantı = new SqlConnection("Data Source=Emircet\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");

        void temizle()
        {
            txtid.Text = " ";
            txtad.Text = " ";
            txtsoyad.Text = " ";
            txtmeslek.Text = " ";
            mskmaaş.Text = " ";
            cmbşehir.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }

        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,perşehir,permaaş,permeslek,perdurum)values(@p1,@p2,@p3,@p4,@p5,@p6)", bağlantı);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbşehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaaş.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("ekleme başarıyla yapıldı");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "true";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text= "false";
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[seçilen].Cells[2].Value.ToString();
            cmbşehir.Text = dataGridView1.Rows[seçilen].Cells[3].Value.ToString();
            mskmaaş.Text = dataGridView1.Rows[seçilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[seçilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[seçilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komutsil = new SqlCommand("delete from tbl_personel where perid=@k1", bağlantı);
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("silme başarıyla gerçekleşti");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komutgüncelle = new SqlCommand("update Tbl_Personel set perad=@a1,persoyad=@a2,perşehir=@a3,permaaş=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7", bağlantı);
            komutgüncelle.Parameters.AddWithValue("@a1",txtad.Text);
            komutgüncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@a3", cmbşehir.Text);
            komutgüncelle.Parameters.AddWithValue("@a4", mskmaaş.Text);
            komutgüncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutgüncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutgüncelle.Parameters.AddWithValue("@a7", txtid.Text);
            komutgüncelle.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("güncelleme başarıyla yapıldı");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            frmgrafikler frg = new frmgrafikler();
            frg.Show();
        }

        
    }
}
