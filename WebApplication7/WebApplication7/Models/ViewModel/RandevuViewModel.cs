using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models.Entity;

namespace WebApplication7.Models.ViewModel
{
    public class RandevuViewModel
    {
        public List<Kullanicilar> Kullanicilars { get; set; }
        public List<SelectListItem> Birimlers { get; set; }
        public Randevular Randevular { get; set; }

    }
}