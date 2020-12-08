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
using QuanLyBanHang.BaoCao;
using QuanLyBanHang.BaoCao.QuanTri;
using QuanLyBanHang.GUI.BaoCao;


namespace QuanLyBanHang.GUI.QuanTri
{
    public partial class frmChamCong : Form
    {
        string _mnu = "mnuChamCong";
        CChamCong _cChamCong = new CChamCong();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        ChamCong _en = null;
        string[] _ngays = { "N1", "N2", "N3", "N4", "N5", "N6", "N7", "N8", "N9", "N10", "N11", "N12", "N13", "N14", "N15", "N16", "N17", "N18", "N19", "N20", "N21", "N22", "N23", "N24", "N25", "N26", "N27", "N28", "N29", "N30", "N31" };

        public frmChamCong()
        {
            InitializeComponent();
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            dgvChamCong_ChiTiet.AutoGenerateColumns = false;
            dgvChamCong_TinhLuong.AutoGenerateColumns = false;

            if (!_cChamCong.CheckExist(DateTime.Now.Month, DateTime.Now.Year))
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    List<User> lstND = _cNguoiDung.getDS_ChamCong();

                    ChamCong chamcong = new ChamCong();
                    chamcong.Thang = DateTime.Now.Month;
                    chamcong.Nam = DateTime.Now.Year;

                    foreach (User item in lstND)
                    {
                        ChamCong_ChiTiet ctchamcong = new ChamCong_ChiTiet();
                        ctchamcong.MaU = item.MaU;
                        ctchamcong.CreateBy = CNguoiDung.MaU;
                        ctchamcong.CreateDate = DateTime.Now;

                        #region
                        //for (int i = 1; i <= GetTongNgay(DateTime.Now.Month, DateTime.Now.Year); i++)
                        //{
                        //    DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i);

                        //    if (time.DayOfWeek == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Sunday)
                        //    {
                        //        #region Thứ 7 & CN

                        //        switch (i)
                        //        {
                        //            case 1:
                        //                ctchamcong.N1 = false;
                        //                break;
                        //            case 2:
                        //                ctchamcong.N2 = false;
                        //                break;
                        //            case 3:
                        //                ctchamcong.N3 = false;
                        //                break;
                        //            case 4:
                        //                ctchamcong.N4 = false;
                        //                break;
                        //            case 5:
                        //                ctchamcong.N5 = false;
                        //                break;
                        //            case 6:
                        //                ctchamcong.N6 = false;
                        //                break;
                        //            case 7:
                        //                ctchamcong.N7 = false;
                        //                break;
                        //            case 8:
                        //                ctchamcong.N8 = false;
                        //                break;
                        //            case 9:
                        //                ctchamcong.N9 = false;
                        //                break;
                        //            case 10:
                        //                ctchamcong.N10 = false;
                        //                break;
                        //            case 11:
                        //                ctchamcong.N11 = false;
                        //                break;
                        //            case 12:
                        //                ctchamcong.N12 = false;
                        //                break;
                        //            case 13:
                        //                ctchamcong.N13 = false;
                        //                break;
                        //            case 14:
                        //                ctchamcong.N14 = false;
                        //                break;
                        //            case 15:
                        //                ctchamcong.N15 = false;
                        //                break;
                        //            case 16:
                        //                ctchamcong.N16 = false;
                        //                break;
                        //            case 17:
                        //                ctchamcong.N17 = false;
                        //                break;
                        //            case 18:
                        //                ctchamcong.N18 = false;
                        //                break;
                        //            case 19:
                        //                ctchamcong.N19 = false;
                        //                break;
                        //            case 20:
                        //                ctchamcong.N20 = false;
                        //                break;
                        //            case 21:
                        //                ctchamcong.N21 = false;
                        //                break;
                        //            case 22:
                        //                ctchamcong.N22 = false;
                        //                break;
                        //            case 23:
                        //                ctchamcong.N23 = false;
                        //                break;
                        //            case 24:
                        //                ctchamcong.N24 = false;
                        //                break;
                        //            case 25:
                        //                ctchamcong.N25 = false;
                        //                break;
                        //            case 26:
                        //                ctchamcong.N26 = false;
                        //                break;
                        //            case 27:
                        //                ctchamcong.N27 = false;
                        //                break;
                        //            case 28:
                        //                ctchamcong.N28 = false;
                        //                break;
                        //            case 29:
                        //                ctchamcong.N29 = false;
                        //                break;
                        //            case 30:
                        //                ctchamcong.N30 = false;
                        //                break;
                        //            case 31:
                        //                ctchamcong.N31 = false;
                        //                break;
                        //            default:
                        //                break;
                        //        }

                        //        #endregion
                        //    }
                        //    else
                        //    {
                        //        #region Thứ 2, 3, 4, 5, 6

                        //        switch (i)
                        //        {
                        //            case 1:
                        //                ctchamcong.N1 = true;
                        //                break;
                        //            case 2:
                        //                ctchamcong.N2 = true;
                        //                break;
                        //            case 3:
                        //                ctchamcong.N3 = true;
                        //                break;
                        //            case 4:
                        //                ctchamcong.N4 = true;
                        //                break;
                        //            case 5:
                        //                ctchamcong.N5 = true;
                        //                break;
                        //            case 6:
                        //                ctchamcong.N6 = true;
                        //                break;
                        //            case 7:
                        //                ctchamcong.N7 = true;
                        //                break;
                        //            case 8:
                        //                ctchamcong.N8 = true;
                        //                break;
                        //            case 9:
                        //                ctchamcong.N9 = true;
                        //                break;
                        //            case 10:
                        //                ctchamcong.N10 = true;
                        //                break;
                        //            case 11:
                        //                ctchamcong.N11 = true;
                        //                break;
                        //            case 12:
                        //                ctchamcong.N12 = true;
                        //                break;
                        //            case 13:
                        //                ctchamcong.N13 = true;
                        //                break;
                        //            case 14:
                        //                ctchamcong.N14 = true;
                        //                break;
                        //            case 15:
                        //                ctchamcong.N15 = true;
                        //                break;
                        //            case 16:
                        //                ctchamcong.N16 = true;
                        //                break;
                        //            case 17:
                        //                ctchamcong.N17 = true;
                        //                break;
                        //            case 18:
                        //                ctchamcong.N18 = true;
                        //                break;
                        //            case 19:
                        //                ctchamcong.N19 = true;
                        //                break;
                        //            case 20:
                        //                ctchamcong.N20 = true;
                        //                break;
                        //            case 21:
                        //                ctchamcong.N21 = true;
                        //                break;
                        //            case 22:
                        //                ctchamcong.N22 = true;
                        //                break;
                        //            case 23:
                        //                ctchamcong.N23 = true;
                        //                break;
                        //            case 24:
                        //                ctchamcong.N24 = true;
                        //                break;
                        //            case 25:
                        //                ctchamcong.N25 = true;
                        //                break;
                        //            case 26:
                        //                ctchamcong.N26 = true;
                        //                break;
                        //            case 27:
                        //                ctchamcong.N27 = true;
                        //                break;
                        //            case 28:
                        //                ctchamcong.N28 = true;
                        //                break;
                        //            case 29:
                        //                ctchamcong.N29 = true;
                        //                break;
                        //            case 30:
                        //                ctchamcong.N30 = true;
                        //                break;
                        //            case 31:
                        //                ctchamcong.N31 = true;
                        //                break;
                        //            default:
                        //                break;
                        //        }

                        //        #endregion
                        //    }
                        //}
                        #endregion

                        chamcong.ChamCong_ChiTiets.Add(ctchamcong);
                    }

                    _cChamCong.Them(chamcong);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            dgvChamCong.DataSource = _cChamCong.getDS();
        }



        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region textbox=0

