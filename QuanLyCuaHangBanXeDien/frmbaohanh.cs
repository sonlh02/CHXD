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
    public partial class frmbaohanh : Form
    {
        public frmbaohanh()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();
        public void getdata()
        {
            string query = "select * from BaoHanh";
            //DataSet ds = kn.laydulieu(query, "BaoHanh");
            //dgvbaohanh.DataSource = ds.Tables["BaoHanh"];
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

        private void frmbaohanh_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into BaoHanh(MaKhachHang,MaXe,NgayLap,NgayHetHan,NoiDung,TinhTrang) values({0},{1},'{2}','{3}','{4}','{5}')", txtmakhachhang.Text, txtmaxe.Text, dtpngaylap.Text, dtpngayhethan.Text, txtnoidung.Text, txttinhtrang.Text);
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
            string query = string.Format("update BaoHanh set MaKhachHang = {1}, MaXe = {2}, NgayLap = '{3}' , NgayHetHan = '{4}', NoiDung = '{5}', TinhTrang = '{6}' where MaBaoHanh = '{0}'", txtmabaohanh.Text ,txtmakhachhang.Text, txtmaxe.Text, dtpngaylap.Text, dtpngayhethan.Text, txtnoidung.Text, txttinhtrang.Text);
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
            string query = string.Format("delete from BaoHanh where MaBaoHanh = '{0}'", txtmabaohanh.Text);
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
            string query = string.Format("select BaoHanh.* from BaoHanh,KhachHang where BaoHanh.MaKhachHang=KhachHang.MaKhachHang and HoTen like N'%{0}%'", txttimkiem.Text);
            //DataSet ds = kn.laydulieu(query, "BaoHanh");
            //dgvbaohanh.DataSource = ds.Tables["BaoHanh"];
        }
    }
}
