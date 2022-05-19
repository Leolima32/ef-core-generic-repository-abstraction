using GenericRepository.EntityFrameworkCore.Repository;

namespace GenericRepository.EntityFrameworkCore.Tests.Fakes
{
    public class FakeRepository: GenericRepository<FakeModel>
    {
        public FakeRepository(GenericDbContext db) : base(db) { }
    }
}
