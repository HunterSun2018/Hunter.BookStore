
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using Hunter.BookStore.Blazor.Client.Models;
using Hunter.BookStore.Books;
using Hunter.BookStore.Categories;

namespace Hunter.BookStore.Blazor.Client.Pages;

public partial class Books
{
    private IReadOnlyList<BookDto> BookList { get; set; }

    public class SelectListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    private List<SelectListItem> AuthorList { get; set; }
    private Guid SelectedListValue;

    public List<CategoryViewModel> Categories { get; set; }

    private int PageSize { get; } = 10;//LimitedResultRequestDto.DefaultMaxResultCount;
    private int CurrentPage { get; set; }
    private string CurrentSorting { get; set; }
    private int TotalCount { get; set; }

    private bool CanCreateBook { get; set; }
    private bool CanEditBook { get; set; }
    private bool CanDeleteBook { get; set; }

    private CreateUpdateBookDto NewBook { get; set; }

    private Modal CreateBookModal { get; set; }
    private Modal EditBookModal { get; set; }

    private Validations CreateValidationsRef;
    private Validations EditValidationsRef;

    private string selectedTab = "Book Information";

    public Books()
    {
        CanCreateBook = true;

        NewBook = new CreateUpdateBookDto();
    }

    protected override async Task OnInitializedAsync()
    {
        var authorLookup = await BookAppService.GetAuthorLookupAsync();
        AuthorList = authorLookup.Items
                .Select(x => new SelectListItem { Name = x.Name, Id = x.Id })
                .ToList();

        var categoryLookupDto = await BookAppService.GetCategoryLookupAsync();

        Categories = new List<CategoryViewModel>();
        foreach (var item in categoryLookupDto.Items.ToList())
        {
            var cvm = new CategoryViewModel();

            cvm.Id = item.Id;
            cvm.Name = item.Name;
            cvm.IsSelected = false;

            Categories.Add(cvm);
        }
    }

    private Task OnSelectedTabChanged(string name)
    {
        selectedTab = name;

        return Task.CompletedTask;
    }

    private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<BookDto> e)
    {
        CurrentSorting = e.Columns
            .Where(c => c.SortDirection != SortDirection.Default)
            .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
            .JoinAsString(",");
        CurrentPage = e.Page - 1;

        await GetBooksAsync();
        await InvokeAsync(StateHasChanged);
    }

    private async Task GetBooksAsync()
    {
        var Result = await BookAppService.GetListAsync(
            new BookGetListInput
            {
                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,
                Sorting = CurrentSorting
            }
        );

        BookList = Result.Items;
        TotalCount = (int)Result.TotalCount;
    }

    private void OpenCreateBookModal()
    {
        CreateValidationsRef.ClearAll();

        NewBook = new CreateUpdateBookDto();
        CreateBookModal.Show();
    }

    private void CloseCreateBookModal()
    {
        CreateBookModal.Hide();
    }

    private async Task CreateBookAsync()
    {
        // if (await CreateValidationsRef.ValidateAll())
        {
            var selectedCategories = Categories.Where(x => x.IsSelected).ToList();
            if (selectedCategories.Any())
            {
                var categoryNames = selectedCategories.Select(x => x.Name).ToArray();
                NewBook.CategoryNames = categoryNames;
            }

            await BookAppService.CreateAsync(NewBook);

            await CreateBookModal.Hide();

            await InvokeAsync(StateHasChanged);
        }
    }

    private void OpenEditBookModal(BookDto bookDto)
    {
        EditValidationsRef.ClearAll();
    }

    private async Task DeleteBookAsync(BookDto bookDto)
    {
        await BookAppService.DeleteAsync(bookDto.Id);
    }

}