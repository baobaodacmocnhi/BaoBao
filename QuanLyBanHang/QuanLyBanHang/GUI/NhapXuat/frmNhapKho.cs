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
            _nhapkho = null;
        }

        public void loadEntity(NhapKho en)
        {
            dateNgayLap.Value = en.NgayLap.Value;
            if(en.ID_KhachHang!=null)
            cmbKhachHang.SelectedValue = en.ID_KhachHang;
            if (en.ID_NhanVien != null)
                cmbNhanVien.SelectedValue = en.ID_NhanVien;
            chkCoHoaDon.Checked = en.CoHoaDon;
            dgvSanPham.Rows.Clear();
            foreach (NhapKho_ChiTiet item in en.NhapKho_ChiTiets.ToList())
            {
                var index = dgvSanPham.Rows.Add();
                //dgvSanPham.Rows[index].Cells["ID_BoCT"].Value = item.ID_Bo;
                //dgvSanPham.Rows[index].Cells["ID_SanPham"].Value = item.ID_SanPham;
                //dgvSanPham.Rows[index].Cells["KyHieu_CT"].Value = item.SanPham1.KyHieu;
                //dgvSanPham.Rows[index].Cells["HoTen_CT"].Value = item.SanPham1.HoTen;
                //dgvSanPham.Rows[index].Cells["SoLuong_CT"].Value = item.SoLuong;
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
                dgvSanPham["GiaNiemYet", e.RowIndex].Value = sp.DonGia;
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
                    dgvSanPham["GiaNiemYet", e.RowIndex].Value = sp.DonGia;
                }
                else
                    if (dgvSanPham.Columns[e.ColumnIndex].Name == "HoTen" && dgvSanPham.Columns[e.ColumnIndex].Name == "HoTen")
                    {

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
            dgvSanPham.DataSource = _cNK.getDS(dateTu.Value, dateDen.Value);
        }
    }
}
