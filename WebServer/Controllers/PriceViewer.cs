using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebServer.Context;
using WebServer.Models;

namespace WebServer.Controllers;

[ApiController]
// [Route("[controller]")]
[Route("PriceViewer")]
public class PriceViewer(ProductsContext context, IMapper mapper) : ControllerBase
{
    [HttpGet("{barcode}/Price", Name = "GetPrice")]
    public async Task<ActionResult<PriceResult>> GetPrice(string barcode)
    {
        var product = await context.Products.FindAsync(barcode);
        
        if (product is null) 
            return NotFound();
        
        var priceResult = mapper.Map<PriceResult>(product);
        
        return priceResult;
    }
}