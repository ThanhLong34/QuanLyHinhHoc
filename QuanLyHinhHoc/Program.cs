using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    class Program
    {
        static DanhSachHinhHoc ds = new DanhSachHinhHoc();
        static void Main(string[] args)
        {
            Console.Title = "Chương trình quản lý hình học";
            Console.OutputEncoding = Encoding.Unicode;
            ChayChuongTrinh();
        }
        enum Menu
        {
            ThoatChuongTrinh,
            TaoDanhSachHinhHoc,
            XemDanhSachHinhHoc,
            TimHinhVuongCoDienTichLonNhat,
            TimHinhTronCoDienTichNhoNhat,
            TimHinhHocCoDienTichLonNhatTrongDanhSach,
            TinhTongChuViHinhVuong,
            TinhTongDienTichHinhTron,
            TimTatCaHinhVuongTrongDanhSach,
            DemSoLuongHinhVuong,
            XoaHinhVuongTheoDienTichX,
            XoaHinhTronCoDienTichNhoNhat,
            SapTangTheoDienTich,
            HienThiDanhSachTheoTungHinh,
            TimLoaiHinhCoTongDienTichLonNhat,
            TimHinhTronTheoBanKinhX,
            XuatDuLieuRaFile
        }
        static void XuatMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n====================== MENU ======================");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("0.".PadLeft(5) + " Thoát chương trình!");
            Console.WriteLine("1.".PadLeft(5) + " Tạo danh sách hình học");
            Console.WriteLine("2.".PadLeft(5) + " Xem danh sách hình học");
            Console.WriteLine("3.".PadLeft(5) + " Tìm hình vuông có diện tích lớn nhất");
            Console.WriteLine("4.".PadLeft(5) + " Tìm hình tròn có diện tích nhỏ nhất");
            Console.WriteLine("5.".PadLeft(5) + " Tìm hình có diện tích lớn nhất trong danh sách");
            Console.WriteLine("6.".PadLeft(5) + " Tính tổng chu vi hình vuông");
            Console.WriteLine("7.".PadLeft(5) + " Tính tổng diện tích hình tròn");
            Console.WriteLine("8.".PadLeft(5) + " Tìm tất cả hình vuông trong danh sách");
            Console.WriteLine("9.".PadLeft(5) + " Đếm số lượng hình vuông trong danh sách");
            Console.WriteLine("10.".PadLeft(5) + " Xóa hình vuông theo diện tích X");
            Console.WriteLine("11.".PadLeft(5) + " Xóa hình tròn có diện tích nhỏ nhất");
            Console.WriteLine("12.".PadLeft(5) + " Sắp xếp danh sách tăng dần theo diện tích");
            Console.WriteLine("13.".PadLeft(5) + " Hiển thị danh sách theo từng loại hình khác nhau");
            Console.WriteLine("14.".PadLeft(5) + " Tìm loại hình có tổng diện tích lớn nhất");
            Console.WriteLine("15.".PadLeft(5) + " Tìm hình tròn theo bán kính X");
            Console.Write("16.".PadLeft(5) + " Xuất dữ liệu hiện tại ra file \"Xuat.txt\"");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n====================== END =======================");
            Console.ResetColor();
        }
        static void ChayChuongTrinh()
        {
            while (true)
            {
                Console.Clear();
                XuatMenu();
                Console.Write(">>>Chọn chức năng: ");
                Menu menu = (Menu)int.Parse(Console.ReadLine());

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n====================== CHƯƠNG TRÌNH ĐÃ XỬ LÝ XONG =======================");
                Console.ResetColor();
                switch (menu)
                {
                    case Menu.ThoatChuongTrinh:
                        Console.WriteLine("0.".PadRight(5) + " Thoát chương trình!");
                        return;
                    case Menu.TaoDanhSachHinhHoc:
                        {
                            Console.WriteLine("1.".PadRight(5) + " Tạo danh sách hình học");
                            ds.NhapDuLieuTuFile();
                            ThuVienKieuHinh.dsKieuHinhHoc = ds.TimTatCaKieuHinhHoc();
                            Console.WriteLine("Dữ liệu vừa nhập là:\n" + ds);
                            break;
                        }
                    case Menu.XemDanhSachHinhHoc:
                        {
                            Console.WriteLine("2.".PadRight(5) + " Xem danh sách hình học");
                            Console.WriteLine(ds);
                            break;
                        }
                    case Menu.TimHinhVuongCoDienTichLonNhat:
                        {
                            Console.WriteLine("3.".PadRight(5) + " Tìm hình vuông có diện tích lớn nhất");
                            Console.WriteLine("Danh sách hình vuông có diện tích lớn nhất:\n" + ds.TimHinhHocTheoDienTich<HinhVuong>(ds.TimDienTich_Max<HinhVuong>()));
                            break;
                        }
                    case Menu.TimHinhTronCoDienTichNhoNhat:
                        {
                            Console.WriteLine("4.".PadRight(5) + " Tìm hình tròn có diện tích nhỏ nhất");
                            Console.WriteLine("Danh sách hình tròn có diện tích nhỏ nhất:\n" + ds.TimHinhHocTheoDienTich<HinhTron>(ds.TimDienTich_Min<HinhTron>()));
                            break;
                        }
                    case Menu.TimHinhHocCoDienTichLonNhatTrongDanhSach:
                        {
                            Console.WriteLine("5.".PadRight(5) + " Tìm hình có diện tích lớn nhất trong danh sách");
                            Console.WriteLine("Danh sách hình học có diện tích lớn nhất trong danh sách:\n" + ds.TimHinhHocTheoDienTich<IHinhHoc>(ds.TimDienTich_Max<IHinhHoc>()));

                            break;
                        }
                    case Menu.TinhTongChuViHinhVuong:
                        {
                            Console.WriteLine("6.".PadRight(5) + " Tính tổng chu vi hình vuông");
                            Console.WriteLine("Tổng chu vi tất cả hình vuông trong danh sách là: " + ds.TinhTongChuViHinhHoc<HinhVuong>());
                            break;
                        }
                    case Menu.TinhTongDienTichHinhTron:
                        {
                            Console.WriteLine("7.".PadRight(5) + " Tính tổng diện tích hình tròn");
                            Console.WriteLine("Tổng diện tích tất cả hình tròn trong danh sách là: " + ds.TinhTongDienTichHinhHoc<HinhTron>());
                            break;
                        }
                    case Menu.TimTatCaHinhVuongTrongDanhSach:
                        {
                            Console.WriteLine("8.".PadLeft(5) + " Tìm tất cả hình vuông trong danh sách");
                            Console.WriteLine("Tất cả hình vuông trong danh sách là:\n" + ds.TimHinhHoc<HinhVuong>());
                            break;
                        }
                    case Menu.DemSoLuongHinhVuong:
                        {
                            Console.WriteLine("9.".PadLeft(5) + " Đếm số lượng hình vuông trong danh sách");
                            Console.WriteLine("Số lượng hình vuông trong danh sách là: " + ds.DemSoLuongHinhHoc<HinhVuong>());
                            break;
                        }
                    case Menu.XoaHinhVuongTheoDienTichX:
                        {
                            Console.WriteLine("10.".PadLeft(5) + " Xóa hình vuông theo diện tích X");
                            Console.Write("Nhập diện tích: ");
                            float value = float.Parse(Console.ReadLine());
                            ds.XoaHinhHocTheoDienTich<HinhVuong>(value);
                            Console.WriteLine("Danh sách hình học sau khi xóa:\n" + ds);
                            break;
                        }
                    case Menu.XoaHinhTronCoDienTichNhoNhat:
                        {
                            Console.WriteLine("11.".PadLeft(5) + " Xóa hình tròn có diện tích nhỏ nhất");
                            ds.XoaHinhHocTheoDienTich<HinhTron>(ds.TimDienTich_Min<HinhTron>());
                            Console.WriteLine("Danh sách hình học sau khi xóa:\n" + ds);
                            break;
                        }
                    case Menu.SapTangTheoDienTich:
                        {
                            Console.WriteLine("12.".PadLeft(5) + " Sắp xếp danh sách tăng dần theo diện tích");
                            ds.SapTangTheoDienTich();
                            Console.WriteLine("Danh sách sau khi sắp tăng:\n" + ds);
                            break;
                        }
                    case Menu.HienThiDanhSachTheoTungHinh:
                        {
                            Console.WriteLine("13.".PadLeft(5) + " Hiển thị danh sách theo từng loại hình khác nhau");
                            ds.XuatDanhSachTheoTungKieuHinh();
                            break;
                        }
                    case Menu.TimLoaiHinhCoTongDienTichLonNhat:
                        {
                            Console.WriteLine("14.".PadLeft(5) + " Tìm loại hình có tổng diện tích lớn nhất");
                            ds.TimKieuHinhCoTongDienTichLonNhat().ForEach(item => Console.WriteLine("\t" + item));
                            break;
                        }
                    case Menu.TimHinhTronTheoBanKinhX:
                        {
                            Console.WriteLine("15.".PadLeft(5) + " Tìm hình tròn theo bán kính X");
                            Console.Write("Nhập bán kính: ");
                            float value = float.Parse(Console.ReadLine());
                            Console.WriteLine("Danh sách hình tròn có bán kính " + value + " là:\n" + ds.TimHinhTronTheoBanKinh(value));
                            break;
                        }
                    case Menu.XuatDuLieuRaFile:
                        {
                            Console.Write("16.".PadLeft(5) + " Xuất dữ liệu hiện tại ra file \"Xuat.txt\"");
                            DanhSachHinhHoc.XuatDuLieuRaFile(ds);
                            Console.WriteLine("\nĐã xuất dữ liệu thành công!");
                            break;
                        }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter any key to back Menu...");
                Console.ReadKey();
            }
        }
    }
}
