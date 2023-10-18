using Microsoft.EntityFrameworkCore;
using MVC_IntroEx.Models;

namespace MVC_IntroEx.Data
{
    public class WebAppMVCContext : DbContext
    {


        public WebAppMVCContext(DbContextOptions<WebAppMVCContext> options): base(options)
        {           
        }

        public DbSet<Product> Products => Set<Product>();








    }
}
