﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Bida.BUS;
using Bida.DTO;
using MetroFramework;
using System.Data.SqlClient;

namespace Bida
{
    public partial class frmOrder : Form
    {
        private BAN ban;
        private NHANVIEN nhanvien;
        private List<ORDER> orders;
        public frmOrder(BAN b, NHANVIEN n)
        {
            InitializeComponent();
            this.ban = b;
            this.nhanvien = n;
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            // Chuỗi kết nối tới SQL Server với server name và database name của bạn
            string connectionString = "Data Source=DLONG\\SQLEXPRESS;Initial Catalog=Bida;Integrated Security=True";

            // Câu truy vấn SQL để lấy dữ liệu từ bảng ORDER
            string query = "SELECT * FROM [ORDER]";




            // Kết nối tới cơ sở dữ liệu và lấy dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan(ban, nhanvien);
            frm.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy số lượng hiện tại và tăng lên 1
                int soLuongHienTai = Convert.ToInt32(row.Cells["SoLuong"].Value);
                row.Cells["SoLuong"].Value = soLuongHienTai + 1;
            }
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan(ban, nhanvien);
            frm.Show();
            this.Close(
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
