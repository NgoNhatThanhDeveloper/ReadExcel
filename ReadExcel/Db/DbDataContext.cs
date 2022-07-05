using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReadExcel.Model;


namespace ReadExcel.Db
{
    public class DbDataContext : DbContext
    {
        private readonly IConfigurationRoot _builder;

        public DbDataContext()
        {
            _builder = new ConfigurationBuilder()
                             .AddJsonFile($"appsettings.json", true, true)
                             .Build();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_builder.GetConnectionString("ConnStr"));
        }
        public DbSet<DataEntity> Data { get; set; }

    }
}
