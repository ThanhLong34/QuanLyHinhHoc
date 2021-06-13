using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    class HinhTron : IHinhHoc
    {
        // Fields
        private float banKinh;
        private string kieuHinh = "Hình tròn";

        // Properties
        public float BanKinh { get => banKinh; set => banKinh = value; }
        public string KieuHinh { get => kieuHinh; }

        // Constructor
        public HinhTron()
        {

        }
        public HinhTron(string lineData)
        {
            string[] data = lineData.Trim().Split(' ');
            banKinh = float.Parse(data[1].Trim());
        }

        // Methods
        public float TinhChuVi()
        {
            return (float)Math.Round((float)(Math.PI * banKinh * 2), 1);
        }
        public float TinhDienTich()
        {
            return (float)Math.Round((float)(Math.PI * banKinh * banKinh), 1);
        }
        public override string ToString()
        {
            string s = "|{0}|{1}|{2}|{3}|";
            return string.Format(s, kieuHinh.PadRight(12), ("bán kính: " + banKinh.ToString()).PadRight(12), TinhChuVi().ToString().PadRight(12), TinhDienTich().ToString().PadRight(12));
        }
    }
}
