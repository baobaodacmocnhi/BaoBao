using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyBanHang.DAL.QuanTri;
using QuanLyBanHang.LinQ;
using System.Net;
using System.Net.Sockets;

namespace QuanLyBanHang.GUI.HeThong
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public delegate void GetValue(bool result);
        public GetValue GetLoginResult;

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnDangNhap.PerformClick();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                CNguoiDung _cNguoiDung = new CNguoiDung();

                if (_cNguoiDung.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()))
                {
                    User nguoidung = _cNguoiDung.GetByTaiKhoan(txtTaiKhoan.Text.Trim());
                    if (nguoidung != null)
                    {
                        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
                        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();

                        CNguoiDung.MaU = nguoidung.MaU;
                        CNguoiDung.HoTen = nguoidung.HoTen;
                        CNguoiDung.Admin = nguoidung.Admin;
                        if (nguoidung.MaNhom != null)
                            CNguoiDung.dtQuyenNhom = _cPhanQuyenNhom.GetDSByMaNhom(true, nguoidung.MaNhom.Value);
                        CNguoiDung.dtQuyenNguoiDung = _cPhanQuyenNguoiDung.GetDSByMaND(true, nguoidung.MaU);

                        GetLoginResult(true);
                        this.Hide();
                    }
                }
                else
                    MessageBox.Show("Sai Tài Khoản hoặc Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
