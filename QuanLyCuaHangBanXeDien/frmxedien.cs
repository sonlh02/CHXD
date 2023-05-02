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
    public partial class frmxedien : Form
    {
        public frmxedien()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();
        public void getdata()
        {
            string query = "select * from XeDien";
            DataSet ds = kn.laydulieu(query, "XeDien");
            dgvdgvxedien.DataSource = ds.Tables["XeDien"];
        }
        private void frmxedien_Load(object sender, EventArgs e)
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
            string query = string.Format("insert into XeDien(MaLoaiXe,TenXe,HangSanXuat,NamSanXuat,GiaBan,SoLuong,MoTa) values({0},'{1}','{2}',{3},{4},{5},'{6}')", txtmaloaixe.Text, txttenxe.Text, txthangsanxuat.Text, txtnamsanxuat.Text, txtgiaban.Text, txtsoluong.Text, txtmota.Text);
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
            string query = string.Format("update XeDien set MaLoaiXe = {1}, TenXe = '{2}', HangSanXuat = '{3}', NamSanXuat = {4}, GiaBan = {5}, SoLuong = {6}, MoTa = '{7}' where MaXe = {0}", txtmaxe.Text, txtmaloaixe.Text, txttenxe.Text, txthangsanxuat.Text, txtnamsanxuat.Text, txtgiaban.Text, txtsoluong.Text, txtmota.Text);
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
            string query = string.Format("delete from XeDien where MaXe = {0}", txtmaxe.Text);
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
            string query = string.Format("select * from XeDien where MaXe = N'{0}'", txttimkiem.Text);
            DataSet ds = kn.laydulieu(query, "XeDien");
            dgvdgvxedien.DataSource = ds.Tables["XeDien"];
        }
    }
}
