//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication7.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adresler
    {
        public int adres_id { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string adres_detay { get; set; }
        public Nullable<int> kullanici_id { get; set; }
    
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
