using Biteline.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Biteline.Client.Pages
{
    public partial class PopularRecipes
    {
        public List<Recipe> Recipes { get; private set; }

        [Inject]
        private HttpClient Http { get; set; }

        public bool Loading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Loading = true;

            Recipes = await Http.GetFromJsonAsync<List<Recipe>>($"api/recipes");

            Loading = false;
            StateHasChanged();
        }
    }
}
