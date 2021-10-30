using CleanCode.BCEL.BaseEntity;

namespace TestWebApplication.Models
{
    public class Student : EntityBase<int>, IAggregateRoot
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Bio { get; set; }

    }
}
