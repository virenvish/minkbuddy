using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Minkbuddy.Services;
using Minkbuddy.Services.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minkbuddy.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private DataSyncService _service;
        private IConfiguration _config;

        public SyncController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult WakeUp()
        {
            return Ok("I m awake");
        }

        [HttpGet]
        [Route("category")]
        public IActionResult CategorySync()
        {
            string categoryUrl = _config["Woohoo:Urls:baseUrl"] + _config["Woohoo:Urls:categoryUrl"];
            categoryUrl = categoryUrl.Replace("{id}", "122");
            _service = new CategorySyncService(categoryUrl, _config);
            _service.Sync();
            return Ok("Category");
        }

        [HttpGet]
        [Route("product")]
        public IActionResult ProductSync()
        {
            return Ok("Product");
        }
    }
}
