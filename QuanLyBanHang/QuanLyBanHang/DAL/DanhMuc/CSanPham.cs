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
        public bool Them(SanPham en)
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

        public bool Sua(SanPham en)
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

        public bool Xoa(SanPham en)
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

        public bool checkExists_HoTen(string HoTen)
        {
            return _db.SanPhams.Any(item => item.HoTen == HoTen);
        }

        public SanPham get(int ID)
        {
            return _db.SanPhams.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.SanPhams.ToList());
        }
    }
}
