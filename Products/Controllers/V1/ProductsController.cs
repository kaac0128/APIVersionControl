using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.DTO;
using System.Text.Json;

namespace Products.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string ApiTestURL = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetProductsDataV2")]
        public async Task<IActionResult> GetProductsDataAsync()
        {

            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var productsData = await JsonSerializer.DeserializeAsync<List<Product>>(response);

            return Ok(productsData);
        }
    }
}
