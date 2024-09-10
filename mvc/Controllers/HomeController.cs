using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Httpclients;
using mvc.Models;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly InventoryHttpClient _inventoryHttpClient;

    public HomeController(ILogger<HomeController> logger, InventoryHttpClient inventoryHttpClient)
    {
        _logger = logger;
        _inventoryHttpClient = inventoryHttpClient;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Products"] = await _inventoryHttpClient.GetProductsAsync();


        return View();
    }

    public async Task<IActionResult> Inventory(int selectedCategory)
    {

        Console.WriteLine(selectedCategory);

        ViewData["Categories"] = await _inventoryHttpClient.GetCategoriesAsync();
        ViewData["Inventories"] = await _inventoryHttpClient.GetInventoriesAsync(selectedCategory);
        ViewData["SelectedCat"] = selectedCategory;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
