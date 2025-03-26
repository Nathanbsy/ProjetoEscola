namespace ProjetoEscola.Models
{
    public class Aluno
    {
        public int idAluno { get; set; }

        public string nomeAluno { get; set; }

        public DateOnly DataNascimento { get; set; }

        public ICollection<Notas> NotaAluno { get; set; }
        
    }
}
