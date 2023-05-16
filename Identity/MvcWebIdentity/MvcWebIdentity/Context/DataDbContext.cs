using Microsoft.EntityFrameworkCore;

namespace MvcWebIdentity.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }
    }
}
