﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using System.Data;

namespace QuanLyBanHang.DAL.QuanTri
{
    class CPhanQuyenNhom:CDAL
    {
        public bool Them(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.CreateDate = DateTime.Now;
                phanquyennhom.CreateBy = CNguoiDung.MaU;
                _db.PhanQuyenNhoms.InsertOnSubmit(phanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.ModifyDate = DateTime.Now;
                phanquyennhom.ModifyBy = CNguoiDung.MaU;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                _db.PhanQuyenNhoms.DeleteOnSubmit(phanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(List<PhanQuyenNhom> lstphanquyennhom)
        {
            try
            {
                _db.PhanQuyenNhoms.DeleteAllOnSubmit(lstphanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public PhanQuyenNhom GetByMaMenuMaNhom(int MaMenu,int MaTT_Nhom)
        {
            return _db.PhanQuyenNhoms.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaNhom == MaTT_Nhom);
        }

        public bool CheckByMaMenuMaNhom(int MaMenu,int MaTT_Nhom)
        {
            return _db.PhanQuyenNhoms.Any(item => item.MaMenu == MaMenu && item.MaNhom == MaTT_Nhom);
        }

        public DataTable GetDSByMaNhom(bool Admin,int MaTT_Nhom)
        {
            if(Admin)
                return LINQToDataTable(_db.PhanQuyenNhoms.Where(item => item.MaNhom == MaTT_Nhom).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
            else
            return LINQToDataTable(_db.PhanQuyenNhoms.Where(item => item.MaNhom == MaTT_Nhom && item.Menu.TenMenuCha != "mnuPhoGiamDoc").Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }

        
    }
}
