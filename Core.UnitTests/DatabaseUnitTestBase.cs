using Core.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Core.UnitTests
{
    // Setup a base class that uses a in-mem database for unit tests.
    // Inspired by the official example https://github.com/dotnet/EntityFramework.Docs/blob/main/samples%2Fcore%2FTesting%2FTestingWithoutTheDatabase%2FSqliteInMemoryBloggingControllerTest.cs

    [Parallelizable(ParallelScope.Children)] // This enables parallel execution for tests in this class
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)] // Create a new instance per test.
    public abstract class DatabaseUnitTestBase
    {
        private DbConnection _connection;
        private DbContextOptions<DemoContext> _contextOptions;

        [SetUp]
        public void SetUp()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed at the end of the test 
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<DemoContext>()
                .UseSqlite(_connection)
                .Options;

            using var context = new DemoContext(_contextOptions);
            context.Database.EnsureCreated();
        }

        protected DemoContext CreateContext() => new(_contextOptions);

        [TearDown]
        public void TearDown()
        {
            _connection?.Dispose();
        }
    }
}
