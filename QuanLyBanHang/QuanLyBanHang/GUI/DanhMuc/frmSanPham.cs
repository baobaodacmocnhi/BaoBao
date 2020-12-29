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
using System.Transactions;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmSanPham : Form
    {
        string _mnu = "mnuSanPham";
        CSanPham _cSP = new CSanPham();
        SanPham _sp = null;
        SanPham _spBo = null;
        AutoCompleteStringCollection autoHoTen_SP = new AutoCompleteStringCollection();

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
            loadAutoCompleteSP();
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

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DonGia" && e.Value != null)
            {
                e.Value = String.Format("{0:0,0}", e.Value);
            }
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "SoLuong" && e.Value != null)
            {
                e.Value = String.Format("{0:0,0}", e.Value);
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

        public void loadAutoCompleteSP()
        {
            DataTable dt = _cSP.getDS_SP();
            foreach (DataRow item in dt.Rows)
            {
                autoHoTen_SP.Add(item["HoTen"].ToString());
            }
        }

        public void ClearBo()
        {
            txtHoTen_Bo.Text = "";
            txtDonGia_Bo.Text = "0";
            _spBo = null;
            dgvBo_ChiTiet.Rows.Clear();
            dgvBo.DataSource = _cSP.getDS_Bo();
        }

        public void loadEntity_Bo(SanPham en)
        {
            txtHoTen_Bo.Text = en.HoTen;
            txtDonGia_Bo.Text = en.DonGia.ToString();
            dgvBo_ChiTiet.Rows.Clear();
            foreach (SanPham_Bo item in en.SanPham_Bos.ToList())
            {
                var index = dgvBo_ChiTiet.Rows.Add();
                dgvBo_ChiTiet.Rows[index].Cells["ID_BoCT"].Value = item.ID_Bo;
                dgvBo_ChiTiet.Rows[index].Cells["ID_SanPham"].Value = item.ID_SanPham;
                dgvBo_ChiTiet.Rows[index].Cells["HoTen_CT"].Value = item.SanPham1.HoTen;
                dgvBo_ChiTiet.Rows[index].Cells["SoLuong_CT"].Value = item.SoLuong;
            }
        }

        private void dgvBo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _spBo = _cSP.getBo(int.Parse(dgvBo.CurrentRow.Cells["ID_Bo"].Value.ToString()));
                loadEntity_Bo(_spBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBo.Columns[e.ColumnIndex].Name == "DonGia_Bo" && e.Value != null)
            {
                e.Value = String.Format("{0:0,0}", e.Value);
            }
        }

        private void dgvBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnThemBo_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cSP.checkExists_SP_HoTen(txtHoTen_Bo.Text.Trim()) == true)
                    {
                        MessageBox.Show("Họ Tên đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SanPham spBo = new SanPham();
                    spBo.HoTen = txtHoTen_Bo.Text.Trim();
                    spBo.DonGia = int.Parse(txtDonGia_Bo.Text.Trim());
                    spBo.Bo = true;
                    var transactionOptions = new TransactionOptions();
                    transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                    {
                        if (_cSP.ThemSP(spBo) == true)
                        {
                            foreach (DataGridViewRow item in dgvBo_ChiTiet.Rows)
                                if (item.Cells["HoTen_CT"].Value != null && item.Cells["HoTen_CT"].Value.ToString() != "")
                                {
                                    SanPham sp = _cSP.getSP(item.Cells["HoTen_CT"].Value.ToString());
                                    SanPham_Bo spBoCT = new SanPham_Bo();
                                    spBoCT.ID_Bo = spBo.ID;
                                    spBoCT.ID_SanPham = sp.ID;
                                    spBoCT.SoLuong = int.Parse(item.Cells["SoLuong_CT"].Value.ToString());
                                    _cSP.ThemBoCT(spBoCT);
                                }
                            scope.Complete();
                            scope.Dispose();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearBo();
                        }
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
                        if (_spBo != null)
                        {
                            if (_cSP.XoaSP(_spBo) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearBo();
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
                    if (_spBo != null)
                    {
                        if (_spBo.HoTen != txtHoTen_Bo.Text.Trim())
                        {
                            if (_cSP.checkExists_SP_HoTen(txtHoTen_Bo.Text.Trim()) == true)
                            {
                                MessageBox.Show("Họ Tên đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        _spBo.HoTen = txtHoTen_Bo.Text.Trim();
                        _spBo.DonGia = int.Parse(txtDonGia_Bo.Text.Trim());
                        _cSP.XoaBoCT(_spBo);
                        foreach (DataGridViewRow item in dgvBo_ChiTiet.Rows)
                            if (item.Cells["HoTen_CT"].Value != null && item.Cells["HoTen_CT"].Value.ToString() != "")
                            {
                                SanPham sp = _cSP.getSP(item.Cells["HoTen_CT"].Value.ToString());
                                SanPham_Bo spBoCT = new SanPham_Bo();
                                spBoCT.ID_Bo = _spBo.ID;
                                spBoCT.ID_SanPham = sp.ID;
                                spBoCT.SoLuong = int.Parse(item.Cells["SoLuong_CT"].Value.ToString());
                                _cSP.ThemBoCT(spBoCT);
                            }
                        if (_cSP.SuaSP(_spBo) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearBo();
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

        private void dgvBo_ChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBo_ChiTiet.Columns[e.ColumnIndex].Name == "HoTen_CT")
            {
                dgvBo_ChiTiet["SoLuong_CT", e.RowIndex].Value = 0;
            }
        }




    }
}
