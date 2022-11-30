using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.DTO;
using System.Text.Json;

namespace Products.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsControllerV2 : ControllerBase
    {
        private const string ApiTestURL = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsControllerV2(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProductsData")]
        public async Task<IActionResult> GetProductsDataAsync()
        {

            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var productsData = await JsonSerializer.DeserializeAsync<List<Product>>(response);

            return Ok(productsData);
        }
    }
}
