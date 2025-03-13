namespace ProjetoEscola.Models
{
    public class Disciplina
    {
        public int idDis { get; set; }

        public string nomeDis { get; set; }

        public ICollection<Notas> NotaDisciplina { get; set; }
    }
}
