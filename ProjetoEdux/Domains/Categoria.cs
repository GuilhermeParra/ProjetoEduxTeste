using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEdux.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Objetivo = new HashSet<Objetivo>();
        }

        [Key]
        public Guid IdCategoria { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Objetivo> Objetivo { get; set; }
    }
}
