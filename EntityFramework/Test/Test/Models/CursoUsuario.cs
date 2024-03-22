namespace Test.Models
{
    public class CursoUsuario
    {
        public int  Id { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
