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
    
    public partial class Fiyat
    {
        public int fiyat_id { get; set; }
        public Nullable<int> fiyat1 { get; set; }
        public Nullable<int> birim_id { get; set; }
    
        public virtual Birimler Birimler { get; set; }
    }
}
