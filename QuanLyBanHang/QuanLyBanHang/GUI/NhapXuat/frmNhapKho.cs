﻿using System;
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
using QuanLyBanHang.DAL.NhapXuat;

namespace QuanLyBanHang.GUI.NhapXuat
{
    public partial class frmNhapKho : Form
    {
        string _mnu = "mnuNhapKho";
        CSanPham _cSP = new CSanPham();
        CKhachHang _cKH = new CKhachHang();
        CNguoiDung _cND = new CNguoiDung();
        CNhapKho _cNK = new CNhapKho();
        AutoCompleteStringCollection autoHoTen_SP = new AutoCompleteStringCollection();
        AutoCompleteStringCollection autoKyHieu_SP = new AutoCompleteStringCollection();

        NhapKho _nhapkho = null;

        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvDanhSach.AutoGenerateColumns = false;
            loadAutoCompleteSP();
        }

        public void Clear()
        {
            dateNgayLap.Value = DateTime.Now;
            cmbKhachHang.SelectedIndex = -1;
            cmbNhanVien.SelectedIndex = -1;
            chkNhanVienGiuTien.Checked = false;
            txtNhanVienSoTien.Text = "0";
            chkCoHoaDon.Checked = false;
            chkChuyenKhoan.Checked = false;
            dgvSanPham.Rows.Clear();
            _nhapkho = null;
            btnXem.PerformClick();
        }

        public void loadEntity(NhapKho en)
        {
            dateNgayLap.Value = en.NgayLap.Value;
            if (en.ID_KhachHang != null)
                cmbKhachHang.SelectedValue = en.ID_KhachHang;
            if (en.ID_NhanVien != null)
                cmbNhanVien.SelectedValue = en.ID_NhanVien;
            chkCoHoaDon.Checked = en.CoHoaDon;
            chkChuyenKhoan.Checked = en.ChuyenKhoan;
            txtNhanVienSoTien.Text = en.NhanVien_SoTien.ToString();
            txtTongCong.Text = en.TongCong.ToString();
            txtThucTra.Text = en.ThucTra.ToString();
            dgvSanPham.Rows.Clear();
            foreach (NhapKho_ChiTiet item in en.NhapKho_ChiTiets.ToList())
            {
                var index = dgvSanPham.Rows.Add();
                dgvSanPham.Rows[index].Cells["ID"].Value = item.ID_SanPham;
                dgvSanPham.Rows[index].Cells["KyHieu"].Value = item.SanPham.KyHieu;
                dgvSanPham.Rows[index].Cells["HoTen"].Value = item.SanPham.HoTen;
                dgvSanPham.Rows[index].Cells["SoLuong"].Value = item.SoLuong;
                dgvSanPham.Rows[index].Cells["GiaNCC"].Value = item.GiaNCC;
                dgvSanPham.Rows[index].Cells["GiaNiemYet"].Value = item.GiaNiemYet;
                dgvSanPham.Rows[index].Cells["GiaGiamTrucTiep"].Value = item.GiaGiamTrucTiep;
                dgvSanPham.Rows[index].Cells["GiaGiamTyLe"].Value = item.GiaGiamTyLe;
                dgvSanPham.Rows[index].Cells["TongCong"].Value = item.TongCong;
                dgvSanPham.Rows[index].Cells["ThucTra"].Value = item.ThucTra;
            }
        }

