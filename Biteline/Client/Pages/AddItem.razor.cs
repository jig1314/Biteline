﻿using Biteline.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biteline.Client.Pages
{
    public partial class AddItem
    {
        public AddItemViewModel AddItemViewModel { get; set; } = new AddItemViewModel();

        [Parameter]
        public EventCallback<AddItemViewModel> OnAddItem { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        protected async void SubmitItem()
        {
            await OnAddItem.InvokeAsync(AddItemViewModel);
            AddItemViewModel = new AddItemViewModel();
        }

        protected async void Cancel()
        {
            await OnClose.InvokeAsync();
            AddItemViewModel = new AddItemViewModel();
        }

    }
}