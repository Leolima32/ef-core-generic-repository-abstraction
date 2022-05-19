using Microsoft.EntityFrameworkCore;

namespace GenericRepository.EntityFrameworkCore.Tests.Fakes
{
    public class FakeContext : GenericDbContext
    {
        public FakeContext(DbContextOptions options) : base(options) { }
        public DbSet<FakeModel> Model { get; set; }
    }
}
