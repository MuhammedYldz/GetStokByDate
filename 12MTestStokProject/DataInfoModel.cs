using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12MTestStokProject
{
    public class DataInfoModel
    {
        public int SıraNo { get; set; }
        public string IslemTur { get; set; }
        public char EvrakNo { get; set; }
        public DateTime Tarih { get; set; }
        public decimal GirisMiktar { get; set; }
        public decimal CıkısMiktar { get; set; }
        public decimal Miktar { get; set; }
        public decimal StokMiktar { get; set; }
    }
}
