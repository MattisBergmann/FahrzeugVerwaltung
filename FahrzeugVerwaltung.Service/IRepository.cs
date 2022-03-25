using System.Collections.Generic;

namespace FahrzeugVerwaltung.Service
{
    public interface IRepository<TId, TModel>
    {
        void Save(TModel entity);
        TModel Get(TId ident);
        IEnumerable<TModel> GetAll();
        void Update(TModel entity);
        void Delete(TModel entity);
    }
}
