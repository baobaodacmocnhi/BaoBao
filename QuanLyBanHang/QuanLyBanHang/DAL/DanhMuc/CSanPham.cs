using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using QuanLyBanHang.DAL.QuanTri;
using System.Data;

namespace QuanLyBanHang.DAL.DanhMuc
{
    class CSanPham : CDAL
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
            return _db.SanPhams.SingleOrDefault(item => item.ID == ID && item.Bo == false);
        }

        public SanPham getSP(string HoTen)
        {
            return _db.SanPhams.SingleOrDefault(item => item.HoTen == HoTen && item.Bo == false);
        }

        public DataTable getDS_SP()
        {
            return LINQToDataTable(_db.SanPhams.Where(item => item.Bo == false).ToList());
        }

        ////////////

        public SanPham getBo(int ID)
        {
            return _db.SanPhams.SingleOrDefault(item => item.ID == ID && item.Bo == true);
        }

        public SanPham getBo(string HoTen)
        {
            return _db.SanPhams.SingleOrDefault(item => item.HoTen == HoTen && item.Bo == true);
        }

        public DataTable getDS_Bo()
        {
            return LINQToDataTable(_db.SanPhams.Where(item => item.Bo == true).ToList());
        }

        ////////////

        public bool ThemBoCT(SanPham_Bo en)
        {
            try
            {
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaU;
                _db.SanPham_Bos.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool SuaBoCT(SanPham_Bo en)
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

        public bool XoaBoCT(SanPham en)
        {
            try
            {
                _db.SanPham_Bos.DeleteAllOnSubmit(en.SanPham_Bos.ToList());
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
