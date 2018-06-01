using NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
