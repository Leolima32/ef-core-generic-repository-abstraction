using Xunit;
using System;
using LF.GenericRepository.EntityFrameworkCore.Repository;
using LF.GenericRepository.EntityFrameworkCore.Tests.Fakes;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LF.GenericRepository.EntityFrameworkCore.Tests
{
    public class GenericRepositoryTests
    {
        private readonly GenericRepository<FakeModel> mockRepository;
        private readonly FakeContext mockContext;
        public GenericRepositoryTests()
        {
            var mockDbOptions = new DbContextOptionsBuilder<FakeContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            mockContext = new FakeContext(mockDbOptions);
            mockContext.Database.EnsureCreated();
            mockRepository = new FakeRepository(mockContext);
        }
        [Fact]
        public void Should_Add_Entity()
        {
            var model = AddModel("Leonardo Ferreira", 26);

            var addedModel = mockContext.Model.Where(x => x.Id == model.Id).FirstOrDefault();

            Assert.Equal(model, addedModel);
        }

        [Fact]
        public void Should_Update_Entity()
        {
            var model = AddModel("Leonardo Ferreira", 26);

            model.Age = 19;

            mockRepository.Update(model);

            var updatedModel = mockContext.Model.Where(_ => _.Name == model.Name).FirstOrDefault();

            Assert.Equal(19, updatedModel?.Age);
        }

        [Fact]
        public void Should_Delete_Entity()
        {
            var model = AddModel("Leonardo Ferreira", 26);

            mockRepository.Remove(model.Id);

            IEnumerable<FakeModel> list = mockContext.Model.ToList();

            Assert.Empty(list);
        }

        [Fact]
        public void Should_List_Entity()
        {
            AddModel("Leonardo Ferreira", 26);
            AddModel("Gabriela Ferreira", 25);
            AddModel("Jose Ferreira", 55);

            IEnumerable<FakeModel> list = mockRepository.GetAll();

            Assert.NotEmpty(list);
            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void Should_Get_Entity_By_Id()
        {
            var model = AddModel("Leonardo Ferreira", 26);

            var selectedModel = mockRepository.GetById(model.Id);

            Assert.NotNull(selectedModel);
            Assert.Equal("Leonardo Ferreira", model.Name);
        }

        [Fact]
        public async Task Should_Add_Entity_Async()
        {
            var model = CreateModel("Leonardo Ferreira", 26);
            var testeResult = await mockRepository.AddAsync(model);

            var addedModel = mockContext.Model.Where(x => x.Id == model.Id).FirstOrDefault();

            Assert.Equal(model, addedModel);
        }

        public FakeModel AddModel(string name, int age)
        {
            var model = CreateModel(name, age);

            mockRepository.Add(model);

            return model;
        }

        public FakeModel CreateModel(string name, int age)
        {
            FakeModel model = new FakeModel();
            model.Name = name;
            model.Age = age;

            return model;
        }
    }
}