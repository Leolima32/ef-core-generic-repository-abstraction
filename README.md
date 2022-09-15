# Generic Repository Package For Entity Framework Core

> Application meant to be used as a nuget package to abstract simple CRUD operations

## 💻 Requirements

Before we begin, check that you have met the following requirements:
* You have installed the latest version of `.NET`.
* You have a running local instance of `SQL SERVER`.


## 🚀 Getting Started

Install the package on your app using the command below

```
Install-Package LF.GenericRepository.EntityFrameworkCore
```

## ☕ Using in your project

In order to configure in your project follow this steps

Create your model objects and make them herd from BaseModel class
```
  public class Product : BaseModel
  {
      public string Name { get; set; }
      public double Price { get; set; }
  }
```
Create an context class
```
  public class Context : GenericDbContext
  {
      public Context(DbContextOptions options)
      : base(options) 
      {
      }
      public DbSet<Product> Products { get; set; }
  }
```
Create your repository
```
  public class ProductRepository : GenericRepository<Product>
  {
      private Context _db;
      public ProductRepository(Context db) : base(db)
      {
          _db = db;
      }
  }
```

Add your database configuration in Program.cs 
```
  builder.Services.AddGenericRepositorySqlServer<Context>("YOUR_CONNECTION_STRING");
```

Thats it! Your repository should have all the functions needed for all basic CRUD operations.
