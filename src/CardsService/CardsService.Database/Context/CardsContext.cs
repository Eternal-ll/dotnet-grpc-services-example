using CardsService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardsService.Database.Context
{
    public class CardsContext : DbContext
    {
        public CardsContext()
        {
            
        }
        public CardsContext(DbContextOptions<CardsContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Card> Cards { get; set; }
    }
}
