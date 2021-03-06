﻿using System;
using System.Collections.Generic;

namespace ProjetoEdux.Domains
{
    public partial class Turma : BaseDomain
    {
        public Turma()
        {
            AlunoTurma = new HashSet<AlunoTurma>();
            ProfessorTurma = new HashSet<ProfessorTurma>();
        }

        public Guid IdTurma { get; set; }
        public string Descricao { get; set; }
        public Guid? IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }
        public virtual ICollection<ProfessorTurma> ProfessorTurma { get; set; }
    }
}
