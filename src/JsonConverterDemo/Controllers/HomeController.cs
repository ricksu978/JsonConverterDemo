using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json.Nodes;

namespace JsonConverterDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var d0 = new JsonObject();
            d0.Add("ts", DateTimeOffset.Now);
            d0.Add("type", nameof(JsonObject));
            
            dynamic d1 = new ExpandoObject();
            d1.ts = DateTimeOffset.Now;
            d1.type = nameof(ExpandoObject);

            var d2 = new Dictionary<string, object>();
            d2.Add("ts", DateTimeOffset.Now);
            d2.Add("type", "Dictionary<string, object>");

            return Ok(new
            {
                Result = "OK",
                Data = new JsonArray
                {
                    d0, d1, d2
                },
            });
        }
    }
}
