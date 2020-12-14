using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyBanHang.DAL.DanhMuc;
using QuanLyBanHang.LinQ;
using QuanLyBanHang.DAL.QuanTri;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmSanPham : Form
    {
        string _mnu = "mnuSanPham";
        CSanPham _cSP = new CSanPham();
        SanPham _sp = null;

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            Clear();
        }

        public void Clear()
        {
            txtHoTen.Text = "";
            txtDonGia.Text = "0";
            txtModel.Text = "";
            txtSerial.Text = "";
            txtHangSanXuat.Text = "";
            _sp = null;
            dgvDanhSach.DataSource = _cSP.getDS();
        }

        public void loadEntity(SanPham en)
        {
            txtHoTen.Text = en.HoTen;
            txtDonGia.Text = en.DonGia.Value.ToString();
            txtModel.Text = en.Model;
            txtSerial.Text = en.Serial;
            txtHangSanXuat.Text = en.HangSanXuat;
            if (en.Hinh != null)
                picHinh.Image = _cSP.byteArrayToImage(en.Hinh.ToArray());
            else
                picHinh.Image = QuanLyBanHang.Properties.Resources.questionmark128x128;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cSP.checkExists_HoTen(txtHoTen.Text.Trim()) == true)
                    {
                        MessageBox.Show("Họ Tên đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SanPham en = new SanPham();
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DonGia = int.Parse(txtDonGia.Text.Trim());
                    en.Model = txtModel.Text.Trim();
                    en.Serial = txtSerial.Text.Trim();
                    en.HangSanXuat = txtHangSanXuat.Text.Trim();
                    if (picHinh.Image != null)
                        en.Hinh = _cSP.imgToByteArray(picHinh.Image);
                    if (_cSP.Them(en) == true)
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
                        if (_sp != null)
                        {
                            if (_cSP.Xoa(_sp) == true)
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
                    if (_sp != null)
                    {
                        if (_sp.HoTen != txtHoTen.Text.Trim())
                        {
                            if (_cSP.checkExists_HoTen(txtHoTen.Text.Trim()) == true)
                            {
                                MessageBox.Show("Họ Tên đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        _sp.HoTen = txtHoTen.Text.Trim();
                        _sp.DonGia = int.Parse(txtDonGia.Text.Trim());
                        _sp.Model = txtModel.Text.Trim();
                        _sp.Serial = txtSerial.Text.Trim();
                        _sp.HangSanXuat = txtHangSanXuat.Text.Trim();
                        if (picHinh.Image != null)
                            _sp.Hinh = _cSP.imgToByteArray(picHinh.Image);
                        if (_cSP.Sua(_sp) == true)
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
                _sp = _cSP.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                loadEntity(_sp);
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

        private void picHinh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picHinh.Image = Image.FromFile(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
