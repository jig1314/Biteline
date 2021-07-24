using Biteline.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biteline.Client.Pages
{
    public partial class AddItem
    {
        public AddItemViewModel AddItemViewModel { get; set; } = new AddItemViewModel() { Quantity = 1 };

        [Parameter]
        public EventCallback<AddItemViewModel> OnAddItem { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        protected async void SubmitItem()
        {
            await OnAddItem.InvokeAsync(AddItemViewModel);
            AddItemViewModel = new AddItemViewModel() { Quantity = 1 };
        }

        protected async void Cancel()
        {
            await OnClose.InvokeAsync();
            AddItemViewModel = new AddItemViewModel() { Quantity = 1 };
        }

    }
}
