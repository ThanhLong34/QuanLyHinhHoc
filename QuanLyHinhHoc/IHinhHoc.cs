using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    interface IHinhHoc
    {
        string KieuHinh { get;}
        float TinhChuVi();
        float TinhDienTich();
    }
}
