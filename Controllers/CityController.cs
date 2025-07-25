﻿using Locamobi.DTO_;
using Microsoft.AspNetCore.Mvc;
using Locamobi.Contracts.Service;
using Locamobi.Entity;
using Locamobi.Response;
using Locamobi.Response.City;

namespace Locamobi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CityController : ControllerBase
    {
        private ICityService _service;

        public CityController(ICityService cityService)
        {
            _service = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<CityGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CityEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(CityInsertDTO city)
        {
            return Ok(await _service.Post(city));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(CityEntity city)
        {
            return Ok(await _service.Update(city));
        }

    }
}
