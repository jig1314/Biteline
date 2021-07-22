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
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Recipe>> Get()
        {
            var client = new RestClient("https://tasty.p.rapidapi.com/recipes/list?from=0&size=9&tags=best_of_tasty");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "10faf544acmshc2fad71ec2c1fecp122c84jsnfb3ed81442a8");
            request.AddHeader("x-rapidapi-host", "tasty.p.rapidapi.com");
            IRestResponse response = await client.ExecuteAsync(request);

            var content = JsonConvert.DeserializeObject<JToken>(response.Content);

            var results = content.SelectTokens("results[*]");
            var recipes = results.Select(recipe => new Recipe()
            {
                Name = (string)recipe["name"],
                ThumbnailURL = (string)recipe["thumbnail_url"],
                PrepTime = (string)recipe["cook_time_minutes"],
                URL = "https://tasty.co/recipe/" + (string)recipe["slug"]
            });

            return recipes;
        }

        [HttpGet("{items}")]
        public async Task<IEnumerable<Recipe>> GetRecipesByIngredients(string items)
        {
            var client = new RestClient("https://tasty.p.rapidapi.com/recipes/list?from=0&size=9&q="+items);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "10faf544acmshc2fad71ec2c1fecp122c84jsnfb3ed81442a8");
            request.AddHeader("x-rapidapi-host", "tasty.p.rapidapi.com");
            IRestResponse response = await client.ExecuteAsync(request);

            var content = JsonConvert.DeserializeObject<JToken>(response.Content);

            var results = content.SelectTokens("results[*]");
            var recipes = results.Select(recipe => new Recipe()
            {
                Name = (string)recipe["name"],
                ThumbnailURL = (string)recipe["thumbnail_url"],
                PrepTime = (string)recipe["cook_time_minutes"],
                URL = "https://tasty.co/recipe/" + (string)recipe["slug"]
            });

            return recipes;
        }
    }
}
