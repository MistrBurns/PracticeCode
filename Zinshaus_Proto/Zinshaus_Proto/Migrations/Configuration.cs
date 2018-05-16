namespace Zinshaus_Proto.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Zinshaus_Proto.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Zinshaus_Proto.Models.ZinssatzDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Zinshaus_Proto.Models.ZinssatzDB context)
        {
            
           
              context.Zinssatzs.AddOrUpdate(
                 p => p.Id,
                 new Zinssatz { Id = 1 , Stichtag = "09.07.2013", Strasse =  "Viktorgasse", Hausnummer = 21, KGNR = 01011, KG_Name = "Wieden", Grnr = "327", Flaeche = 31.50, Kap_zs = 4, Mietnw_eur = 9.60, Clusterung = "sehr gut" }
                
              );
            
        }
    }
}
