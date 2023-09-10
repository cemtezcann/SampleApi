using Microsoft.EntityFrameworkCore;
using SampleApi.Core;

namespace SampleApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        
        public DbSet<ProductEntity> productEntities  { get;set; }
    }
    
}
