using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using JSL.DDD.Domain.Entities;
using JSL.DDD.Domain.Helpers;
using JSL.DDD.Repository.Context;
using JSL.DDD.Repository.Repository;
using JSL.DDD.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JSL.DDD.API.Controllers
{
    [Route("api/[controller]")]

    public class MotoristaController : ControllerBase
    {

        private MotoristaService appService;
        ReturnServices retorno = new ReturnServices();

        public MotoristaController(JslContext _context)
        {
            var rep = new MotoristaRepository(_context);
            appService = new MotoristaService(rep);

        }

        // GET: api/<MotoristaController>
        [HttpGet]
        public IEnumerable<Motorista> Get()
        {
            return appService.GetAll();
        }


        // GET api/<MotoristaController>/5
        [HttpGet("{id}")]
        public Motorista Get(int id)
        {
            return appService.Get(id);
        }




        // POST api/<MotoristaController>
        [HttpPost]
        public ReturnServices Post([FromBody] Motorista motorista)
        {

            try
            {
                appService.Insert(motorista);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = $"Erro ao tentar incluir um motorista {ex.Message}";
            }
            return retorno;
        }




        // PUT api/<MotoristaController>/5
        [HttpPut("{id}")]
        public ReturnServices Put(int id, [FromBody] Motorista motorista)
        {
            try
            {
                appService.Update(motorista);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = $"Erro ao tentar editar um motorista {ex.Message}";
            }
            return retorno;
        }

        // DELETE api/<MotoristaController>/5
        [HttpDelete("{id}")]
        public ReturnServices Delete(int id)
        {
            try
            {
                appService.Delete(id);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = $"Erro ao tentar excluir o motorista {ex.Message}";
            }
            return retorno;
        }

        [HttpGet]
        [Route("google")]
        public ReturnServices google(string endereco)
        {




            var address = endereco;

            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);



            retorno.Result = true;
            retorno.ErrorMessage = $"{latitude}-{longitude}";
            return retorno;
        }
    }
}
