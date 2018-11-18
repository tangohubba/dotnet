using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace restapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<CacheData> Get(string id)
        {
            CacheData cd = new CacheData();
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDIS_SERVER"));
            IDatabase db = redis.GetDatabase();
            db.StringSet("12","test");

            cd.Value = db.StringGet(id);
            cd.Name = "12";
            return cd;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] CacheData data)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string data)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDIS_SERVER"));
            IDatabase db = redis.GetDatabase();
            db.StringSet(id,data);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
