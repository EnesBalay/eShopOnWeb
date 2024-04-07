using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Pages.OrderPage;

public partial class List : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderService OrderService { get; set; }

    private List<Order> orders = new List<Order>();
    private Details DetailsComponent { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            orders = await OrderService.List();

            CallRequestRefresh();
        }

        await base.OnAfterRenderAsync(firstRender);
    }
    private async void DetailsClick(int id)
    {
        await DetailsComponent.Open(id);
    }

    private async Task ReloadOrders()
    {
        orders = await OrderService.List();
        StateHasChanged();
    }
}
