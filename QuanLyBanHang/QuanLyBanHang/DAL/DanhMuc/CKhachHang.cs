using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using QuanLyBanHang.DAL.QuanTri;
using System.Data;

namespace QuanLyBanHang.DAL.DanhMuc
{
    class CKhachHang:CDAL
    {
        public bool Them(KhachHang en)
        {
            try
            {
                if (_db.KhachHangs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.KhachHangs.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaU;
                _db.KhachHangs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(KhachHang en)
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

        public bool Xoa(KhachHang en)
        {
            try
            {
                _db.KhachHangs.DeleteOnSubmit(en);
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
            return _db.KhachHangs.Any(item => item.HoTen == HoTen);
        }

        public bool checkExists_DiaChi(string DiaChi)
        {
            return _db.KhachHangs.Any(item => item.DiaChi == DiaChi);
        }

        public bool checkExists_DienThoai(string DienThoai)
        {
            return _db.KhachHangs.Any(item => item.DienThoai == DienThoai);
        }

        public bool checkExists_MST(string MST)
        {
            return _db.KhachHangs.Any(item => item.MST == MST);
        }

        public KhachHang get(int ID)
        {
            return _db.KhachHangs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.KhachHangs.ToList());
        }
    }
}
