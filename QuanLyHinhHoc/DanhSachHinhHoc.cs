using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuanLyHinhHoc
{
    class DanhSachHinhHoc
    {
        private List<IHinhHoc> collection = new List<IHinhHoc>();

        // Methods
        /// <summary>
        /// Nhập dữ liệu từ file
        /// </summary>
        public void NhapDuLieuTuFile()
        {
            StreamReader nhap = new StreamReader(@"Data.txt");
            string s;
            while ((s = nhap.ReadLine()) != null)
            {
                string[] data = s.Trim().Split(' ');
                if (data[0].Contains("HT"))
                    collection.Add(new HinhTron(s));
                if (data[0].Contains("HV"))
                    collection.Add(new HinhVuong(s));
            }
            nhap.Close();
        }
        /// <summary>
        /// Xuất danh sách hình học
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = XuatKeNgang('=');
            s += "|" + "Loại".PadRight(12) + "|" + "Thông số".PadRight(12) + "|" + "Chu vi".PadRight(12) + "|" + "Diện tích".PadRight(12) + "|\n";
            s += XuatKeNgang('=');
            foreach (var item in collection)
                s += item + "\n" + XuatKeNgang('-');
            s += "|Tổng số hình học trong danh sách trên là: " + collection.Count.ToString().PadRight(9) + "|\n";
            return s + XuatKeNgang('=');
        }
        /// <summary>
        /// Xuất kẽ ngang
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        private string XuatKeNgang(char k)
        {
            string s = "|";
            for (int i = 0; i < 51; i++)
                s += k;
            s += "|";
            return s + "\n";
        }
        /// <summary>
        /// Tìm diện tích của hình học lớn nhất
        /// </summary>
        /// <typeparam name="T">kiểu hình học</typeparam>
        /// <returns></returns>
        public float TimDienTich_Max<T>()
        {
            return collection.Where(item => item is T).Max(item => item.TinhDienTich());
        }
        /// <summary>
        /// Tìm diện tích của hình học nhỏ nhất
        /// </summary>
        /// <typeparam name="T">kiểu hình học</typeparam>
        /// <returns></returns>
        public float TimDienTich_Min<T>()
        {
            return collection.Where(item => item is T).Min(item => item.TinhDienTich());
        }
        /// <summary>
        /// Tìm hình học theo diện tích
        /// </summary>
        /// <typeparam name="T">kiểu hình học</typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DanhSachHinhHoc TimHinhHocTheoDienTich<T>(float dt)
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            kq.collection = collection.FindAll(item => item is T && item.TinhDienTich().Equals(dt));
            return kq;
        }
        /// <summary>
        /// Tính tổng chu vi hình học
        /// </summary>
        /// <typeparam name="T">kiểu hình học</typeparam>
        /// <returns></returns>
        public float TinhTongChuViHinhHoc<T>()
        {
            return collection.Where(item => item is T).Sum(item => item.TinhChuVi());
        }
        /// <summary>
        /// Tính tổng diện tích hình học
        /// </summary>
        /// <typeparam name="T">kiểu hình học</typeparam>
        /// <returns></returns>
        public float TinhTongDienTichHinhHoc<T>()
        {
            return collection.Where(item => item is T).Sum(item => item.TinhDienTich());
        }
        /// <summary>
        /// Tìm tất cả hình học trong danh sách
        /// </summary>
        /// <typeparam name="T">kiểu hình học</typeparam>
        /// <returns></returns>
        public DanhSachHinhHoc TimHinhHoc<T>()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            kq.collection = collection.FindAll(item => item is T);
            return kq;
        }
        /// <summary>
        /// Đếm số lượng hình học trong danh sách
        /// </summary>
        /// <typeparam name="T">kiểu hình học</typeparam>
        /// <returns></returns>
        public int DemSoLuongHinhHoc<T>()
        {
            return collection.Count(item => item is T);
        }
        /// <summary>
        /// Xóa hình học theo diện tích
        /// </summary>
        /// <typeparam name="T">kiểu hình học</typeparam>
        /// <param name="value">diện tích</param>
        public void XoaHinhHocTheoDienTich<T>(float value)
        {
            collection.RemoveAll(item => item.TinhDienTich().Equals(value));
        }
        /// <summary>
        /// Sắp tăng danh sách theo diện tích
        /// </summary>
        public void SapTangTheoDienTich()
        {
            collection = collection.OrderBy(item => item.TinhDienTich()).ToList();
        }
        /// <summary>
        /// Tìm tất cả kiểu hình trong danh sách
        /// </summary>
        /// <returns></returns>
        public List<string> TimTatCaKieuHinhHoc()
        {
            List<string> kq = new List<string>();
            foreach (var item in collection)
            {
                if (!kq.Contains(item.KieuHinh))
                    kq.Add(item.KieuHinh);
            }
            return kq;
        }
        /// <summary>
        /// Tìm hình học theo kiểu hình 
        /// </summary>
        /// <param name="k">kiểu hình</param>
        /// <returns></returns>
        private DanhSachHinhHoc TimHinhHocTheoKieuHinh(string k)
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            kq.collection = collection.FindAll(item => string.Compare(item.KieuHinh, k, true) == 0);
            return kq;
        }
        /// <summary>
        /// Xuất danh sách theo từng kiểu hình
        /// </summary>
        public void XuatDanhSachTheoTungKieuHinh()
        {
            foreach (var item in ThuVienKieuHinh.dsKieuHinhHoc)
            {
                Console.WriteLine("Danh sách " + item);
                Console.WriteLine(TimHinhHocTheoKieuHinh(item));
            }
        }
        /// <summary>
        /// Tính tổng diện tích theo kiểu hình
        /// </summary>
        /// <param name="k">kiểu hình học</param>
        /// <returns></returns>
        public float TinhTongDienTichTheoKieuHinh(string k)
        {
            return collection.Where(item => string.Compare(item.KieuHinh, k, true) == 0).Sum(item => item.TinhDienTich());
        }
        /// <summary>
        /// Tìm tổng diện tích lớn nhất
        /// </summary>
        /// <returns></returns>
        private float TimTongDienTich_Max()
        {
            return ThuVienKieuHinh.dsKieuHinhHoc.Max(item => TinhTongDienTichTheoKieuHinh(item));
        }
        /// <summary>
        /// Tìm kiểu hình có tổng diện tích lớn nhất
        /// </summary>
        /// <returns></returns>
        public List<string> TimKieuHinhCoTongDienTichLonNhat()
        {
            float max = TimTongDienTich_Max();
            return ThuVienKieuHinh.dsKieuHinhHoc.FindAll(item => TinhTongDienTichTheoKieuHinh(item).Equals(max));
        }
        /// <summary>
        /// Tìm hình tròn theo bán kính
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DanhSachHinhHoc TimHinhTronTheoBanKinh(float value)
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            kq.collection = collection.OfType<HinhTron>().Where(item => item.BanKinh.Equals(value)).ToList<IHinhHoc>();
            return kq;
        }
        /// <summary>
        /// Xuất dữ liệu ra file
        /// </summary>
        /// <param name="ds"></param>
        static public void XuatDuLieuRaFile(DanhSachHinhHoc ds)
        {
            StreamWriter xuat = new StreamWriter(@"Xuat.txt");
            xuat.Flush();
            xuat.WriteLine("Danh sách hình học");
            xuat.Write(ds);
            xuat.Close();
        }
    }
}
