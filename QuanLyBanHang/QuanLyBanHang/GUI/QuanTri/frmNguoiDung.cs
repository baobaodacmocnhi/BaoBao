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

namespace QuanLyBanHang.GUI.QuanTri
{
    public partial class frmNguoiDung : Form
    {
        CNhom _cNhom = new CNhom();
        CPhongBan _cPB = new CPhongBan();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CMenu _cMenu = new CMenu();
        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();
        string _mnu = "mnuNguoiDung";
        BindingList<User> _blNguoiDung;
        User _user = null;


        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            dgvNguoiDung.AutoGenerateColumns = false;

            cmbPhongBan.DataSource = _cPB.getDS();
            cmbPhongBan.DisplayMember = "HoTen";
            cmbPhongBan.ValueMember = "ID";

            cmbNhom.DataSource = _cNhom.GetDS();
            cmbNhom.DisplayMember = "TenNhom";
            cmbNhom.ValueMember = "MaNhom";
            //cmbNhom.SelectedIndex = -1;

            Clear();
        }

        public void Clear()
        {
            txtHoTen.Text = "";
            radNam.Checked = true;
            dateNgaySinh.Value = DateTime.Now;
            txtDiaChi.Text = "";
            txtLuong.Text = "";
            txtPhuCap.Text = "";
            txtDienThoai.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cmbPhongBan.SelectedIndex = -1;
            cmbNhom.SelectedIndex = -1;
            picHinh.Image = QuanLyBanHang.Properties.Resources.questionmark128x128;
            chkAn.Checked = false;
            chkChamCong.Checked = false;
            _user = null;
            if (CNguoiDung.Admin)
            {
                chkAn.Visible = true;
                _blNguoiDung = new BindingList<User>(_cNguoiDung.GetDS_Admin());
            }
            else
            {
                chkAn.Visible = false;
                _blNguoiDung = new BindingList<User>(_cNguoiDung.GetDSExceptMaND(CNguoiDung.MaU));
            }
            dgvNguoiDung.DataSource = _blNguoiDung;
        }

