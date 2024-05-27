using API.External.Products.ViewModels;
using Core.Database;
using Core.Products.Entities;

namespace API.IntegrationTests
{
    public class Tests 
    {
        private CustomWebApplicationFactory _factory;
        [SetUp]
        public void Setup()
        {
            _factory = new CustomWebApplicationFactory();
        }

        [TearDown]
        public void TearDown() 
        {
            _factory.Dispose();
        }

        [Test]
        public async Task GetProductsTest()
        {
            var context = _factory.Services.GetService<DemoContext>()!;

            context.Products.Add(entity: new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Tag = "Super", Image = "url" }] });
            await context.SaveChangesAsync();

            var client = _factory.CreateClient();
            var response = await client.GetAsync("/products/");
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();

            Assert.That(products?.Count, Is.EqualTo(1));
        }
    }
}