                txtN1.Text = "0";
                txtN2.Text = "0";
                txtN3.Text = "0";
                txtN4.Text = "0";
                txtN5.Text = "0";
                txtN6.Text = "0";
                txtN7.Text = "0";
                txtN8.Text = "0";
                txtN9.Text = "0";
                txtN10.Text = "0";
                txtN11.Text = "0";
                txtN12.Text = "0";
                txtN13.Text = "0";
                txtN14.Text = "0";
                txtN15.Text = "0";
                txtN16.Text = "0";
                txtN17.Text = "0";
                txtN18.Text = "0";
                txtN19.Text = "0";
                txtN20.Text = "0";
                txtN21.Text = "0";
                txtN22.Text = "0";
                txtN23.Text = "0";
                txtN24.Text = "0";
                txtN25.Text = "0";
                txtN26.Text = "0";
                txtN27.Text = "0";
                txtN28.Text = "0";
                txtN29.Text = "0";
                txtN30.Text = "0";
                txtN31.Text = "0";

                #endregion

                _en = _cChamCong.get(int.Parse(dgvChamCong["ID", e.RowIndex].Value.ToString()));
                dgvChamCong_ChiTiet.DataSource = _cChamCong.getDS_ChiTiet(_en.ID);

                for (int i = 1; i <= _cChamCong.getTongSoNgayTrongThang(_en.Thang.Value, _en.Nam.Value); i++)
                {
                    DateTime time = new DateTime(_en.Nam.Value, _en.Thang.Value, i);

                    if (time.DayOfWeek == DayOfWeek.Sunday)
                        dgvChamCong_ChiTiet.Columns["N" + i].DefaultCellStyle.BackColor = Color.Orange;
                    else
                        dgvChamCong_ChiTiet.Columns["N" + i].DefaultCellStyle.BackColor = Color.White;
                }