        public void loadAutoCompleteSP()
        {
            DataTable dt = _cSP.getDS_SP();
            dt.Merge(_cSP.getDS_Bo());
            foreach (DataRow item in dt.Rows)
            {
                autoHoTen_SP.Add(item["HoTen"].ToString());
                autoKyHieu_SP.Add(item["KyHieu"].ToString());
            }

            cmbKhachHang.DataSource = _cKH.getDS();
            cmbKhachHang.DisplayMember = "HoTen";
            cmbKhachHang.ValueMember = "ID";

            cmbNhanVien.DataSource = _cND.getDS_ChamCong();
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaU";
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgvSanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvSanPham.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvSanPham_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvSanPham.Columns[dgvSanPham.CurrentCell.ColumnIndex].Name == "KyHieu")
            {
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteCustomSource = autoKyHieu_SP;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
                if (dgvSanPham.Columns[dgvSanPham.CurrentCell.ColumnIndex].Name == "HoTen")
                {
                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodCode.AutoCompleteCustomSource = autoHoTen_SP;
                        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
        }

        private void dgvSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSanPham.Rows.Count > 0)
                {
                    if (dgvSanPham.Columns[e.ColumnIndex].Name == "KyHieu")
                    {
                        for (int i = 0; i < dgvSanPham.Rows.Count - 2; i++)
                            if (i != e.RowIndex && dgvSanPham["KyHieu", i].Value != null && dgvSanPham["KyHieu", i].Value.ToString() != "" && dgvSanPham["KyHieu", i].Value.ToString() == dgvSanPham["KyHieu", e.RowIndex].Value.ToString())
                            {
                                MessageBox.Show("Sản Phẩm đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        SanPham sp = _cSP.getSP_KyHieu(dgvSanPham["KyHieu", e.RowIndex].Value.ToString());
                        dgvSanPham["KyHieu", e.RowIndex].Value = sp.KyHieu;
                        dgvSanPham["HoTen", e.RowIndex].Value = sp.HoTen;
                        dgvSanPham["SoLuong", e.RowIndex].Value = 0;
                        dgvSanPham["GiaNCC", e.RowIndex].Value = 0;
                        dgvSanPham["GiaNiemYet", e.RowIndex].Value = sp.DonGia;
                        dgvSanPham["GiaGiamTrucTiep", e.RowIndex].Value = 0;
                        dgvSanPham["GiaGiamTyLe", e.RowIndex].Value = 0;
                    }
                    else
                        if (dgvSanPham.Columns[e.ColumnIndex].Name == "HoTen")
                        {
                            for (int i = 0; i < dgvSanPham.Rows.Count - 2; i++)
                                if (i != e.RowIndex && dgvSanPham["HoTen", i].Value != null && dgvSanPham["HoTen", i].Value.ToString() != "" && dgvSanPham["HoTen", i].Value.ToString() == dgvSanPham["HoTen", e.RowIndex].Value.ToString())
                                {
                                    MessageBox.Show("Sản Phẩm đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            SanPham sp = _cSP.getSP_HoTen(dgvSanPham["HoTen", e.RowIndex].Value.ToString());
                            dgvSanPham["KyHieu", e.RowIndex].Value = sp.KyHieu;
                            dgvSanPham["HoTen", e.RowIndex].Value = sp.HoTen;
                            dgvSanPham["SoLuong", e.RowIndex].Value = 0;
                            dgvSanPham["GiaNCC", e.RowIndex].Value = 0;
                            dgvSanPham["GiaNiemYet", e.RowIndex].Value = sp.DonGia;
                            dgvSanPham["GiaGiamTrucTiep", e.RowIndex].Value = 0;
                            dgvSanPham["GiaGiamTyLe", e.RowIndex].Value = 0;
                        }
                        else
                            if (dgvSanPham.Columns[e.ColumnIndex].Name == "SoLuong" || dgvSanPham.Columns[e.ColumnIndex].Name == "GiaNCC")
                            {
                                int SoLuong = 0, GiaNCC = 0;
                                if (dgvSanPham["SoLuong", e.RowIndex].Value != null)
                                    SoLuong = int.Parse(dgvSanPham["SoLuong", e.RowIndex].Value.ToString());
                                if (dgvSanPham["GiaNCC", e.RowIndex].Value != null)
                                    GiaNCC = int.Parse(dgvSanPham["GiaNCC", e.RowIndex].Value.ToString());
                                long value = SoLuong * GiaNCC;
                                dgvSanPham["TongCong", e.RowIndex].Value = dgvSanPham["ThucTra", e.RowIndex].Value = value;
                            }
                            else
                                if (dgvSanPham.Columns[e.ColumnIndex].Name == "GiaGiamTrucTiep" || dgvSanPham.Columns[e.ColumnIndex].Name == "GiaGiamTyLe")
                                {
                                    int GiaGiamTrucTiep = 0;
                                    double GiaGiamTyLe = 0;
                                    if (dgvSanPham["GiaGiamTrucTiep", e.RowIndex].Value != null)
                                        GiaGiamTrucTiep = int.Parse(dgvSanPham["GiaGiamTrucTiep", e.RowIndex].Value.ToString());
                                    if (dgvSanPham["GiaGiamTyLe", e.RowIndex].Value != null)
                                        GiaGiamTyLe = int.Parse(dgvSanPham["GiaGiamTyLe", e.RowIndex].Value.ToString());
                                    double value = double.Parse(dgvSanPham["TongCong", e.RowIndex].Value.ToString()) - GiaGiamTrucTiep - (double.Parse(dgvSanPham["TongCong", e.RowIndex].Value.ToString()) * GiaGiamTyLe / 100);
                                    dgvSanPham["ThucTra", e.RowIndex].Value = Math.Round(value);
                                }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    NhapKho en = new NhapKho();
                    en.NgayLap = dateNgayLap.Value;
                    if (cmbKhachHang.SelectedIndex >= 0)
                        en.ID_KhachHang = (int)cmbKhachHang.SelectedValue;
                    if (cmbNhanVien.SelectedIndex >= 0)
                        en.ID_NhanVien = (int)cmbNhanVien.SelectedValue;
                    en.CoHoaDon = chkCoHoaDon.Checked;
                    int TongCong = 0, ThucTra = 0;
                    foreach (DataGridViewRow item in dgvSanPham.Rows)
                        if (item.Cells["KyHieu"].Value != null && item.Cells["KyHieu"].Value.ToString() != "")
                        {
                            SanPham sp = _cSP.getSP_KyHieu(item.Cells["KyHieu"].Value.ToString());
                            NhapKho_ChiTiet enCT = new NhapKho_ChiTiet();
                            enCT.ID_SanPham = sp.ID;
                            enCT.SoLuong = int.Parse(item.Cells["SoLuong"].Value.ToString());
                            enCT.GiaNCC = int.Parse(item.Cells["GiaNCC"].Value.ToString());
                            enCT.GiaNiemYet = int.Parse(item.Cells["GiaNiemYet"].Value.ToString());
                            enCT.GiaGiamTrucTiep = int.Parse(item.Cells["GiaGiamTrucTiep"].Value.ToString());
                            enCT.GiaGiamTyLe = int.Parse(item.Cells["GiaGiamTyLe"].Value.ToString());
                            enCT.TongCong = int.Parse(item.Cells["TongCong"].Value.ToString());
                            enCT.ThucTra = int.Parse(item.Cells["ThucTra"].Value.ToString());
                            en.NhapKho_ChiTiets.Add(enCT);
                            TongCong += enCT.TongCong;
                            ThucTra += enCT.ThucTra;
                        }
                    if (chkChuyenKhoan.Checked == true)
                    {
                        en.ChuyenKhoan = true;
                        en.NhanVien_SoTien = TongCong - ThucTra;
                        en.NhanVien_GiuTien = true;
                    }
                    en.TongCong = TongCong;
                    en.ThucTra = ThucTra;
                    if (_cNK.Them(en) == true)
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
                        if (_nhapkho != null)
                        {
                            if (_cNK.Xoa(_nhapkho) == true)
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
                    if (_nhapkho != null)
                    {
                        _nhapkho.NgayLap = dateNgayLap.Value;
                        if (cmbKhachHang.SelectedIndex >= 0)
                            _nhapkho.ID_KhachHang = (int)cmbKhachHang.SelectedValue;
                        if (cmbNhanVien.SelectedIndex >= 0)
                            _nhapkho.ID_NhanVien = (int)cmbNhanVien.SelectedValue;
                        _nhapkho.CoHoaDon = chkCoHoaDon.Checked;
                        _cNK.XoaCT(_nhapkho);
                        int TongCong = 0, ThucTra = 0;
                        foreach (DataGridViewRow item in dgvSanPham.Rows)
                            if (item.Cells["KyHieu"].Value != null && item.Cells["KyHieu"].Value.ToString() != "")
                            {
                                SanPham sp = _cSP.getSP_KyHieu(item.Cells["KyHieu"].Value.ToString());
                                NhapKho_ChiTiet enCT = new NhapKho_ChiTiet();
                                enCT.ID_SanPham = sp.ID;
                                enCT.SoLuong = int.Parse(item.Cells["SoLuong"].Value.ToString());
                                enCT.GiaNCC = int.Parse(item.Cells["GiaNCC"].Value.ToString());
                                enCT.GiaNiemYet = int.Parse(item.Cells["GiaNiemYet"].Value.ToString());
                                enCT.GiaGiamTrucTiep = int.Parse(item.Cells["GiaGiamTrucTiep"].Value.ToString());
                                enCT.GiaGiamTyLe = int.Parse(item.Cells["GiaGiamTyLe"].Value.ToString());
                                enCT.TongCong = int.Parse(item.Cells["TongCong"].Value.ToString());
                                enCT.ThucTra = int.Parse(item.Cells["ThucTra"].Value.ToString());
                                _nhapkho.NhapKho_ChiTiets.Add(enCT);
                                TongCong += enCT.TongCong;
                                ThucTra += enCT.ThucTra;
                            }
                        if (chkChuyenKhoan.Checked == true)
                        {
                            _nhapkho.ChuyenKhoan = true;
                            _nhapkho.NhanVien_SoTien = TongCong - ThucTra;
                            _nhapkho.NhanVien_GiuTien = true;
                        }
                        else
                        {
                            _nhapkho.ChuyenKhoan = false;
                            _nhapkho.NhanVien_SoTien = 0;
                            _nhapkho.NhanVien_GiuTien = false;
                        }
                        _nhapkho.TongCong = TongCong;
                        _nhapkho.ThucTra = ThucTra;
                        if (_cNK.Sua(_nhapkho) == true)
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cNK.getDS(dateTu.Value, dateDen.Value);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _nhapkho = _cNK.get(int.Parse(dgvDanhSach["ID_NK", e.RowIndex].Value.ToString()));
                loadEntity(_nhapkho);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
