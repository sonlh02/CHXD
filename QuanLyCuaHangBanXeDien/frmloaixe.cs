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
    public partial class frmloaixe : Form
    {
        public frmloaixe()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();
        public void getdata()
        {
            string query = "select * from LoaiXe";
            DataSet ds = kn.laydulieu(query, "LoaiXe");
            dgvloaixe.DataSource = ds.Tables["LoaiXe"];
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

        private void frmloaixe_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into LoaiXe(MaNhaCungCap,TenLoaiXe,MoTa) values({0},'{1}','{2}')",txtmanhacungcap.Text, txttenloaixe.Text, txtmota.Text);
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
            string query = string.Format("update LoaiXe set MaNhaCungCap = {1}, TenLoaiXe = '{2}', MoTa = '{3}' where MaLoaiXe = '{0}'", txtmaloaixe.Text, txtmanhacungcap.Text, txttenloaixe.Text, txtmota.Text);
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
            string query = string.Format("delete from LoaiXe where MaLoaiXe = '{0}'", txtmaloaixe.Text);
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
            string query = string.Format("select * from LoaiXe where MaLoaiXe = N'{0}'", txttimkiem.Text);
            DataSet ds = kn.laydulieu(query, "LoaiXe");
            dgvloaixe.DataSource = ds.Tables["LoaiXe"];
        }
    }
}
