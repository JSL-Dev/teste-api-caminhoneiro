using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JSL.DDD.Domain.Entities
{
    public class Motorista : EntityBase
    {

        public virtual string Nome { get; set; }

        public virtual string Sobrenome { get; set; }

        public int CaminhaoId { get; set; }

        public int EnderecoId { get; set; }

        [ForeignKey("CaminhaoId")]
        public  Caminhao Caminhao { get; set; }

        [ForeignKey("EnderecoId")]
        public  Endereco Endereco { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
