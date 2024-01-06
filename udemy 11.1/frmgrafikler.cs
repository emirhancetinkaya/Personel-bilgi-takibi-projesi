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
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=Emircet\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komutg1 = new SqlCommand("select perşehir,count(*) from tbl_personel group by perşehir", bağlantı);
            SqlDataReader dr1=komutg1.ExecuteReader();
            while(dr1.Read())
            {
                chart1.Series["şehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            bağlantı.Close();

            bağlantı.Open();
            SqlCommand komutg2 = new SqlCommand("select permeslek,avg(permaaş) from tbl_personel group by permeslek", bağlantı);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while(dr2.Read())
            {
                chart2.Series["meslek-maaş"].Points.AddXY(dr2[0], dr2[1]);
            }
            bağlantı.Close();
        }
    }
}
