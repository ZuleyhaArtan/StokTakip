//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stok_Takip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satislar
    {
        public int ID { get; set; }
        public int UrunID { get; set; }
        public int SepetID { get; set; }
        public string BarkodNo { get; set; }
        public decimal BirimFiyati { get; set; }
        public decimal Miktari { get; set; }
        public decimal ToplamFiyati { get; set; }
        public int KDV { get; set; }
        public int BirimID { get; set; }
        public System.DateTime Tarih { get; set; }
        public System.DateTime Saat { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}
