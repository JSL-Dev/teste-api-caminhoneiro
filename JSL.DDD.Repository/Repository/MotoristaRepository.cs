using JSL.DDD.Domain.Entities;
using JSL.DDD.Domain.Interfaces;
using JSL.DDD.Repository.Context;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSL.DDD.Repository.Repository
{
    public class MotoristaRepository : IMotoristaRepository, IDisposable
    {

        private readonly JslContext _context;

        public MotoristaRepository(JslContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var original = _context.Motorista.Find(id);
            _context.Remove(original);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Motorista Get(int id)
        {
            var _motorista = new Motorista();
            var dados = _context.Motorista.Find(id);
            var _endereco = _context.Endereco.FirstOrDefault(e => e.Id == dados.EnderecoId);
            var _caminhao = _context.Caminhao.FirstOrDefault(c=> c.Id == dados.CaminhaoId);
            _motorista.Caminhao = _caminhao;
            _motorista.CaminhaoId = dados.CaminhaoId;
            _motorista.Endereco = _endereco;
            _motorista.EnderecoId = dados.EnderecoId;
            _motorista.Nome = dados.Nome;
            _motorista.Sobrenome = dados.Sobrenome;
            return _motorista;
        }

        public List<Motorista> GetAll()
        {

           List<Motorista> _motorista = new List<Motorista>();
            var dados = _context.Motorista.ToList();

            foreach (var item in dados)
            {
                var dadosMotorista = _context.Motorista.Find(item.Id);

                var _endereco = _context.Endereco.FirstOrDefault(e => e.Id == item.EnderecoId);
                var _caminhao = _context.Caminhao.FirstOrDefault(c => c.Id == item.CaminhaoId);

                item.Nome = dadosMotorista.Nome;
                item.Sobrenome = dadosMotorista.Sobrenome;
                item.Caminhao = _caminhao;
                item.CaminhaoId = item.CaminhaoId;
                item.Endereco = _endereco;
                item.EnderecoId = item.EnderecoId;

                _motorista.Add(item);
            }
            return _motorista.ToList();
        }

        public void Insert(Motorista entidade)
        {
            var googleLocation = Location(entidade.Endereco.Logradouro);
            entidade.Endereco.Latitude = googleLocation.Lat;
            entidade.Endereco.Longetude = googleLocation.Lng;
            var original = _context.Motorista.Add(entidade);
            _context.SaveChanges();
        }

        public void Update(Motorista entidade)
        {
            var original = _context.Motorista.Find(entidade.Id);
            original.Nome = entidade.Nome;
            original.Sobrenome = entidade.Sobrenome;
            original.CaminhaoId = entidade.CaminhaoId;
            original.EnderecoId = entidade.EnderecoId;

            var _endereco = _context.Endereco.FirstOrDefault(e => e.Id == entidade.EnderecoId);
            var _caminhao = _context.Caminhao.FirstOrDefault(c => c.Id == entidade.CaminhaoId);
            var googleLocation = Location(entidade.Endereco.Logradouro);

            original.Endereco = entidade.Endereco;
            original.Endereco.Latitude = googleLocation.Lat;
            original.Endereco.Longetude = googleLocation.Lng;
            original.Caminhao = entidade.Caminhao;

            _context.SaveChanges();
        }

        public Location Location(string endereco)
        {
            var client = new RestClient($"https://maps.googleapis.com/maps/api/geocode/json?address={endereco}&key=AIzaSyC43OvPgcIqkx5N846tch-o-L3pxziLVCM");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            dynamic dadosGoogle = JObject.Parse(response.Content);
            var loc = new Location();
            loc.Lat = dadosGoogle.results[0].geometry.location.lat;
            loc.Lng = dadosGoogle.results[0].geometry.location.lng;
            return loc;

        }
    }
}
