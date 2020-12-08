using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using System.Data;

namespace QuanLyBanHang.DAL.QuanTri
{
    class CNguoiDung : CDAL
    {
        static int _MaND;
        public static int MaU
        {
            get { return _MaND; }
            set { _MaND = value; }
        }

        static string _HoTen;
        public static string HoTen
        {
            get { return CNguoiDung._HoTen; }
            set { CNguoiDung._HoTen = value; }
        }

        static int _MaPhong;
        public static int MaPhong
        {
            get { return CNguoiDung._MaPhong; }
            set { CNguoiDung._MaPhong = value; }
        }

        static string _TenPhong;
        public static string TenPhong
        {
            get { return CNguoiDung._TenPhong; }
            set { CNguoiDung._TenPhong = value; }
        }

        static bool _Admin;
        public static bool Admin
        {
            get { return CNguoiDung._Admin; }
            set { CNguoiDung._Admin = value; }
        }

        static System.Data.DataTable _dtQuyenNhom;
        public static System.Data.DataTable dtQuyenNhom
        {
            get { return CNguoiDung._dtQuyenNhom; }
            set { CNguoiDung._dtQuyenNhom = value; }
        }

        static System.Data.DataTable _dtQuyenNguoiDung;
        public static System.Data.DataTable dtQuyenNguoiDung
        {
            get { return CNguoiDung._dtQuyenNguoiDung; }
            set { CNguoiDung._dtQuyenNguoiDung = value; }
        }

        public static bool CheckQuyen(string TenMenu, string LoaiQuyen)
        {
            string query = "";
            switch (LoaiQuyen)
            {
                case "Xem":
                    query = "TenMenu ='" + TenMenu + "' and Xem=1";
                    break;
                case "Them":
                    query = "TenMenu ='" + TenMenu + "' and Them=1";
                    break;
                case "Sua":
                    query = "TenMenu ='" + TenMenu + "' and Sua=1";
                    break;
                case "Xoa":
                    query = "TenMenu ='" + TenMenu + "' and Xoa=1";
                    break;
                default:
                    break;
            }
            System.Data.DataRow[] drs;
            ///Kiểm tra quyền theo Nhóm
            if (_dtQuyenNhom != null)
            {
                drs = dtQuyenNhom.Select(query);
                if (drs.Count() > 0)
                    return true;
                else
                    if (dtQuyenNguoiDung != null)
                    {
                        ///Kiểm tra quyền theo Người Dùng
                        drs = dtQuyenNguoiDung.Select(query);
                        if (drs.Count() > 0)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
            }
            else
                if (dtQuyenNguoiDung != null)
                {
                    ///Kiểm tra quyền theo Người Dùng
                    drs = dtQuyenNguoiDung.Select(query);
                    if (drs.Count() > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
        }

        public static void initial()
        {
            CNguoiDung.MaU = -1;
            CNguoiDung.HoTen = "";
            CNguoiDung.Admin = false;
            CNguoiDung.MaPhong= -1;
            CNguoiDung.TenPhong = "";
            CNguoiDung.dtQuyenNhom = null;
            CNguoiDung.dtQuyenNguoiDung = null;
        }

        public bool Them(User nguoidung)
        {
            try
            {
                if (_db.Users.Count() > 0)
                    nguoidung.MaU = _db.Users.Max(item => item.MaU) + 1;
                else
                    nguoidung.MaU = 1;
                nguoidung.CreateDate = DateTime.Now;
                nguoidung.CreateBy = CNguoiDung.MaU;
                _db.Users.InsertOnSubmit(nguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(User nguoidung)
        {
            try
            {
                nguoidung.ModifyDate = DateTime.Now;
                nguoidung.ModifyBy = CNguoiDung.MaU;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(List<User> lstND)
        {
            try
            {
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(User nguoidung)
        {
            try
            {
                _db.Users.DeleteOnSubmit(nguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public List<User> getDS()
        {
            return _db.Users.OrderBy(item => item.STT).ToList();
        }

        public List<User> getDS_ChamCong()
        {
            return _db.Users.Where(item => item.MaU != 0 && item.ChamCong == true && item.An == false).OrderBy(item => item.STT).ToList();
        }

        /// <summary>
        /// Lấy Danh Sách Nhân Viên ngoài trừ Mã ND truyền vào
        /// </summary>
        /// <param name="MaU"></param>
        /// <returns></returns>
        public List<User> GetDSExceptMaND(int MaU)
        {
            return _db.Users.Where(item => item.MaU != MaU && item.MaU != 0 && item.An == false).OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDSExceptMaND_Doi(int MaU)
        {
            return _db.Users.Where(item => item.MaU != MaU && item.MaU != 0).OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDS_Admin()
        {
            return _db.Users.OrderBy(item => item.STT).ToList();
        }

        public User GetByMaND(int MaU)
        {
            return _db.Users.SingleOrDefault(item => item.MaU == MaU);
        }

        public User GetByTaiKhoan(string TaiKhoan)
        {
            try
            {
                return _db.Users.SingleOrDefault(item => item.TaiKhoan == TaiKhoan);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return null;
            }

        }

        public User getChuyenKhoan()
        {
            return _db.Users.FirstOrDefault(item => item.HoTen.Contains("Chuyển Khoản"));
        }

        public bool DangNhap(string TaiKhoan, string MatKhau)
        {
            try
            {
                return _db.Users.Any(item => item.TaiKhoan == TaiKhoan && item.MatKhau == MatKhau && item.An == false);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GetHoTenByMaND(int MaU)
        {
            return _db.Users.SingleOrDefault(item => item.MaU == MaU).HoTen;
        }

        public string GetDienThoaiByMaND(int MaU)
        {
            return _db.Users.SingleOrDefault(item => item.MaU == MaU).DienThoai;
        }

        public int GetMaNVByHoTen(string HoTen)
        {
            return _db.Users.SingleOrDefault(item => item.HoTen == HoTen).MaU;
        }

        public int GetMaxSTT()
        {
            if (_db.Users.Count() == 0)
                return 0;
            else
                return _db.Users.Max(item => item.STT).Value;
        }

        //

        private const int _SoNgayTinhLuong = 26;

        public static int SoNgayTinhLuong
        {
            get { return _SoNgayTinhLuong; }
        } 

    }
}
