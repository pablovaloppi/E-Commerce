namespace Test.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
