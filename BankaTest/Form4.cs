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

namespace BankaTest
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2HOS6DT\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True");

        private void Form4_Load(object sender, EventArgs e)
        {
            Form2 fr = new Form2();

            SqlDataAdapter da = new SqlDataAdapter("select TBLHAREKETLER.ID , " +
                "(P.AD + ' ' + P.SOYAD) as ALICI, " +
                "(VP.AD + ' ' + VP.SOYAD) as GONDEREN, " +
                "TUTAR from TBLHAREKETLER inner join TBLKISILER as P " +
                "on TBLHAREKETLER.ALICI = P.HESAPNO inner join TBLKISILER as VP" +
                " on TBLHAREKETLER.GONDEREN = VP.HESAPNO where GONDEREN='" + fr.hesap + "'", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            
        }
    }
}
