using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Bai2
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter da_khoa;
        DataSet ds_khoa;
        DataColumn[] key = new DataColumn[1];
        SqlCommand cmd = new SqlCommand();
        string strsql;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=A209PC02;Initial Catalog=QL_Khoa;Integrated Security=True");
            string strSelect = "select * from Khoa";
            da_khoa = new SqlDataAdapter(strSelect, conn);
            ds_khoa = new DataSet();
            da_khoa.Fill(ds_khoa, "Khoa");
            key[0] = ds_khoa.Tables["Khoa"].Columns[0];
            ds_khoa.Tables["Khoa"].PrimaryKey = key;
        }
        void Databingding(DataTable pDT)
        {
            txtMaLop.DataBindings.Clear();
            txtTenLop.DataBindings.Clear();
            //lien ket du lieu trong text box voi truong du lieu trong database
            txtMaLop.DataBindings.Add("Text", pDT, "Ma Khoa");
            txtTenLop.DataBindings.Add("Text", pDT, "Ten Khoa");
        }
        void loadGrid()
        {
            dgvLop.DataSource = ds_khoa.Tables[0];
            Databingding(ds_khoa.Tables[0]);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadGrid();
        }
    }
}
