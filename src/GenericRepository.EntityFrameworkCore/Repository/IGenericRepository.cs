using LF.GenericRepository.EntityFrameworkCore.Model;
using static LF.GenericRepository.EntityFrameworkCore.Model.BaseModel;

namespace LF.GenericRepository.EntityFrameworkCore.Repository
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Guid Add(T obj);
        void Update(T obj);
        void Remove(Guid id);
        Task<Guid> AddAsync(T obj, CancellationToken ct);
    }
}
