using LF.GenericRepository.EntityFrameworkCore.Repository;

namespace LF.GenericRepository.EntityFrameworkCore.Tests.Fakes
{
    public class FakeRepository: GenericRepository<FakeModel>
    {
        public FakeRepository(GenericDbContext db) : base(db) { }
    }
}
