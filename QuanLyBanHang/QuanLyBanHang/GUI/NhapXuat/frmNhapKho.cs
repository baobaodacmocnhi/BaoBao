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

namespace QuanLyBanHang.GUI.NhapXuat
{
    public partial class frmNhapKho : Form
    {
        string _mnu = "mnuNhapKho";
        CSanPham _cSP = new CSanPham();
        CKhachHang _cKH = new CKhachHang();
        CNguoiDung _cND = new CNguoiDung();
        AutoCompleteStringCollection autoHoTen_SP = new AutoCompleteStringCollection();
        AutoCompleteStringCollection autoKyHieu_SP = new AutoCompleteStringCollection();

        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            loadAutoCompleteSP();
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
    }
}
