using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;
namespace BlazorAdmin.Services;

public class CachedOrderServiceDecorator : IOrderService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly OrderService _orderService;
    private ILogger<CachedOrderServiceDecorator> _logger;

    public CachedOrderServiceDecorator(ILocalStorageService localStorageService, OrderService orderService, ILogger<CachedOrderServiceDecorator> logger)
    {
        _localStorageService = localStorageService;
        _orderService = orderService;
        _logger = logger;
    }

    public async Task<Order> ChangeStatus(Order order)
    {
        var result = await _orderService.ChangeStatus(order);
        await RefreshLocalStorageList();
        return result;
    }

    public async Task<OrderDetail> GetById(int id)
    {
        var result = await _orderService.GetById(id);
        Console.WriteLine(result);

        return result;
    }
    public async Task<List<Order>> List()
    {
        string key = "orders";
        var cacheEntry = await _localStorageService.GetItemAsync<CacheEntry<List<Order>>>(key);
        if (cacheEntry != null)
        {
            _logger.LogInformation("Loading orders from local storage.");
            if (cacheEntry.DateCreated.AddMinutes(1) > DateTime.UtcNow)
            {
                return cacheEntry.Value;
            }
            else
            {
                _logger.LogInformation($"Loading {key} from local storage.");
                await _localStorageService.RemoveItemAsync(key);
            }
        }
        var orders = await _orderService.List();
        var entry = new CacheEntry<List<Order>>(orders);
        await _localStorageService.SetItemAsync(key, entry);
        return orders;
    }

    public async Task<List<Order>> ListPaged(int pageSize)
    {
        string key = "orders";
        var cacheEntry = await _localStorageService.GetItemAsync<CacheEntry<List<Order>>>(key);
        if (cacheEntry != null)
        {
            _logger.LogInformation("Loading orders from local storage.");
            if (cacheEntry.DateCreated.AddMinutes(1) > DateTime.UtcNow)
            {
                return cacheEntry.Value;
            }
            else
            {
                _logger.LogInformation($"Loading {key} from local storage.");
                await _localStorageService.RemoveItemAsync(key);
            }
        }
        var orders = await _orderService.List();
        var entry = new CacheEntry<List<Order>>(orders);
        await _localStorageService.SetItemAsync(key, entry);
        return orders;
    }
    private async Task RefreshLocalStorageList()
    {
        string key = "orders";

        await _localStorageService.RemoveItemAsync(key);
        var orders = await _orderService.List();
        var entry = new CacheEntry<List<Order>>(orders);
        await _localStorageService.SetItemAsync(key, entry);
    }
}
