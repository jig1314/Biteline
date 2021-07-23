using Biteline.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biteline.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentersController : ControllerBase
    {
        [HttpGet("{zipCode}")]
        public async Task<IEnumerable<Center>> Get(string zipCode)
        {
            var client = new RestClient("https://real-time-google-search.p.rapidapi.com/search?q=food%20donation%20center%20"+zipCode+"&num=10");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "10faf544acmshc2fad71ec2c1fecp122c84jsnfb3ed81442a8");
            request.AddHeader("x-rapidapi-host", "real-time-google-search.p.rapidapi.com");
            IRestResponse response = await client.ExecuteAsync(request);

            var content = JsonConvert.DeserializeObject<JToken>(response.Content);

            var data = content.Last.First;
            var results = data.SelectTokens("organic_results[*]");
            var centers = results.Select(center => new Center()
            {
                Name = (string)center["title"],
                Description = (string)center["desc"],
                URL = (string)center["url"]
            });

            return centers;
        }
    }
}
