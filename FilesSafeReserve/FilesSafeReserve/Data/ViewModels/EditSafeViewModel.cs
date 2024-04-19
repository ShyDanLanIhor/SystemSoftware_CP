﻿using BlazorBootstrap;
using FilesSafeReserve.Data.Entities.Forms;
using Microsoft.AspNetCore.Components.Forms;

namespace FilesSafeReserve.Data.ViewModels;

public class EditSafeViewModel
{
    public Modal SuccessModal { get; set; } = default!;
    public Modal FailureModal { get; set; } = default!;

    public EditContext EditContext { get; set; }

    public VirtualSafeForm VirtualSafe { get; set; } = new();

    public EditSafeViewModel()
    {
        EditContext = new(VirtualSafe);
    }
}
