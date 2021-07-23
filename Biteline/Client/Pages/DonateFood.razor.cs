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
    public partial class DonateFood
    {
        [Inject]
        private HttpClient Http { get; set; }

        public string ZipCode { get; set; }

        public List<Center> Centers { get; set; } = new List<Center>();

        public bool Searching { get; set; }

        protected async void SearchForCenters()
        {
            if (!string.IsNullOrWhiteSpace(ZipCode))
            {
                Searching = true;

                Centers = await Http.GetFromJsonAsync<List<Center>>($"api/centers/{ZipCode}");

                Searching = false;
                StateHasChanged();
            }
        }
    }
}
