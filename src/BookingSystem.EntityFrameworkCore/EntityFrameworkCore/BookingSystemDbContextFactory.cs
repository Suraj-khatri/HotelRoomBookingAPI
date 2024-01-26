using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using BookingSystem.Configuration;
using BookingSystem.Web;

namespace BookingSystem.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BookingSystemDbContextFactory : IDesignTimeDbContextFactory<BookingSystemDbContext>
    {
        public BookingSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BookingSystemDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BookingSystemDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BookingSystemConsts.ConnectionStringName));

            return new BookingSystemDbContext(builder.Options);
        }
    }
}
