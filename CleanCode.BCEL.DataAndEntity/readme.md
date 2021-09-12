# Generic repository and paged list data extension

## install
- Dotnet Cli
```bash
dotnet add package CleanCode.BCEL.DataAndEntity --version 1.1.0
```

- Package Reference
```bash
<PackageReference Include="CleanCode.BCEL.DataAndEntity" Version="1.1.0" />
```

## usage
1. create a DbContext

```cs
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> opt) : base(opt)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
```
2. create a repository extends by GenericRepository

```cs
  public class StudentRepository : GenericRepository<Student>
  {
      public StudentRepository(SchoolContext dbContext) : base(dbContext)
      {
      }
  }
```
3. register both dbContext and repositoy in Startup.cs file
4. use the repository like this:
```cs
    public async Task OnGetAsync()
    {
        Student = await _repo.Where(false)
            .ToPagedDataAsync(1, 2)
            .ContinueWith(x => x.Result.ToViewModel());
    }

```