//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PolyteksEnerjiYonetimSistemi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AylikUretimVerileri
    {
        public int ID { get; set; }
        public Nullable<int> BolumID { get; set; }
        public Nullable<int> Yil { get; set; }
        public Nullable<int> Ay { get; set; }
        public Nullable<decimal> AylikMiktar { get; set; }
        public string KayitEden { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
    
        public virtual Bolumler Bolumler { get; set; }
    }
}
