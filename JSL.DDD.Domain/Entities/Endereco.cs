using System;
using System.Collections.Generic;
using System.Text;

namespace JSL.DDD.Domain.Entities
{
    public class Endereco : EntityBase
    {

        public  string Logradouro { get; set; }

        public  string Numero { get; set; }
        public  string Cep { get; set; }

        public  string Bairro { get; set; }
        public  string Cidade { get; set; }
        public  string Estado { get; set; }

        public  string Latitude { get; set; }
        public  string Longetude { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
