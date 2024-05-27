using Core.Products;
using Core.Products.Entities;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Core.UnitTests
{
    // In mem database example
    [TestFixture]
    public class ProductServiceTests : DatabaseUnitTestBase
    {
        [Test]
        public async Task ProductTagAssert_ShouldMatchExistingAndNotCreateDuplicate()
        {
            // Setup
            using var context = CreateContext();

            var tag = "Awesome";
            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();
            
            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };
           
            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }


        // Test the same test again, to ensure that the in-mem database is unique per test. 
        [Test]
        public async Task TestDemo()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        // Test the same test again, to ensure that the in-mem database is unique per test. 
        [Test]
        public async Task TestParallel1()
        {
            await Task.Delay(1);
            Assert.Pass();
        }

        // Test the same test again, to ensure that the in-mem database is unique per test. 
        [Test]
        public async Task TestParallel2()
        {
            await Task.Delay(1);
            Assert.Pass();
        }

        // Test the same test again, to ensure that the in-mem database is unique per test. 
        [Test]
        public async Task TestParallel3()
        {
            await Task.Delay(1);
            Assert.Pass();
        }

        // Test the same test again, to ensure that the in-mem database is unique per test. 
        [Test]
        public async Task TestParallel4()
        {
            await Task.Delay(1);
            Assert.Pass();
        }


        // Test the same test again, to ensure that the in-mem database is unique per test. 
        [Test]
        public async Task TestParallel5WithDB()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB2()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB3()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB4()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB5()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB6()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB7()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB8()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB9()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestParallel5WithDB10()
        {
            // Setup
            using var context = CreateContext();
            var tag = "Awesome";

            context.ProductTags.Add(new ProductTagEntity { Image = "url", Tag = tag });
            await context.SaveChangesAsync();

            // Act
            var sut = new ProductService(context, Substitute.For<IServiceProvider>());
            var createProduct = new ProductEntity { Name = "Test", Tags = [new ProductTagEntity { Image = "url", Tag = tag }] };

            await sut.AssertTags(createProduct, CancellationToken.None);

            // Assert
            var tagsInDatabase = await context.ProductTags.ToListAsync();
            Assert.That(tagsInDatabase.Count, Is.EqualTo(1));
        }
    }
}