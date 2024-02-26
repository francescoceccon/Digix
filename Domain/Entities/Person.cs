using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
