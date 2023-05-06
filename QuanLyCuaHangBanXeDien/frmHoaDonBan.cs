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
using COMExcel = Microsoft.Office.Interop.Excel;
namespace QuanLyCuaHangBanXeDien
{
    public partial class frmHoaDonBan : Form
    {
        DataTable ChiTietHoaDon;
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnin.Enabled = false;
            txtmahoadon.ReadOnly = true;
            txtsoluong.ReadOnly = true;
            txtdongia.ReadOnly = true;
            txttongtien2.ReadOnly = true;
            txttongtien2.Text = "0";
            //kn.laydulieu("SELECT MaKhachHang, HoTen FROM KhachHang", cbomakhchhang, "MaKhachHang", "MaKhachHang");
            cbomakhchhang.SelectedIndex = -1;
            //kn.laydulieu("SELECT MaNhanVien, HoTen FROM NhanVien", cbomanhanvien, "MaNhanVien", "MaNhanVien");
            cbomanhanvien.SelectedIndex = -1;
            //ketnoi.FillCombo("SELECT MaXe, TenXe FROM XeDien", cbomaxe, "MaXe", "MaXe");
            cbomaxe.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtmahoadon.Text != "")
            {
                LoadInfoHoaDon();
                btnin.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaXe, b.TenXe, a.SoLuong, a.DonGia, a.ThanhTien FROM ChiTietHoaDon AS a, XeDien AS b WHERE a.MaHoaDon = N'" + txtmahoadon.Text + "'AND a.MaXe=b.MaXe";
            //ChiTietHoaDon = ketnoi.GetDataToTable(sql);
            dgvHoaDonBan.DataSource = ChiTietHoaDon;
            dgvHoaDonBan.Columns[0].HeaderText = "MaXe";
            dgvHoaDonBan.Columns[1].HeaderText = "TenXe";
            dgvHoaDonBan.Columns[2].HeaderText = "SoLuong";
            dgvHoaDonBan.Columns[3].HeaderText = "DonGia";
            dgvHoaDonBan.Columns[4].HeaderText = "ThanhTien";
            dgvHoaDonBan.Columns[0].Width = 80;
            dgvHoaDonBan.Columns[0].Width = 130;
            dgvHoaDonBan.Columns[0].Width = 80;
            dgvHoaDonBan.Columns[0].Width = 90;
            dgvHoaDonBan.Columns[0].Width = 90;
            dgvHoaDonBan.AllowUserToAddRows= false;
            dgvHoaDonBan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayLap FROM HoaDon WHERE MaHoaDon = N'" + txtmahoadon.Text + "'";
            //dtpngaylap.Value = DateTime.Parse(ketnoi.GetFieldValues(str));
            str = "SELECT MaNhanVien FROM HoaDon WHERE MaHoaDon = N'" + txtmahoadon.Text + "'";
            //cbomanhanvien.Text = ketnoi.GetFieldValues(str);
            str = "SELECT MaKhachHang FROM HoaDon WHERE MaHoaDon = N'" + txtmahoadon.Text + "'";
            //cbomakhchhang.Text = ketnoi.GetFieldValues(str);
            str = "SELECT TongTien FROM HoaDon WHERE MaHoaDon = N'" + txtmahoadon.Text + "'";
            //txttongtien2.Text = ketnoi.GetFieldValues(str);
            //lblTongTien.Text = "Bằng chữ: " + ketnoi.ChuyenSoSangChu(txttongtien2.Text);
        }
    }
}
