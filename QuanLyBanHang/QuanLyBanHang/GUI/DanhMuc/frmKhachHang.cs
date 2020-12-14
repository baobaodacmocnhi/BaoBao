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
using QuanLyBanHang.DAL.DanhMuc;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmKhachHang : Form
    {
        string _mnu = "mnuKhachHang";
        CKhachHang _cKH = new CKhachHang();
        KhachHang _kh = null;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            Clear();
        }

        public void Clear()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtMST.Text = "";
            txtDiaChiNhanHang.Text = "";
            txtDienThoaiNhanHang.Text = "";
            _kh = null;
            dgvDanhSach.DataSource = _cKH.getDS();
        }

        public void loadEntity(KhachHang en)
        {
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            txtDienThoai.Text = en.DienThoai;
            txtEmail.Text = en.Email;
            txtMST.Text = en.MST;
            txtDiaChiNhanHang.Text = en.DiaChiNhanHang;
            txtDienThoaiNhanHang.Text = en.DienThoaiNhanHang;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cKH.checkExists_HoTen(txtHoTen.Text.Trim()) == true)
                    {
                        MessageBox.Show("Họ Tên đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cKH.checkExists_DiaChi(txtDiaChi.Text.Trim()) == true)
                    {
                        MessageBox.Show("Địa Chỉ đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cKH.checkExists_DienThoai(txtDienThoai.Text.Trim()) == true)
                    {
                        MessageBox.Show("Điện Thoại đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cKH.checkExists_MST(txtMST.Text.Trim()) == true)
                    {
                        MessageBox.Show("MST đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    KhachHang en = new KhachHang();
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DiaChi = txtDiaChi.Text.Trim();
                    en.DienThoai = txtDienThoai.Text.Trim();
                    en.Email = txtEmail.Text.Trim();
                    en.MST = txtMST.Text.Trim();
                    en.DiaChiNhanHang = txtDiaChiNhanHang.Text.Trim();
                    en.DienThoaiNhanHang = txtDienThoaiNhanHang.Text.Trim();
                    if (_cKH.Them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_kh != null)
                        {
                            if (_cKH.Xoa(_kh) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_kh != null)
                    {
                        if (_kh.HoTen != txtHoTen.Text.Trim())
                        {
                            if (_cKH.checkExists_HoTen(txtHoTen.Text.Trim()) == true)
                            {
                                MessageBox.Show("Họ Tên đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (_kh.DiaChi != txtDiaChi.Text.Trim())
                        {
                            if (_cKH.checkExists_DiaChi(txtDiaChi.Text.Trim()) == true)
                            {
                                MessageBox.Show("Địa Chỉ đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (_kh.DienThoai != txtDienThoai.Text.Trim())
                        {
                            if (_cKH.checkExists_DienThoai(txtDienThoai.Text.Trim()) == true)
                            {
                                MessageBox.Show("Điện Thoại đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (_kh.MST != txtMST.Text.Trim())
                        {
                            if (_cKH.checkExists_MST(txtMST.Text.Trim()) == true)
                            {
                                MessageBox.Show("MST đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        _kh.HoTen = txtHoTen.Text.Trim();
                        _kh.DiaChi = txtDiaChi.Text.Trim();
                        _kh.DienThoai = txtDienThoai.Text.Trim();
                        _kh.Email = txtEmail.Text.Trim();
                        _kh.MST = txtMST.Text.Trim();
                        _kh.DiaChiNhanHang = txtDiaChiNhanHang.Text.Trim();
                        _kh.DienThoaiNhanHang = txtDienThoaiNhanHang.Text.Trim();
                        if (_cKH.Sua(_kh) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _kh = _cKH.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                loadEntity(_kh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
