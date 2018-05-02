using AutoMapper;
using AvaliacaoMg.Data.Automapper;
using AvaliacaoMg.Data.Context;
using AvaliacaoMg.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Data.Repositories
{
    public class RepositoryBase<ViewModel, DomainModel>: IDisposable, IRepositoryBase<ViewModel, DomainModel> 
        where ViewModel : class
        where DomainModel : class

    {
        protected MapperConfiguration config = new AutomapperConfig().Configure();
        
        public RepositoryBase(DbContext db)
        {
            _db = db;
        }

        protected DbContext _db;

        public void Add(ViewModel obj)
        {
            var model = config.CreateMapper().Map<ViewModel, DomainModel>(obj);

            _db.Set<DomainModel>().Add(model);
            _db.SaveChanges();
        }

        public ViewModel GetById(int id)
        {
            var model =_db.Set<DomainModel>().Find(id);

            var viewModel = config.CreateMapper().Map<DomainModel, ViewModel>(model);

            return viewModel;
        }

        public IEnumerable<ViewModel> GetAll()
        {
            var models = _db.Set<DomainModel>();

            var viewModels = config.CreateMapper().Map<IEnumerable<DomainModel>, IEnumerable<ViewModel>>(models);

            return viewModels;
        }

        public void Update(ViewModel obj)
        {
            var model = config.CreateMapper().Map<ViewModel, DomainModel>(obj);

            _db.Entry(model).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Remove(ViewModel obj)
        {
            var model = config.CreateMapper().Map<ViewModel, DomainModel>(obj);

            _db.Set<DomainModel>().Remove(model);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
