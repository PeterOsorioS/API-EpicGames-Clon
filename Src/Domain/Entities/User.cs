using System.ComponentModel.DataAnnotations;


namespace Epic.Domain.Entities
{
    public sealed class User
    {
        [Key]
        public long Id { get; private set; }
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Country { get; private set; }
    }
}
