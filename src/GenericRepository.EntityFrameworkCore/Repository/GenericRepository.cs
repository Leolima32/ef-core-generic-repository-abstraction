using GenericRepository.EntityFrameworkCore.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.EntityFrameworkCore.Repository
{

    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
    {
        private GenericRepository.EntityFrameworkCore.GenericDbContext _db;

        public GenericRepository(GenericDbContext db)
        {
            _db = db;
        }

        public virtual Guid Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();

            return obj.Id;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _db.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public virtual void Remove(Guid id)
        {
            var entity = GetById(id);
            _db.Set<TEntity>().Remove(entity);
            _db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _db.Set<TEntity>().Where(p => p.Id == id).FirstOrDefault();
        }

        public virtual void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
