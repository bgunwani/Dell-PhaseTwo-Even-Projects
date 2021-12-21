using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreWebAPIFundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<string> values = new List<string>()
        {
            "ValueOne", "ValueTwo", "ValueThree"
        };

        // Get All Values
        [HttpGet]
        public List<string> GetValues()
        {
            return values;
        }

        // Get Value By Index
        [HttpGet]
        [Route("{index}")]
        public string GetValue(int index)
        {
            return values[index];
        }

        // Add New Value
        [HttpPost]
        public void PostValue([FromBody]string value)
        {
            values.Add(value);
        }
        
        // Update Existing Value By Index
        [HttpPut]
        [Route("{index}")]
        public void PutValue(int index, [FromBody]string value)
        {
            values[index] = value;
        }

        // Delete Existing Value By Index
        [HttpDelete]
        [Route("{index}")]
        public void DeleteValue(int index)
        {
            values.RemoveAt(index);
        }
    }
}
