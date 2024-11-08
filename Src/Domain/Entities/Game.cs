using Epic.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;


namespace Epic.Domain.Entities
{
    public sealed class Game
    {
        [Key]
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Genre Genre { get; private set; }
        public decimal Price { get; private set; }
    }
}
