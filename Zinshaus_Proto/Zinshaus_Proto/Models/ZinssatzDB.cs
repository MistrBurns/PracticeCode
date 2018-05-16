using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Zinshaus_Proto.Models
{
    
    public class ZinssatzDB : DbContext
    {
        public ZinssatzDB()
        {

        }
        
        public DbSet<Zinssatz> Zinssatzs { get; set; }

    }
    




}