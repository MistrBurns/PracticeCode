using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Zinshaus_Proto.Models
{
    public class Zinssatz 
    {
        public int Id { get; set; }
        public string Stichtag { get; set; }
        public string Strasse { get; set; }
        public int Hausnummer { get; set; }
        public int KGNR { get; set; }
        public string KG_Name { get; set; }
        public string Grnr { get; set; }
        public double Flaeche { get; set; }
        public double Kap_zs { get; set; }
        public double Mietnw_eur { get; set; }
        public string Clusterung { get; set; }
    }
}