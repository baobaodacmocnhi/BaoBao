using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using QuanLyBanHang.DAL.QuanTri;
using System.Data;

namespace QuanLyBanHang.DAL.NhapXuat
{
    class CNhapKho:CDAL
    {
        public bool Them(NhapKho en)
        {
            try
            {
                if (_db.SanPhams.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.SanPhams.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaU;
                _db.NhapKhos.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(NhapKho en)
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

        public bool Xoa(NhapKho en)
        {
            try
            {
                _db.NhapKhos.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DataTable getDS(DateTime FromCreateDate,DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.NhapKhos.Where(item => item.NgayLap.Value.Date >= FromCreateDate.Date && item.NgayLap.Value.Date <= ToCreateDate.Date).ToList());
        }
    }
}
