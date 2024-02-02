using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolyteksEnerjiYonetimSistemi.Models
{
    public class FilterClass
    {
        public int SelectedCountriesId { get; set; }
        public List<Makine> Countrieslist { get; set; }
        public List<MakineCalismaSureleri> Customerdetail { get; set; }
    }
}