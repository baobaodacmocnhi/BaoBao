using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyBanHang.LinQ;
using System.Data;

namespace QuanLyBanHang.DAL.QuanTri
{
    class CPhanQuyenNguoiDung : CDAL
    {
        public bool Them(PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.CreateDate = DateTime.Now;
                phanquyennguoidung.CreateBy = CNguoiDung.MaU;
                _db.PhanQuyenNguoiDungs.InsertOnSubmit(phanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.ModifyDate = DateTime.Now;
                phanquyennguoidung.ModifyBy = CNguoiDung.MaU;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                _db.PhanQuyenNguoiDungs.DeleteOnSubmit(phanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(List<PhanQuyenNguoiDung> lstphanquyennguoidung)
        {
            try
            {
                _db.PhanQuyenNguoiDungs.DeleteAllOnSubmit(lstphanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public PhanQuyenNguoiDung GetByMaMenuMaND(int MaMenu, int MaU)
        {
            return _db.PhanQuyenNguoiDungs.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaU == MaU);
        }

        public bool CheckByMaMenuMaND(int MaMenu, int MaU)
        {
            return _db.PhanQuyenNguoiDungs.Any(item => item.MaMenu == MaMenu && item.MaU == MaU);
        }

        public DataTable GetDSByMaND(bool Admin, int MaU)
        {
            if (Admin)
                return LINQToDataTable(_db.PhanQuyenNguoiDungs.Where(item => item.MaU == MaU).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
            else
                return LINQToDataTable(_db.PhanQuyenNguoiDungs.Where(item => item.MaU == MaU && item.Menu.TenMenuCha != "mnuPhoGiamDoc").Select(item =>
                    new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }

    }
}
