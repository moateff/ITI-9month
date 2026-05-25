using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnersController : ControllerBase
    {
        public readonly IOwnersService _ownersService;
        public OwnersController(IOwnersService ownersService)
        {
            //_ownersService = new OwnersService(
            //    new OwnersRepository(new InMemoryContext()),
            //    new CarsRepository(new InMemoryContext()),
            //    new CreditCardService());
            _ownersService = ownersService;
        }
        [HttpGet]
        public List<Owner> Get()
        {
            return _ownersService.GetOwners();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Owner Get(int id)
        {
            return _ownersService.GetById(id);
        }

        [HttpPost]
        public bool Post([FromBody] Owner owner)
        {
            return _ownersService.AddOwner(owner);
        }

        [HttpPost]
        public string BuyCar([FromBody] BuyCarInput input)
        {
            return _ownersService.BuyCar(input);
        }
    }
}
