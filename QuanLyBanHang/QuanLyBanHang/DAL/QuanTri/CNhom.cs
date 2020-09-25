using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;

namespace QuanLyBanHang.DAL.QuanTri
{
    class CNhom:CDAL
    {
        public bool Them(Nhom nhom)
        {
            try
            {
                if (_db.Nhoms.Count() > 0)
                    nhom.MaNhom = _db.Nhoms.Max(item => item.MaNhom) + 1;
                else
                    nhom.MaNhom = 1;
                nhom.CreateDate = DateTime.Now;
                nhom.CreateBy = CNguoiDung.MaU;
                _db.Nhoms.InsertOnSubmit(nhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(Nhom nhom)
        {
            try
            {
                nhom.ModifyDate = DateTime.Now;
                nhom.ModifyBy = CNguoiDung.MaU;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(Nhom nhom)
        {
            try
            {
                _db.Nhoms.DeleteOnSubmit(nhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public List<Nhom> GetDS()
        {
            return _db.Nhoms.ToList();
        }

        public Nhom GetByMaNhom(int MaTT_Nhom)
        {
            return _db.Nhoms.SingleOrDefault(item => item.MaNhom == MaTT_Nhom);
        }

        public string GetTenNhomByMaNhom(int MaTT_Nhom)
        {
            return _db.Nhoms.SingleOrDefault(item => item.MaNhom == MaTT_Nhom).TenNhom;
        }
    }
}
