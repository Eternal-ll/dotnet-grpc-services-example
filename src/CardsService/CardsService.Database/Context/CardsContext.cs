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
        public virtual DbSet<CardType> CardTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardType>(x =>
            {
                x.HasData(
                [
                    new()
                    {
                        Id = 1,
                        Name = "Без банка"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "От Уралсиба"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "От Совкомбанка"
                    },
                    new()
                    {
                        Id = 4,
                        Name = "От Сбербанка"
                    },
                ]);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
