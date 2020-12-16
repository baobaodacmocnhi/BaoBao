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
        SanPham_Nhom _spNhom = null;
        AutoCompleteStringCollection autoHoTen_SP = null;

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvBo.AutoGenerateColumns = false;
            ClearSP();
            ClearBo();
            DataTable dt = _cSP.getDS_SP();
            foreach (DataRow item in dt.Rows)
            {
                autoHoTen_SP.Add(item["HoTen"].ToString());
            }
        }

        public void ClearSP()
        {
            txtHoTen.Text = "";
            txtDonGia.Text = "0";
            txtModel.Text = "";
            txtSerial.Text = "";
            txtHangSanXuat.Text = "";
            _sp = null;
            dgvDanhSach.DataSource = _cSP.getDS_SP();
        }

        public void loadEntity_SP(SanPham en)
        {
            txtHoTen.Text = en.HoTen;
            txtDonGia.Text = en.DonGia.ToString();
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
                    if (_cSP.checkExists_SP_HoTen(txtHoTen.Text.Trim()) == true)
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
                    if (_cSP.ThemSP(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearSP();
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
                            if (_cSP.XoaSP(_sp) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearSP();
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
                            if (_cSP.checkExists_SP_HoTen(txtHoTen.Text.Trim()) == true)
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
                        if (_cSP.SuaSP(_sp) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSP();
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
                _sp = _cSP.getSP(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                loadEntity_SP(_sp);
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

        ////////////////////////////

        public void ClearBo()
        {
            txtHoTen_Bo.Text = "";
            txtDonGia_Bo.Text = "0";
            _spNhom = null;
            dgvBo.DataSource = _cSP.getDS_Bo();
        }

        public void loadEntity_Bo(SanPham_Nhom en)
        {
            txtHoTen_Bo.Text = en.HoTen;
            txtDonGia_Bo.Text = en.DonGia.ToString();
            dgvBo_ChiTiet.Rows.Clear();
            foreach (SanPham_Nhom_ChiTiet item in en.SanPham_Nhom_ChiTiets.ToList())
            {
                var index = dgvBo_ChiTiet.Rows.Add();
                dgvBo_ChiTiet.Rows[index].Cells["IDSanPham"].Value = item.IDSanPham;
                dgvBo_ChiTiet.Rows[index].Cells["IDSanPham_Nhom"].Value = item.IDSanPham_Nhom;
                dgvBo_ChiTiet.Rows[index].Cells["HoTen_CT"].Value = item.SanPham_Nhom.HoTen;
                dgvBo_ChiTiet.Rows[index].Cells["SoLuong_CT"].Value = item.SoLuong;
            }
        }

        private void dgvBo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _spNhom = _cSP.getBo(int.Parse(dgvBo.CurrentRow.Cells["ID_Bo"].Value.ToString()));
                loadEntity_Bo(_spNhom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemBo_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cSP.checkExists_Bo_HoTen(txtHoTen_Bo.Text.Trim()) == true)
                    {
                        MessageBox.Show("Họ Tên đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SanPham_Nhom en = new SanPham_Nhom();
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DonGia = int.Parse(txtDonGia_Bo.Text.Trim());
                    if (_cSP.ThemBo(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearBo();
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

        private void btnXoaBo_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_spNhom != null)
                        {
                            if (_cSP.XoaBo(_spNhom) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearSP();
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

        private void btnSuaBo_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_spNhom != null)
                    {
                        if (_spNhom.HoTen != txtHoTen.Text.Trim())
                        {
                            if (_cSP.checkExists_Bo_HoTen(txtHoTen_Bo.Text.Trim()) == true)
                            {
                                MessageBox.Show("Họ Tên đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        _spNhom.HoTen = txtHoTen.Text.Trim();
                        _spNhom.DonGia = int.Parse(txtDonGia_Bo.Text.Trim());
                        if (_cSP.SuaBo(_spNhom) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSP();
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

        private void dgvBo_ChiTiet_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBo_ChiTiet.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBo_ChiTiet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvBo_ChiTiet.Columns[dgvBo_ChiTiet.CurrentCell.ColumnIndex].Name == "HoTen_CT")
            {
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteCustomSource = autoHoTen_SP;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                }
            }
            else
            {
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    prodCode.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }
    }
}
