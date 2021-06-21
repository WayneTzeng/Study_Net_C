using LifeEnterpot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeEnterpot.Core.Providers
{
    public interface IBuilding
    {
        IEnumerable<Building>  GetBuildings();

        //List<Building> GetBuildings(string zipCode);
        List<Building> GetBuildingsByName(string name);



    }
}
