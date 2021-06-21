using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeEnterpot.Core.Providers;
using WebApplication2;
using System.Reflection.Emit;
using LifeEnterpot.WebAPI.Controllers;

namespace FakeXiecheng.API.Controllers
{
    [Route("api/app/[controller]")]
    [ApiController]
    public class Building : Controller
    {
        private IBuilding _Building;

        public Building(IBuilding Building)
        {
            _Building = Building;

        }

        public IActionResult GetBuildings()
        {
            var routes = _Building.GetBuildings() ;
            return Ok(routes);

        }


    }
}
