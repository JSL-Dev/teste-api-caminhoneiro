using System;
using System.Collections.Generic;
using System.Text;

namespace JSL.DDD.Domain.Entities
{
    public class Caminhao : EntityBase
    {

        public  string Marca { get; set; }

        public  string Modelo { get; set; }

        public  string Placa { get; set; }

        public  int Eixos { get; set; }


        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
