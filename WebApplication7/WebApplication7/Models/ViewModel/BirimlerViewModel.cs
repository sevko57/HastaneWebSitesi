using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models.Entity;

namespace WebApplication7.Models.ViewModel
{
    public class BirimlerViewModel
    {
        public List<SelectListItem> Birimlers { get; set; }
        public List<Doktorlar> Doktorlars { get; set; }
        public List<string> Fiyats { get; set; }
    }
}