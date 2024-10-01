using System.ComponentModel.DataAnnotations;

namespace CardsService.Database.Entities.Base
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
