using Biteline.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biteline.Client.Pages
{
    public partial class EditItem
    {
        [Parameter]
        public AddItemViewModel EditItemViewModel { get; set; }

        [Parameter]
        public EventCallback<AddItemViewModel> OnEditItem { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        protected async void SubmitItem()
        {
            await OnEditItem.InvokeAsync(EditItemViewModel);
            EditItemViewModel = new AddItemViewModel();
            await OnClose.InvokeAsync();
        }

        protected async void Cancel()
        {
            await OnClose.InvokeAsync();
            EditItemViewModel = new AddItemViewModel();
        }

    }
}
