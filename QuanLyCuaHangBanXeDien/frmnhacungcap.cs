using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanXeDien
{
    public partial class frmnhacungcap : Form
    {
        public frmnhacungcap()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();
        public void getdata()
        {
            string query = "select * from NhaCungCap";
            DataSet ds = kn.laydulieu(query, "NhaCungCap");
            dgvnhacungcap.DataSource = ds.Tables["NhaCungCap"];
        }
        private void frmnhacungcap_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void btnmoi_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is System.Windows.Forms.TextBox) || (ctr is DateTimePicker) || (ctr is System.Windows.Forms.ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into NhaCungCap(TenNhaCungCap,DiaChi,SoDienThoai,Email) values('{0}','{1}','{2}','{3}')",txttennhacungcap.Text, txtdiachi.Text, txtsodienthoai.Text, txtemail.Text);
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Them thanh cong");
                getdata();
            }
            else
            {
                MessageBox.Show("Them that bai");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string query = string.Format("update NhaCungCap set TenNhaCungCap = '{1}', DiaChi = '{2}', SoDienThoai = '{3}' , Email = '{4}' where MaNhaCungCap = '{0}'", txtnhacungcap.Text, txttennhacungcap.Text, txtdiachi.Text, txtsodienthoai.Text, txtemail.Text);
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Sua thanh cong");
                getdata();
            }
            else
            {
                MessageBox.Show("Sua that bai");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string query = string.Format("delete from NhaCungCap where MaNhaCungCap = '{0}'", txtnhacungcap.Text);
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Xoa thanh cong");
                getdata();
            }
            else
            {
                MessageBox.Show("Xoa that bai");
            }
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from NhaCungCap where MaNhaCungCap like N'%{0}%'", txttimkiem.Text);
            DataSet ds = kn.laydulieu(query, "NhaCungCap");
            dgvnhacungcap.DataSource = ds.Tables["NhaCungCap"];
        }
    }
}
