namespace ProjetoEscola.Models
{
    public class Professor
    {

        public int IdProfessor { get; set; }
        public string NomeProfessor { get; set; }
        public ICollection<Notas> NotaProfessor { get; set; }
    }
}