                foreach (DataGridViewRow item in dgvChamCong_ChiTiet.Rows)
                {
                    #region count textbox

                    if (bool.Parse(item.Cells["N1"].Value.ToString()))
                    {
                        txtN1.Text = (int.Parse(txtN1.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N2"].Value.ToString()))
                    {
                        txtN2.Text = (int.Parse(txtN2.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N3"].Value.ToString()))
                    {
                        txtN3.Text = (int.Parse(txtN3.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N4"].Value.ToString()))
                    {
                        txtN4.Text = (int.Parse(txtN4.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N5"].Value.ToString()))
                    {
                        txtN5.Text = (int.Parse(txtN5.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N6"].Value.ToString()))
                    {
                        txtN6.Text = (int.Parse(txtN6.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N7"].Value.ToString()))
                    {
                        txtN7.Text = (int.Parse(txtN7.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N8"].Value.ToString()))
                    {
                        txtN8.Text = (int.Parse(txtN8.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N9"].Value.ToString()))
                    {
                        txtN9.Text = (int.Parse(txtN9.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N10"].Value.ToString()))
                    {
                        txtN10.Text = (int.Parse(txtN10.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N11"].Value.ToString()))
                    {
                        txtN11.Text = (int.Parse(txtN11.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N12"].Value.ToString()))
                    {
                        txtN12.Text = (int.Parse(txtN12.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N13"].Value.ToString()))
                    {
                        txtN13.Text = (int.Parse(txtN13.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N14"].Value.ToString()))
                    {
                        txtN14.Text = (int.Parse(txtN14.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N15"].Value.ToString()))
                    {
                        txtN15.Text = (int.Parse(txtN15.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N16"].Value.ToString()))
                    {
                        txtN16.Text = (int.Parse(txtN16.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N17"].Value.ToString()))
                    {
                        txtN17.Text = (int.Parse(txtN17.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N18"].Value.ToString()))
                    {
                        txtN18.Text = (int.Parse(txtN18.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N19"].Value.ToString()))
                    {
                        txtN19.Text = (int.Parse(txtN19.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N20"].Value.ToString()))
                    {
                        txtN20.Text = (int.Parse(txtN20.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N21"].Value.ToString()))
                    {
                        txtN21.Text = (int.Parse(txtN21.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N22"].Value.ToString()))
                    {
                        txtN22.Text = (int.Parse(txtN22.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N23"].Value.ToString()))
                    {
                        txtN23.Text = (int.Parse(txtN23.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N24"].Value.ToString()))
                    {
                        txtN24.Text = (int.Parse(txtN24.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N25"].Value.ToString()))
                    {
                        txtN25.Text = (int.Parse(txtN25.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N26"].Value.ToString()))
                    {
                        txtN26.Text = (int.Parse(txtN26.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N27"].Value.ToString()))
                    {
                        txtN27.Text = (int.Parse(txtN27.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N28"].Value.ToString()))
                    {
                        txtN28.Text = (int.Parse(txtN28.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N29"].Value.ToString()))
                    {
                        txtN29.Text = (int.Parse(txtN29.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N30"].Value.ToString()))
                    {
                        txtN30.Text = (int.Parse(txtN30.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    if (bool.Parse(item.Cells["N31"].Value.ToString()))
                    {
                        txtN31.Text = (int.Parse(txtN31.Text) + 1).ToString();
                        item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                    }
                    #endregion

                    //if (bool.Parse(item.Cells["ToTruong"].Value.ToString()) == true)
                    //    item.DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                loaddgvChamCong_TinhLuong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChamCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvChamCong.Columns[e.ColumnIndex].Name == "Chot")
                    {
                        //ChamCong en = _cChamCong.get(int.Parse(dgvChamCong["ID",e.RowIndex].Value.ToString()));
                        _en.Chot = bool.Parse(dgvChamCong["Chot", e.RowIndex].Value.ToString());
                        _cChamCong.Sua(_en);
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

        private void dgvChamCong_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_en.Chot == true)
                    {
                        MessageBox.Show(_en.Thang.Value + "/" + _en.Nam.Value + " đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_ngays.Contains(dgvChamCong_ChiTiet.Columns[e.ColumnIndex].Name) == true)
                        _cChamCong.suaChamCong(_en.ID, int.Parse(dgvChamCong_ChiTiet["MaU", e.RowIndex].Value.ToString()), dgvChamCong_ChiTiet.Columns[e.ColumnIndex].Name, bool.Parse(dgvChamCong_ChiTiet[e.ColumnIndex, e.RowIndex].Value.ToString()));
                    if (dgvChamCong_ChiTiet.Columns[e.ColumnIndex].Name == "PhuCap")
                    {
                        _cChamCong.suaPhuCap(_en.ID, int.Parse(dgvChamCong_ChiTiet["MaU", e.RowIndex].Value.ToString()), dgvChamCong_ChiTiet["PhuCap", e.RowIndex].Value.ToString());
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

        private void dgvChamCong_ChiTiet_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvChamCong_ChiTiet.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        public void loaddgvChamCong_TinhLuong()
        {
            try
            {
                dgvChamCong_TinhLuong.DataSource = _cChamCong.getDS_ChiTiet(_en.ID);
                if (_en.Chot == false)
                {
                    int Thang=_en.Thang.Value,Nam=_en.Nam.Value;
                    if (Thang == 1)
                    {
                        Thang = 12;
                        Nam -= 1;
                    }
                    else
                        Thang -= 1;
                    ChamCong enPrevious = _cChamCong.get(Thang, Nam);
                    if (enPrevious != null)
                    {
                        foreach (DataGridViewRow item in dgvChamCong_TinhLuong.Rows)
                        {
                            ChamCong_ChiTiet enPrevious_CT=enPrevious.ChamCong_ChiTiets.SingleOrDefault(itemA=>itemA.ID==int.Parse(item.Cells["ID_TL"].Value.ToString())&&itemA.MaU==int.Parse(item.Cells["MaU_TL"].Value.ToString()));
                            if(enPrevious_CT!=null)
                            {
                                item.Cells["LuongCoBan"].Value = enPrevious_CT.LuongCoBan;
                                item.Cells["LuongKhoan"].Value = enPrevious_CT.LuongKhoan;
                                item.Cells["TamUng1"].Value = enPrevious_CT.TamUng1;
                                item.Cells["TamUng2"].Value = enPrevious_CT.TamUng2;
                                item.Cells["TamUng3"].Value = enPrevious_CT.TamUng3;
                                item.Cells["BoiDuong"].Value = enPrevious_CT.BoiDuong;
                                item.Cells["ThuongDotXuat"].Value = enPrevious_CT.ThuongDotXuat;
                                item.Cells["ThuongLe"].Value = enPrevious_CT.ThuongLe;
                                item.Cells["ThuongThang"].Value = enPrevious_CT.ThuongThang;
                                item.Cells["ThuongQuy"].Value = enPrevious_CT.ThuongQuy;
                                item.Cells["ThuongNam"].Value = enPrevious_CT.ThuongNam;
                                item.Cells["PhuCapXang"].Value = enPrevious_CT.PhuCapXang;
                                item.Cells["PhuCapDienThoai"].Value = enPrevious_CT.PhuCapDienThoai;
                                item.Cells["TienCom1Ngay"].Value = enPrevious_CT.TienCom1Ngay;
                                //item.Cells["LuongThucLanh"].Value = enPrevious_CT.LuongThucLanh;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuLuong_Click(object sender, EventArgs e)
        {
            //dsBaoCao ds = new dsBaoCao();
            //foreach (DataGridViewRow item in dgvChamCong.Rows)
            //{
            //    DataRow dr = ds.Tables["ChamCong"].NewRow();
            //    dr["ThoiGian"] = dateChamCong.Value.ToString("MM/yyyy");
            //    dr["HoTen"] = item.Cells["HoTen"].Value;
            //    dr["N1"] = item.Cells["N1"].Value;
            //    dr["N2"] = item.Cells["N2"].Value;
            //    dr["N3"] = item.Cells["N3"].Value;
            //    dr["N4"] = item.Cells["N4"].Value;
            //    dr["N5"] = item.Cells["N5"].Value;
            //    dr["N6"] = item.Cells["N6"].Value;
            //    dr["N7"] = item.Cells["N7"].Value;
            //    dr["N8"] = item.Cells["N8"].Value;
            //    dr["N9"] = item.Cells["N9"].Value;
            //    dr["N10"] = item.Cells["N10"].Value;
            //    dr["N11"] = item.Cells["N11"].Value;
            //    dr["N12"] = item.Cells["N12"].Value;
            //    dr["N13"] = item.Cells["N13"].Value;
            //    dr["N14"] = item.Cells["N14"].Value;
            //    dr["N15"] = item.Cells["N15"].Value;
            //    dr["N16"] = item.Cells["N16"].Value;
            //    dr["N17"] = item.Cells["N17"].Value;
            //    dr["N18"] = item.Cells["N18"].Value;
            //    dr["N19"] = item.Cells["N19"].Value;
            //    dr["N20"] = item.Cells["N20"].Value;
            //    dr["N21"] = item.Cells["N21"].Value;
            //    dr["N22"] = item.Cells["N22"].Value;
            //    dr["N23"] = item.Cells["N23"].Value;
            //    dr["N24"] = item.Cells["N24"].Value;
            //    dr["N25"] = item.Cells["N25"].Value;
            //    dr["N26"] = item.Cells["N26"].Value;
            //    dr["N27"] = item.Cells["N27"].Value;
            //    dr["N28"] = item.Cells["N28"].Value;
            //    dr["N29"] = item.Cells["N29"].Value;
            //    dr["N30"] = item.Cells["N30"].Value;
            //    dr["N31"] = item.Cells["N31"].Value;
            //    dr["Nghi"] = item.Cells["Nghi"].Value;
            //    dr["XS"] = item.Cells["XS"].Value;
            //    dr["KK"] = item.Cells["KK"].Value;
            //    ds.Tables["ChamCong"].Rows.Add(dr);
            //}
            //rptChamCong rpt = new rptChamCong();
            //rpt.SetDataSource(ds);
            //frmBaoCao frm = new frmBaoCao(rpt);
            //frm.ShowDialog();
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_en.Chot == false)
                    {
                        MessageBox.Show(_en.Thang.Value + "/" + _en.Nam.Value + " chưa Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int TongSoNgay = _cChamCong.getTongSoNgayTrongThang(_en.Thang.Value, _en.Nam.Value);
                    int TongSoNgayCN = 0;
                    for (int i = 1; i <= TongSoNgay; i++)
                    {
                        DateTime time = new DateTime(_en.Nam.Value, _en.Thang.Value, i);
                        if (time.DayOfWeek == DayOfWeek.Sunday)
                            TongSoNgayCN++;
                    }
                    dsBaoCao dsBaoCao = new dsBaoCao();
                    foreach (ChamCong_ChiTiet item in _en.ChamCong_ChiTiets.ToList())
                    {
                        int TienLuong1Ngay = (int)Math.Round((double)0 / CNguoiDung.SoNgayTinhLuong);
                        int TongSoNgayNghi = 0;
                        DataRow dr = dsBaoCao.Tables["dtBaoCao"].NewRow();
                        dr["PhongBan"] = item.User.PhongBan.HoTen;
                        dr["NhanVien"] = item.User.HoTen;
                        #region count Ngày Nghỉ

                        if (item.N1 == true)
                            TongSoNgayNghi++;
                        if (item.N2 == true)
                            TongSoNgayNghi++;
                        if (item.N3 == true)
                            TongSoNgayNghi++;
                        if (item.N4 == true)
                            TongSoNgayNghi++;
                        if (item.N5 == true)
                            TongSoNgayNghi++;
                        if (item.N6 == true)
                            TongSoNgayNghi++;
                        if (item.N7 == true)
                            TongSoNgayNghi++;
                        if (item.N8 == true)
                            TongSoNgayNghi++;
                        if (item.N9 == true)
                            TongSoNgayNghi++;
                        if (item.N10 == true)
                            TongSoNgayNghi++;
                        if (item.N11 == true)
                            TongSoNgayNghi++;
                        if (item.N12 == true)
                            TongSoNgayNghi++;
                        if (item.N13 == true)
                            TongSoNgayNghi++;
                        if (item.N14 == true)
                            TongSoNgayNghi++;
                        if (item.N15 == true)
                            TongSoNgayNghi++;
                        if (item.N16 == true)
                            TongSoNgayNghi++;
                        if (item.N17 == true)
                            TongSoNgayNghi++;
                        if (item.N18 == true)
                            TongSoNgayNghi++;
                        if (item.N19 == true)
                            TongSoNgayNghi++;
                        if (item.N20 == true)
                            TongSoNgayNghi++;
                        if (item.N21 == true)
                            TongSoNgayNghi++;
                        if (item.N22 == true)
                            TongSoNgayNghi++;
                        if (item.N23 == true)
                            TongSoNgayNghi++;
                        if (item.N24 == true)
                            TongSoNgayNghi++;
                        if (item.N25 == true)
                            TongSoNgayNghi++;
                        if (item.N26 == true)
                            TongSoNgayNghi++;
                        if (item.N27 == true)
                            TongSoNgayNghi++;
                        if (item.N28 == true)
                            TongSoNgayNghi++;
                        if (item.N29 == true)
                            TongSoNgayNghi++;
                        if (item.N30 == true)
                            TongSoNgayNghi++;
                        if (item.N31 == true)
                            TongSoNgayNghi++;
                        #endregion
                        dr["SoNgayNghi"] = TongSoNgayNghi;
                        dr["SoNgayLamViec"] = TongSoNgay - TongSoNgayCN - TongSoNgayNghi;
                        dr["Luong"] = TienLuong1Ngay * int.Parse(dr["SoNgayLamViec"].ToString());
                        dsBaoCao.Tables["dtBaoCao"].Rows.Add(dr);
                    }
                    rptBangLuong rpt = new rptBangLuong();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.Show();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChamCong_TinhLuong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }




    }
}
