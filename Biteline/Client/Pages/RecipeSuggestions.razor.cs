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
    public partial class RecipeSuggestions
    {
        public List<Recipe> Recipes { get; private set; }

        [Inject]
        private HttpClient Http { get; set; }

        [Parameter]
        public IEnumerable<string> Items { get; set; } = new List<string>();

        IEnumerable<string> SelectedItems { get; set; } = new List<string>();

        protected async void SelectedItemsChanged(IEnumerable<string> items)
        {
            if (items?.Count() > 0)
            {
                Recipes = await Http.GetFromJsonAsync<List<Recipe>>($"api/recipes/{string.Join(',', items)}");
                StateHasChanged();
            }
        }
    }
}
