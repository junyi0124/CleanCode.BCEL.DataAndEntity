using CleanCode.BCEL.DataAndEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class Student: EntityBase<int>, IAggregateRoot
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Bio { get; set; }

    }
}
