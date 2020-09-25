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

        static int _MaTo;
        public static int MaTo
        {
            get { return CNguoiDung._MaTo; }
            set { CNguoiDung._MaTo = value; }
        }

        static string _TenTo;
        public static string TenTo
        {
            get { return CNguoiDung._TenTo; }
            set { CNguoiDung._TenTo = value; }
        }

        static bool _Admin;
        public static bool Admin
        {
            get { return CNguoiDung._Admin; }
            set { CNguoiDung._Admin = value; }
        }

        static bool _PhoGiamDoc;
        public static bool PhoGiamDoc
        {
            get { return CNguoiDung._PhoGiamDoc; }
            set { CNguoiDung._PhoGiamDoc = value; }
        }

        static bool _Doi;
        public static bool Doi
        {
            get { return CNguoiDung._Doi; }
            set { CNguoiDung._Doi = value; }
        }

        static bool _ToTruong;
        public static bool ToTruong
        {
            get { return CNguoiDung._ToTruong; }
            set { CNguoiDung._ToTruong = value; }
        }

        static bool _SyncNopTien;
        public static bool SyncNopTien
        {
            get { return CNguoiDung._SyncNopTien; }
            set { CNguoiDung._SyncNopTien = value; }
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

        static string _Name_PC;
        public static string Name_PC
        {
            get { return CNguoiDung._Name_PC; }
            set { CNguoiDung._Name_PC = value; }
        }

        static string _IP_PC;
        public static string IP_PC
        {
            get { return CNguoiDung._IP_PC; }
            set { CNguoiDung._IP_PC = value; }
        }

        static int _ID_DangNhap = -1;
        public static int ID_DangNhap
        {
            get { return CNguoiDung._ID_DangNhap; }
            set { CNguoiDung._ID_DangNhap = value; }
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
            CNguoiDung.PhoGiamDoc = false;
            CNguoiDung.Doi = false;
            CNguoiDung.ToTruong = false;
            CNguoiDung.SyncNopTien = false;
            CNguoiDung.MaTo = -1;
            CNguoiDung.TenTo = "";
            CNguoiDung.dtQuyenNhom = null;
            CNguoiDung.dtQuyenNguoiDung = null;
            CNguoiDung.Name_PC = "";
            CNguoiDung.IP_PC = "";
            CNguoiDung.ID_DangNhap = -1;
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

        public List<User> GetDS()
        {
            return _db.Users.OrderBy(item => item.STT).ToList();
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


    }
}
