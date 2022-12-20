using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class APIController : ControllerBase
{
    Dictionary<int, Category> categories = new Dictionary<int, Category>(){
        {1, new Category(1, "Pcs")},
        {2, new Category(2, "Phones")},
    };
    private readonly ILogger<APIController> _logger;
    public APIController(ILogger<APIController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Product
        {
            ProductId = (index),
            Designation = "Product " + index,
            Price = Random.Shared.NextInt64(index * 100),
            CategoryID = categories[index < 3 ? 1 : 2].CategoryID
        })
        .ToArray();
    }
}

