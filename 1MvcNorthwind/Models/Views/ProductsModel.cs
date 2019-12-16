using _1MvcNorthwind.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1MvcNorthwind.Models.Views
{
    public class ProductsModel
    {
        public ICollection<Products> plist { get; set; }// listelerken  gostereceğiz
        public Products SecProducts { get; set; } //tek bir product ile uğraşırken gostereceğiz
        public List<SelectListItem> CatDropDown { get; set; }
        public List<SelectListItem> SupDropDown { get; set; }
    }
}