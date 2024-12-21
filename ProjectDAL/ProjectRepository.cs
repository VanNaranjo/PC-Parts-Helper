using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectDAL
{
    public class ProjectRepository<T> : IRepository<T> where T : ProjectEntity
    {
        readonly private PCPartsContext _db;

        public ProjectRepository() { 
            _db = new PCPartsContext();
        }

        public async Task<List<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetSome(Expression<Func<T, bool>> match)
        {
            return await _db.Set<T>().Where(match).ToListAsync();
        }
        public async Task<T?> GetOne(Expression<Func<T, bool>> match)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(match);
        }

        public async Task<T> Add(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<int> Delete(int id)
        {
            T? currentEntity = await GetOne(ent => ent.Id == id);
            _db.Set<T>().Remove(currentEntity!);
            return _db.SaveChanges();
        }




    }
}
