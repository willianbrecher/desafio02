using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace Desafio.EntityFramework
{
    public class EntityFrameworkDesafioContextFactory : IDesignTimeDbContextFactory<DesafioDbContext>
    {
        public DesafioDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<DesafioDbContext> builder = new();
            string connectionString = configuration["ConnectionStrings:SQLDatabase"];
            builder.UseSqlite(connectionString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "application"));
            return new DesafioDbContext(builder.Options);
        }
    }
}
