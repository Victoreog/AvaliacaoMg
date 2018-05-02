using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Domain.IRepositories
{
    public interface IRepositoryBase<ViewModel, DomainModel>
        where ViewModel : class
        where DomainModel : class
    {
        void Add(ViewModel obj);
        ViewModel GetById(int id);
        IEnumerable<ViewModel> GetAll();
        void Update(ViewModel obj);
        void Remove(ViewModel obj);
        void Dispose();
    }
}
