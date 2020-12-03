using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using System.Data;

namespace QuanLyBanHang.DAL.QuanTri
{
    class CPhongBan : CDAL
    {
        public bool Them(PhongBan en)
        {
            try
            {
                if (_db.PhongBans.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.PhongBans.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaU;
                _db.PhongBans.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(PhongBan en)
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

        public bool Xoa(PhongBan en)
        {
            try
            {
                _db.PhongBans.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(string HoTen)
        {
            return _db.PhongBans.Any(item => item.HoTen == HoTen);
        }

        public PhongBan get(int ID)
        {
            return _db.PhongBans.SingleOrDefault(item => item.ID == ID);
        }

        public List<PhongBan> getDS()
        {
            return _db.PhongBans.ToList();
        }
    }
}
