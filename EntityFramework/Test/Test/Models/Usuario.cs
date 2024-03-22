namespace Test.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int PaisId { get; set; }
        public Pais? Pais { get; set; }

        public ICollection<CursoUsuario> CursosUsuarios { get; set; }
    }
}
