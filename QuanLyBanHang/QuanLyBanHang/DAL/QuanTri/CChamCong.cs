using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using System.Data;

namespace QuanLyBanHang.DAL.QuanTri
{
    class CChamCong : CDAL
    {
        public bool Them(ChamCong chamcong)
        {
            try
            {
                if (_db.ChamCongs.Count() > 0)
                    chamcong.ID = _db.ChamCongs.Max(item => item.ID) + 1;
                else
                    chamcong.ID = 1;
                chamcong.CreateDate = DateTime.Now;
                chamcong.CreateBy = CNguoiDung.MaU;
                _db.ChamCongs.InsertOnSubmit(chamcong);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(ChamCong chamcong)
        {
            try
            {
                _db.ChamCongs.DeleteOnSubmit(chamcong);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(ChamCong chamcong)
        {
            try
            {
                chamcong.ModifyBy = CNguoiDung.MaU;
                chamcong.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist(int Thang, int Nam)
        {
            return _db.ChamCongs.Any(item => item.Thang == Thang && item.Nam == Nam);
        }

        public bool CheckExist_Chot(int ID)
        {
            return _db.ChamCongs.Any(item => item.ID == ID && item.Chot == true);
        }

        public int GetMaxID()
        {
            return _db.ChamCongs.Max(item => item.ID);
        }

        public ChamCong get(int ID)
        {
            return _db.ChamCongs.SingleOrDefault(item => item.ID == ID);
        }

        public ChamCong get(int Thang, int Nam)
        {
            return _db.ChamCongs.SingleOrDefault(item => item.Thang.Value == Thang && item.Nam.Value == Nam);
        }

        public DataTable getDS()
        {
            var query = from item in _db.ChamCongs
                        select new
                        {
                            item.ID,
                            ThoiGian = item.Thang + "/" + item.Nam,
                            item.Thang,
                            item.Nam,
                            item.Chot,
                        };
            return LINQToDataTable(query);
        }

        ///////////////////

        public bool Sua_ChiTiet(ChamCong_ChiTiet chamcong)
        {
            try
            {
                chamcong.ModifyBy = CNguoiDung.MaU;
                chamcong.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public ChamCong_ChiTiet get_ChiTiet(int ID, int MaU)
        {
            return _db.ChamCong_ChiTiets.SingleOrDefault(item => item.ID == ID && item.MaU == MaU);
        }

        public DataTable getDS_ChiTiet(int ID)
        {
            var query = from item in _db.ChamCong_ChiTiets
                        where item.ID == ID
                        orderby item.User.IDPhong, item.User.MaU
                        select new
                        {
                            item.ID,
                            item.MaU,
                            PhongBan = item.User.PhongBan.HoTen,
                            item.User.HoTen,
                            item.N1,
                            item.N2,
                            item.N3,
                            item.N4,
                            item.N5,
                            item.N6,
                            item.N7,
                            item.N8,
                            item.N9,
                            item.N10,
                            item.N11,
                            item.N12,
                            item.N13,
                            item.N14,
                            item.N15,
                            item.N16,
                            item.N17,
                            item.N18,
                            item.N19,
                            item.N20,
                            item.N21,
                            item.N22,
                            item.N23,
                            item.N24,
                            item.N25,
                            item.N26,
                            item.N27,
                            item.N28,
                            item.N29,
                            item.N30,
                            item.N31,
                            Nghi = 0,
                            item.LuongCoBan,
                            item.LuongThucLanh,
                            item.TamUng1,
                            item.TamUng2,
                            item.TamUng3,
                            item.BoiDuong,
                            item.ThuongDotXuat,
                            item.ThuongLe,
                            item.ThuongThang,
                            item.ThuongQuy,
                            item.ThuongNam,
                            item.PhuCapXang,
                            item.PhuCapDienThoai,
                            item.TienCom1Ngay,
                        };
            return LINQToDataTable(query);
        }

        public bool suaChamCong(int ID, int MaNV, string Ngay, bool Nghi)
        {
            string sql = "update ChamCong_ChiTiet set " + Ngay + "='" + Nghi + "',ModifyBy=" + CNguoiDung.MaU + ",ModifyDate=getdate() where ID=" + ID + " and MaU=" + MaNV;
            return LinQ_ExecuteNonQuery(sql);
        }



        ///////////////////

        public int getTongSoNgayTrongThang(int Thang, int Nam)
        {
            switch (Thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (Nam % 400 == 0 || (Nam % 4 == 0 && Nam % 100 != 0))
                        return 29;
                    else
                        return 28;
                default:
                    return 0;
            }
        }

        public int getTongSoNgayCNTrongThang(int Thang, int Nam)
        {
            int TongSoNgay = getTongSoNgayTrongThang(Thang, Nam);
            int TongSoNgayCN = 0;
            for (int i = 1; i <= TongSoNgay; i++)
            {
                DateTime time = new DateTime(Nam, Thang, i);
                if (time.DayOfWeek == DayOfWeek.Sunday)
                    TongSoNgayCN++;
            }
            return TongSoNgayCN;
        }

        public int getTongSoNgayNghiTrongThang(int Thang, int Nam, int MaU)
        {
            ChamCong_ChiTiet en = _db.ChamCong_ChiTiets.SingleOrDefault(item => item.ChamCong.Thang.Value == Thang && item.ChamCong.Nam.Value == Nam && item.MaU == MaU);
            int count = 0;
            if (en != null)
            {
                if (en.N1 == true)
                    count++;
                if (en.N2 == true)
                    count++;
                if (en.N3 == true)
                    count++;
                if (en.N4 == true)
                    count++;
                if (en.N5 == true)
                    count++;
                if (en.N6 == true)
                    count++;
                if (en.N7 == true)
                    count++;
                if (en.N8 == true)
                    count++;
                if (en.N9 == true)
                    count++;
                if (en.N10 == true)
                    count++;
                if (en.N11 == true)
                    count++;
                if (en.N12 == true)
                    count++;
                if (en.N13 == true)
                    count++;
                if (en.N14 == true)
                    count++;
                if (en.N15 == true)
                    count++;
                if (en.N16 == true)
                    count++;
                if (en.N17 == true)
                    count++;
                if (en.N18 == true)
                    count++;
                if (en.N19 == true)
                    count++;
                if (en.N20 == true)
                    count++;
                if (en.N21 == true)
                    count++;
                if (en.N22 == true)
                    count++;
                if (en.N23 == true)
                    count++;
                if (en.N24 == true)
                    count++;
                if (en.N25 == true)
                    count++;
                if (en.N26 == true)
                    count++;
                if (en.N27 == true)
                    count++;
                if (en.N28 == true)
                    count++;
                if (en.N29 == true)
                    count++;
                if (en.N30 == true)
                    count++;
                if (en.N31 == true)
                    count++;
            }
            return count;
        }

        public int getTongSoNgayNghiDenThang(int Thang, int Nam, int MaU)
        {
            List<ChamCong_ChiTiet> lst = _db.ChamCong_ChiTiets.Where(item => item.ChamCong.Thang.Value < Thang && item.ChamCong.Nam.Value == Nam && item.MaU == MaU).ToList();
            int count = 0;
            if (lst.Count > 0)
                foreach (ChamCong_ChiTiet item in lst)
                {
                    count += getTongSoNgayNghiTrongThang(item.ChamCong.Thang.Value, item.ChamCong.Nam.Value, item.MaU);
                }
            return count;
        }

        public int getTongSoNgayPhepTrongNam(int Nam, int MaU)
        {
            int count = 12;
            CNguoiDung _cND = new CNguoiDung();
            User user = _cND.GetByMaND(MaU);
            if ((DateTime.Now.Month == user.NgayVaoLam.Value.Month && DateTime.Now.Day >= user.NgayVaoLam.Value.Day) || (DateTime.Now.Month > user.NgayVaoLam.Value.Month))
                if (DateTime.Now.Year - user.NgayVaoLam.Value.Year > CNguoiDung.SoNamTangNgayNghi)
                    count += (DateTime.Now.Year - user.NgayVaoLam.Value.Year) - CNguoiDung.SoNamTangNgayNghi;
            return count;
        }
    }
}
