using JSL.DDD.Domain.Entities;
using JSL.DDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSL.DDD.Services
{
    public class MotoristaService : IMotoristaRepository
    {

        IMotoristaRepository _motoristaRepository;
        public MotoristaService(IMotoristaRepository motoristaReposwitory)
        {
            _motoristaRepository = motoristaReposwitory;
        }

        public void Delete(int id)
        {
            _motoristaRepository.Delete(id);
        }

        public Motorista Get(int id)
        {
            return _motoristaRepository.Get(id);
        }

        public List<Motorista> GetAll()
        {
            return _motoristaRepository.GetAll();
        }

        public void Insert(Motorista entidade)
        {
          if (entidade.Valida)
            {
                _motoristaRepository.Insert(entidade);
            }
        }

        public void Update(Motorista entidade)
        {
            if (entidade.Valida)
            {
                _motoristaRepository.Update(entidade);
            }
        }
    }
}
