using Core.Database;
using Core.Integrations;
using Core.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Products
{
    public interface IProductService
    {
        Task<bool> CheckAvailability(string productKey, string instanceId, int passengerCount, CancellationToken cancellationToken);
        Task<ICollection<ProductEntity>> GetProducts(CancellationToken cancellationToken);
        Task<ProductEntity> Insert(ProductEntity productEntity, CancellationToken cancellationToken);
    }

    public class ProductService(DemoContext demoContext, IServiceProvider provider) : IProductService
    {
        public async Task<ICollection<ProductEntity>> GetProducts(CancellationToken cancellationToken)
        {
            return await demoContext.Products
                .Include(p => p.Tags)
                .ToListAsync(cancellationToken);
        }

        public async Task<ProductEntity> Insert(ProductEntity productEntity, CancellationToken cancellationToken)
        {
            await AssertTags(productEntity, cancellationToken);

            var product = demoContext.Products.Add(productEntity);
            await demoContext.SaveChangesAsync(cancellationToken);
           
            return product.Entity;
        }

        // Check if tags already exist to avoid adding duplicates.
        internal async Task AssertTags(ProductEntity productEntity, CancellationToken cancellationToken)
        {
            if (productEntity.Tags.Count == 0) return; // Exit early

            var existingTags = await demoContext.ProductTags
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            foreach (var tag in productEntity.Tags)
            {
                var existingTag = existingTags.FirstOrDefault(et => tag.Tag == tag.Tag);
                if (existingTag is null) continue;

                tag.Id = existingTag.Id;
            }
        }

        public async Task<bool> CheckAvailability(string productKey, string instanceId, int passengerCount, CancellationToken cancellationToken)
        {
            // Quick and dirty routing code. Should build some wrapper/factory code that handles this in a generic way and not using magic strings.
            if (productKey.Contains("dummy"))
            {
                var dummyClient = provider.GetRequiredKeyedService<IIntegrationClient>("dummy");
                return await dummyClient.CheckLiveAvailability(productKey, instanceId, passengerCount, cancellationToken);
            }
            else if (productKey.Contains("proto"))
            {
                var protoClient = provider.GetRequiredKeyedService<IIntegrationClient>("proto");
                return await protoClient.CheckLiveAvailability(productKey, instanceId, passengerCount, cancellationToken);
            }
            return false;
        } 
    }
}
