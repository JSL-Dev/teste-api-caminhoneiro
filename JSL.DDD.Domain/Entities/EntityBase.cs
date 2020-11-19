using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JSL.DDD.Domain.Entities
{
    public abstract class EntityBase
    {
        [NotMapped]
        public List<string> Erros { get; set; }

        public int Id { get; set; }
        public abstract void Validar();

        public EntityBase()
        {
            this.Erros = new List<string>();
        }

        public bool Valida
        {
            get
            {
                return (Erros == null || Erros.Count == 0);
            }
        }
    }
}
