namespace Test.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<CursoUsuario> CursosUsuarios { get; set; }
    }
}
