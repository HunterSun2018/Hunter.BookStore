
using System;
using System.ComponentModel.DataAnnotations;

namespace Hunter.BookStore.Blazor.Client.Models;

public class CategoryViewModel
{
    public Guid Id { get; set; }

    public bool IsSelected { get; set; } = false;

    [Required]
    public string Name { get; set; }
}