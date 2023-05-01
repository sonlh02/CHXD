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
    public partial class frmnhanvien : Form
    {
        public frmnhanvien()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();
        public void getdata()
        {
            string query = "select * from NhanVien";
            DataSet ds = kn.laydulieu(query, "NhanVien");
            dgvnhanvien.DataSource = ds.Tables["NhanVien"];
        }
        private void frmnhanvien_Load(object sender, EventArgs e)
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
            string query = string.Format("insert into NhanVien(HoTen,DiaChi,SoDienThoai,Email,NgaySinh,GioiTinh,ChucVu,Luong) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})", txthoten.Text, txtdiachi.Text, txtsodienthoai.Text, txtemail.Text,dtpngaysinh.Text,txtgioitinh.Text,txtchucvu.Text,txtluong.Text);
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
            string query = string.Format("update NhanVien set HoTen = '{1}', DiaChi = '{2}', SoDienThoai = '{3}' , Email = '{4}', NgaySinh = '{5}', GioiTinh = '{6}', ChucVu = '{7}', Luong = {8} where MaNhanVien = {0}",txtmanhanvien.Text, txthoten.Text, txtdiachi.Text, txtsodienthoai.Text, txtemail.Text, dtpngaysinh.Text, txtgioitinh.Text, txtchucvu.Text, txtluong.Text);
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
            string query = string.Format("delete from NhanVien where MaNhanVien = '{0}'", txtmanhanvien.Text);
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
            string query = string.Format("select * from NhanVien where MaNhanVien like N'%{0}%'", txttimkiem.Text);
            DataSet ds = kn.laydulieu(query, "NhanVien");
            dgvnhanvien.DataSource = ds.Tables["NhanVien"];
        }
    }
}
