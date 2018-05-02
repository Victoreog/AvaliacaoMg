using AutoMapper;
using AvaliacaoMg.Data.Automapper;
using AvaliacaoMg.Data.Context;
using AvaliacaoMg.Data.ViewModels;
using AvaliacaoMg.Domain.Entities;
using AvaliacaoMg.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoMg.Data.Repositories
{
    public class ClienteRepository: RepositoryBase<ClienteViewModel, Cliente>
    {
        public ClienteRepository(DbContext db) :base(db)
        {
            
        }
    
        public ClienteViewModel GetByIdWithIncludes(int id)
        {
            var model = _db.Set<Cliente>().Include("Socios").Include("Contatos").Single(x => x.IdCliente == id);

            var viewModel = base.config.CreateMapper().Map<Cliente, ClienteViewModel>(model);

            return viewModel;
        }

        public IEnumerable<ClienteViewModel> GetAllWithIncludes()
        {
            var models = _db.Set<Cliente>().Include("Socios").Include("Contatos");

            var viewModels = config.CreateMapper().Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(models);

            return viewModels;
        }

        public void UpdateWithIncludes(ClienteViewModel viewmodel)
        {
            var model = config.CreateMapper().Map<ClienteViewModel, Cliente>(viewmodel);

            _db.Entry(model).State = EntityState.Modified;

            RemoveSocios(viewmodel);
            RemoveContatos(viewmodel);

            foreach (var item in model.Socios)
            {
                _db.Entry(item).State = EntityState.Added;
            }

            foreach (var item in model.Contatos)
            {
                _db.Entry(item).State = EntityState.Added;
            }

            _db.SaveChanges();

        }

        public void RemoveSocios(ClienteViewModel viewmodel)
        {
            var socios = _db.Set<Socio>().Where(x => x.IdCliente == viewmodel.IdCliente);

            foreach (var item in socios)
            {
                _db.Entry(item).State = EntityState.Deleted;
            }

            _db.SaveChanges();
        }

        public void RemoveContatos(ClienteViewModel viewmodel)
        {
            var contatos = _db.Set<Contato>().Where(x => x.IdCliente == viewmodel.IdCliente);

            foreach (var item in contatos)
            {
                _db.Entry(item).State = EntityState.Deleted;
            }

            _db.SaveChanges();

        }


    }
}