        public void loadEntity(User en)
        {
            txtHoTen.Text = en.HoTen;
            if (en.GioiTinh == true)
                radNam.Checked = true;
            else
                radNu.Checked = true;
            if (en.NgaySinh != null)
                dateNgaySinh.Value = en.NgaySinh.Value;
            txtDiaChi.Text = en.DiaChi;
            if (en.Luong != null)
                txtLuong.Text = en.Luong.Value.ToString();
            else
                txtLuong.Text = "";
            if (en.PhuCap != null)
                txtPhuCap.Text = en.PhuCap.Value.ToString();
            else
                txtPhuCap.Text = "";
            txtDienThoai.Text = en.DienThoai;
            txtTaiKhoan.Text = en.TaiKhoan;
            txtMatKhau.Text = en.MatKhau;
            if (en.IDPhong != null)
                cmbPhongBan.SelectedValue = en.IDPhong;
            else
                cmbPhongBan.SelectedIndex = -1;
            if (en.MaNhom != null)
                cmbNhom.SelectedValue = en.MaNhom;
            else
                cmbNhom.SelectedIndex = -1;
            if (en.Hinh != null)
                picHinh.Image = _cNguoiDung.byteArrayToImage(en.Hinh.ToArray());
            else
                picHinh.Image = QuanLyBanHang.Properties.Resources.questionmark128x128;
            chkAn.Checked = en.An;
            chkChamCong.Checked = en.ChamCong;
            gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSByMaND(false, en.MaU);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                    {
                        User nguoidung = new User();
                        nguoidung.HoTen = txtHoTen.Text.Trim();
                        if (radNam.Checked == true)
                            nguoidung.GioiTinh = true;
                        else
                            nguoidung.GioiTinh = false;
                        nguoidung.NgaySinh = dateNgaySinh.Value;
                        nguoidung.DiaChi = txtDiaChi.Text.Trim();
                        if (txtLuong.Text.Trim() != "")
                            nguoidung.Luong = int.Parse(txtLuong.Text.Trim());
                        if (txtPhuCap.Text.Trim() != "")
                            nguoidung.PhuCap = int.Parse(txtPhuCap.Text.Trim());
                        nguoidung.DienThoai = txtDienThoai.Text.Trim();
                        nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                        nguoidung.MatKhau = txtMatKhau.Text.Trim();
                        nguoidung.STT = _cNguoiDung.GetMaxSTT() + 1;
                        if (cmbPhongBan.SelectedIndex != -1)
                            nguoidung.IDPhong = (int)cmbPhongBan.SelectedValue;
                        if (cmbNhom.SelectedIndex != -1)
                            nguoidung.MaNhom = (int)cmbNhom.SelectedValue;
                        if (picHinh.Image != null)
                            nguoidung.Hinh = _cNguoiDung.imgToByteArray(picHinh.Image);
                        nguoidung.An = chkAn.Checked;
                        nguoidung.ChamCong = chkChamCong.Checked;
                        ///tự động thêm quyền cho người mới
                        foreach (var item in _cMenu.GetDS())
                        {
                            PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                            phanquyennguoidung.MaMenu = item.MaMenu;
                            phanquyennguoidung.MaU = nguoidung.MaU;
                            nguoidung.PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                        }
                        if (_cNguoiDung.Them(nguoidung))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_user != null)
                    {
                        if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                        {
                            _user.HoTen = txtHoTen.Text.Trim();
                            _user.DienThoai = txtDienThoai.Text.Trim();
                            _user.TaiKhoan = txtTaiKhoan.Text.Trim();
                            _user.MatKhau = txtMatKhau.Text.Trim();
                            if (cmbPhongBan.SelectedIndex != -1)
                                _user.IDPhong = (int)cmbPhongBan.SelectedValue;
                            if (cmbNhom.SelectedIndex != -1)
                                _user.MaNhom = (int)cmbNhom.SelectedValue;
                            _user.An = chkAn.Checked;
                            _user.ChamCong = chkChamCong.Checked;

                            _cNguoiDung.Sua(_user);
                        }
                        DataTable dt = ((DataView)gridView.DataSource).Table;
                        foreach (DataRow item in dt.Rows)
                        {
                            PhanQuyenNguoiDung phanquyennguoidung = _cPhanQuyenNguoiDung.GetByMaMenuMaND(int.Parse(item["MaMenu"].ToString()), _user.MaU);
                            if (phanquyennguoidung.Xem != bool.Parse(item["Xem"].ToString()) || phanquyennguoidung.Them != bool.Parse(item["Them"].ToString()) ||
                                phanquyennguoidung.Sua != bool.Parse(item["Sua"].ToString()) || phanquyennguoidung.Xoa != bool.Parse(item["Xoa"].ToString()) ||
                                phanquyennguoidung.QuanLy != bool.Parse(item["QuanLy"].ToString()))
                            {
                                phanquyennguoidung.Xem = bool.Parse(item["Xem"].ToString());
                                phanquyennguoidung.Them = bool.Parse(item["Them"].ToString());
                                phanquyennguoidung.Sua = bool.Parse(item["Sua"].ToString());
                                phanquyennguoidung.Xoa = bool.Parse(item["Xoa"].ToString());
                                phanquyennguoidung.QuanLy = bool.Parse(item["QuanLy"].ToString());
                                _cPhanQuyenNguoiDung.Sua(phanquyennguoidung);
                            }
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_user != null)
                    {
                        ///xóa quan hệ 1 nhiều
                        //_cPhanQuyenNguoiDung.Xoa(nguoidung.PhanQuyenNguoiDungs.ToList());
                        _user.An = true;
                        if (_cNguoiDung.Sua(_user) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Người Dùng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNguoiDung_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNguoiDung.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNguoiDung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "ToanQuyen")
                if (bool.Parse(e.Value.ToString()))
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xem"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Them"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Sua"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xoa"], "True");
                }
                else
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xem"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Them"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Sua"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xoa"], "False");
                }
        }

        //private void dgvNguoiDung_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Up))
        //    {
        //        moveUp();
        //    }
        //    if (e.KeyCode.Equals(Keys.Down))
        //    {
        //        moveDown();
        //    }
        //    e.Handled = true;
        //}

        //private void moveUp()
        //{
        //    if (dgvNguoiDung.RowCount > 0)
        //    {
        //        if (dgvNguoiDung.SelectedRows.Count > 0)
        //        {
        //            int rowCount = dgvNguoiDung.Rows.Count;
        //            int index = dgvNguoiDung.SelectedCells[0].OwningRow.Index;

        //            if (index == 0)
        //            {
        //                return;
        //            }
        //            //DataGridViewRowCollection rows = dgvNguoiDung.Rows;

        //            // remove the previous row and add it behind the selected row.
        //            //DataGridViewRow prevRow = rows[index - 1];
        //            //rows.Remove(prevRow);
        //            //prevRow.Frozen = false;
        //            //rows.Insert(index, prevRow);
        //            //dgvNguoiDung.ClearSelection();
        //            //dgvNguoiDung.Rows[index - 1].Selected = true;
        //            var itemToMoveUp = this._blNguoiDung[index];
        //            this._blNguoiDung.RemoveAt(index);
        //            this._blNguoiDung.Insert(index - 1, itemToMoveUp);
        //            dgvNguoiDung.ClearSelection();
        //            dgvNguoiDung.Rows[index - 1].Selected = true;
        //        }
        //    }
        //}

        //private void moveDown()
        //{
        //    if (dgvNguoiDung.RowCount > 0)
        //    {
        //        if (dgvNguoiDung.SelectedRows.Count > 0)
        //        {
        //            int rowCount = dgvNguoiDung.Rows.Count;
        //            int index = dgvNguoiDung.SelectedCells[0].OwningRow.Index;

        //            if (index == (rowCount - 2)) // include the header row
        //            {
        //                return;
        //            }
        //            //DataGridViewRowCollection rows = dgvNguoiDung.Rows;

        //            // remove the next row and add it in front of the selected row.
        //            //DataGridViewRow nextRow = rows[index + 1];
        //            //rows.Remove(nextRow);
        //            //nextRow.Frozen = false;
        //            //rows.Insert(index, nextRow);
        //            //dgvNguoiDung.ClearSelection();
        //            //dgvNguoiDung.Rows[index + 1].Selected = true;
        //            var itemToMoveDown = this._blNguoiDung[index];
        //            this._blNguoiDung.RemoveAt(index);
        //            this._blNguoiDung.Insert(index + 1, itemToMoveDown);
        //            dgvNguoiDung.ClearSelection();
        //            dgvNguoiDung.Rows[index + 1].Selected = true;
        //        }
        //    }
        //}

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvNguoiDung_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvNguoiDung.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvNguoiDung.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._blNguoiDung[rowIndexFromMouseDown];
                _blNguoiDung.RemoveAt(rowIndexFromMouseDown);
                _blNguoiDung.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _blNguoiDung.Count; i++)
                {
                    _blNguoiDung[i].STT = i + 1;
                }
                _cNguoiDung.SubmitChanges();
            }
        }

        private void dgvNguoiDung_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvNguoiDung_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvNguoiDung.SelectedRows[0];
                    rowIndexFromMouseDown = dgvNguoiDung.SelectedRows[0].Index;
                    dgvNguoiDung.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _user = _cNguoiDung.GetByMaND(int.Parse(dgvNguoiDung["MaU", e.RowIndex].Value.ToString()));
                loadEntity(_user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //byte[] bytes = System.IO.File.ReadAllBytes(dialog.FileName);
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
