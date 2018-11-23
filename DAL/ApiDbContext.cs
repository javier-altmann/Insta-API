using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        { }
        
        //aca van las tablas (dbset)
    }
}