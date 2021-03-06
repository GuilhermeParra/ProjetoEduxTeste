﻿using System;
using System.Collections.Generic;

namespace ProjetoEdux.Domains
{
    public partial class ProfessorTurma : BaseDomain
    {
        public Guid IdProfessorTurma { get; set; }
        public string Descricao { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdTurma { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
