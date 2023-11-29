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

namespace Bai1
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
            txtMaKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Clear();
            //lien ket du lieu trong text box voi truong du lieu trong database
            txtMaKhoa.DataBindings.Add("Text", pDT, "Ma Khoa");
            txtTenKhoa.DataBindings.Add("Text", pDT, "Ten Khoa");
        }
        void loadGrid()
        {
            dgvKhoa.DataSource = ds_khoa.Tables[0];
            Databingding(ds_khoa.Tables[0]);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //tao 1 dong du lieu moi
            DataRow newrow = ds_khoa.Tables[0].NewRow();
            newrow["Ma Khoa"] = txtMaKhoa.Text;
            newrow["Ten Khoa"] = txtTenKhoa.Text;
            //them dong du lieu
            ds_khoa.Tables[0].Rows.Add(newrow);
            //cap nhap trong database
            SqlCommandBuilder cB = new SqlCommandBuilder(da_khoa);
            //cap nhat dataset
            da_khoa.Update(ds_khoa, "Khoa");
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRow dr = ds_khoa.Tables[0].Rows.Find(txtMaKhoa.Text);
            if(dr!=null)
            {
                dr.Delete();
            }
            //cap nhap trong database
            SqlCommandBuilder cB = new SqlCommandBuilder(da_khoa);
            //cap nhat dataset
            da_khoa.Update(ds_khoa, "Khoa");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow dr = ds_khoa.Tables[0].Rows.Find(txtMaKhoa.Text);
            if(dr!=null)
            {
                dr["Ten Khoa"] = txtTenKhoa.Text;
            }
            //cap nhap trong database
            SqlCommandBuilder cB = new SqlCommandBuilder(da_khoa);
            //cap nhat dataset
            da_khoa.Update(ds_khoa, "Khoa");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadGrid();
        }
    }
}
