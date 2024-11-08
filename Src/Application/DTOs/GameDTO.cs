using Epic.Domain.ValueObjects;

namespace Epic.Application.DTOs
{
    public class GameDTO
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Genre Genre { get; private set; }
        public decimal Price { get; private set; }
    }
}
