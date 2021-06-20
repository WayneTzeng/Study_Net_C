using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LifeEnterpot.Core.Models
{ 
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class Building
	{
		public Building()
			{
				BuildingName = string.Empty;
				BuildingStreetName = string.Empty;
				ZipCode = string.Empty;
			}
			public int Id { get; set; }
			public string BuildingName { get; set; }
			public string BuildingStreetName { get; set; }
			public string ZipCode { get; set; }
			public string TownName { get; set; }
			public string TownShortName { get; set; }
			public int BuildingRank { get; set; }
			public string CityName { get; set; }
			public string ShortName { get; set; }

        internal List<Building> ToList()
        {
            throw new NotImplementedException();
        }
    }
}