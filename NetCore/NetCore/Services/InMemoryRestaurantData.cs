using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Models;

namespace NetCore.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Burger Bar"},
                new Restaurant {Id = 2, Name = "Italian Pizza"},
                new Restaurant {Id = 3, Name = "Greek place"},
            };
            return restaurants;
        }
    }
}
