using System.Collections.Generic;

namespace hospitalmanagement.Model{
    public interface IDataRepository<TEntity>{
        IEnumerable<TEntity> GetUsers();
        TEntity GetUser(int id);
        void Add(TEntity entity);
        void Update(TEntity dbentity,TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetUsers(string sortByfirstName,string sortBylastName,string search);

    }
}