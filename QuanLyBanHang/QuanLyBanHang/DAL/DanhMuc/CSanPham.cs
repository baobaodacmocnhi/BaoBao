using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using QuanLyBanHang.DAL.QuanTri;
using System.Data;

namespace QuanLyBanHang.DAL.DanhMuc
{
    class CSanPham:CDAL
    {
        public bool ThemSP(SanPham en)
        {
            try
            {
                if (_db.SanPhams.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.SanPhams.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaU;
                _db.SanPhams.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool SuaSP(SanPham en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaU;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool XoaSP(SanPham en)
        {
            try
            {
                _db.SanPhams.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists_SP_HoTen(string HoTen)
        {
            return _db.SanPhams.Any(item => item.HoTen == HoTen);
        }

        public SanPham getSP(int ID)
        {
            return _db.SanPhams.SingleOrDefault(item => item.ID == ID);
        }

        public SanPham getSP(string HoTen)
        {
            return _db.SanPhams.SingleOrDefault(item => item.HoTen == HoTen);
        }

        public DataTable getDS_SP()
        {
            return LINQToDataTable(_db.SanPhams.ToList());
        }

        ////////////

        public bool ThemBo(SanPham_Nhom en)
        {
            try
            {
                if (_db.SanPham_Nhoms.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.SanPham_Nhoms.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaU;
                _db.SanPham_Nhoms.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool SuaBo(SanPham_Nhom en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaU;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool XoaBo(SanPham_Nhom en)
        {
            try
            {
                _db.SanPham_Nhoms.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists_Bo_HoTen(string HoTen)
        {
            return _db.SanPham_Nhoms.Any(item => item.HoTen == HoTen);
        }

        public SanPham_Nhom getBo(int ID)
        {
            return _db.SanPham_Nhoms.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS_Bo()
        {
            return LINQToDataTable(_db.SanPham_Nhoms.ToList());
        }

        ////////////

        public bool ThemBoCT(SanPham_Nhom_ChiTiet en)
        {
            try
            {
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaU;
                _db.SanPham_Nhom_ChiTiets.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool SuaBoCT(SanPham_Nhom_ChiTiet en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaU;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool XoaBoCT(SanPham_Nhom_ChiTiet en)
        {
            try
            {
                _db.SanPham_Nhom_ChiTiets.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }
    }
}
