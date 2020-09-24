using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEdux.Domains
{
    public partial class AlunoTurma
    {
        public AlunoTurma()
        {
            ObjetivoAluno = new HashSet<ObjetivoAluno>();
        }
        
        [Key]
        public Guid IdAlunoTurma { get; set; }
        public string Matricula { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdTurma { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ObjetivoAluno> ObjetivoAluno { get; set; }
    }
}
