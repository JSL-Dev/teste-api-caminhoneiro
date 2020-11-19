using JSL.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSL.DDD.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        ///INterface para inserir os dados no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        void Insert(T entidade);

        /// <summary>
        /// Interface para modificar os dados no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        void Update(T entidade);

        /// <summary>
        /// Interface para excluir um dado do banco de dados
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Interface para listar todos os registros
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Interface para mostrare um unico registro no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

    }
}
