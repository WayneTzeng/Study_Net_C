using LifeEnterpot.Core.Models;
using LifeEnterpot.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.MockData
{
    public class MockBuilding : IBuilding
    {
        private List<Building> _roures;

        public MockBuilding()
        {
            if (_roures == null)
            {
                MockDataTest();
            }
        }
        private void MockDataTest()
        {
            _roures = new List<Building>
            {
                new Building
                {
                    Id = 888,
                    BuildingName = "BuildingName測試" ,
                    BuildingStreetName = "BuildingStreetName測試",
                    ZipCode = "ZipCode測試",
                    TownName = "Layour測試",
                    TownShortName = "TownShortName測試",
                    CityName  = "CreateId測試",
                    BuildingRank = 123,
                    ShortName  = "ShortName測試",         

                 },
            };
        }
        //public List<Building> GetBuildings()
        //{
        //    return _roures ;
        //    //throw new NotImplementedException();
        //}

        public List<Building> GetBuildingsByName(string name)
        {
            return _roures.FirstOrDefault(n => n.BuildingName == name).ToList();

            //throw new NotImplementedException();
        }

        IEnumerable<Building> IBuilding.GetBuildings()
        {
            return _roures;
        }
    }
}
