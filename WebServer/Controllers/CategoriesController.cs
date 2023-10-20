using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IDataService _dataService;

    public CategoriesController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public IActionResult GetCetagories(string? name = null)
    {

        if(name != null)
        {
            var categories = _dataService.GetCategoriesByName(name);
            return Ok(categories);
        }
        return Ok(_dataService.GetCategories());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var category = _dataService.GetCategory(id);
        if(category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryModel model)
    {
        var category = new Category
        {
            Name = model.Name,
            Description = model.Description
        };

        _dataService.CreateCategory(category);

        return Ok(category);
    }


    
}
