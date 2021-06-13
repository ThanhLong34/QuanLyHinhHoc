using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    class HinhVuong : IHinhHoc
    {
        // Fields
        private float canh;
        private string kieuHinh = "Hình vuông";

        // Properties
        public float Canh { get => canh; set => canh = value; }
        public string KieuHinh { get => kieuHinh; }

        // Constructor
        public HinhVuong()
        {

        }
        public HinhVuong(string lineData)
        {
            string[] data = lineData.Trim().Split(' ');
            canh = float.Parse(data[1].Trim());
        }

        // Methods
        public float TinhChuVi()
        {
            return canh * 4;
        }
        public float TinhDienTich()
        {
            return canh * canh;
        }
        public override string ToString()
        {
            string s = "|{0}|{1}|{2}|{3}|";
            return string.Format(s, kieuHinh.PadRight(12),("cạnh: " + canh.ToString()).PadRight(12), TinhChuVi().ToString().PadRight(12), TinhDienTich().ToString().PadRight(12));
        }
    }
}
