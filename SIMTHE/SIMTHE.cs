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

namespace SIMTHE
{
    public partial class SIMTHE : Form
    {
        listView1.Sorting = SortOrder.Ascending;
        String connectstring = @"Data Source=DESKTOP-CO09DFI\MSSQLSERVER01;Initial Catalog=simthe;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader doc;
        string sql;
        int i = 0;
        public SIMTHE()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            conn.Open();
            sql = @"select * from sim";
            cmd = new SqlCommand(sql, conn);
            doc = cmd.ExecuteReader();
            i = 0;
            while (doc.Read())
            {
                listView1.Items.Add(doc[0].ToString());
                listView1.Items[i].SubItems.Add(doc[1].ToString());
                listView1.Items[i].SubItems.Add(doc[2].ToString());
                listView1.Items[i].SubItems.Add(doc[3].ToString());
                listView1.Items[i].SubItems.Add(doc[4].ToString());
                i++;
            }
            conn.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SIMTHE_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectstring);
            hienthi();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
           
        }
    }
}
