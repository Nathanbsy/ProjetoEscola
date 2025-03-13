namespace ProjetoEscola.Models
{
    public class Aluno
    {
        public int idAluno { get; set; }

        public string nomeAluno { get; set; }

        public int Faltas { get; set; }

        public ICollection<Notas> NotaAluno { get; set; }
        
    }
}
