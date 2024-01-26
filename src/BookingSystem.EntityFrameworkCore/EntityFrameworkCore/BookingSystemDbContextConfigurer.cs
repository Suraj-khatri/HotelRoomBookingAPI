using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.EntityFrameworkCore
{
    public static class BookingSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BookingSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BookingSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
