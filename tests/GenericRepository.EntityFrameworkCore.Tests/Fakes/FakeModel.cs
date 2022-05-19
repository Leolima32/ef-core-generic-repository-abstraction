using GenericRepository.EntityFrameworkCore.Model;
using System;

namespace GenericRepository.EntityFrameworkCore.Tests.Fakes
{
    public class FakeModel: BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
