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

        public bool suaPhuCap(int ID, int MaNV, string PhuCap)
        {
            string sql = "update ChamCong_ChiTiet set PhuCap=" + PhuCap + ",ModifyBy=" + CNguoiDung.MaU + ",ModifyDate=getdate() where ID=" + ID + " and MaU=" + MaNV;
            return LinQ_ExecuteNonQuery(sql);
        }

        public int GetMaxID()
        {
            return _db.ChamCongs.Max(item => item.ID);
        }
    }
}
