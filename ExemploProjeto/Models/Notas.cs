namespace ProjetoEscola.Models
{
    public class Notas
    {
        public int IdNota { get; set; }

        public int IdAluno { get; set; }

        public Aluno Aluno { get; set; }

        public int IdDisciplina { get; set; }

        public Disciplina Disciplina { get; set; }

        public int IdProfessor { get; set; }

        public Professor Professor { get; set; }

        public string Nota { get; set; }

        public int Faltas { get; set; }

    }
}
