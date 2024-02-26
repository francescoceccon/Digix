using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Family : BaseEntity
    {
        public Person Holder { get; set; }
        public Person CoHolder { get; set; }
        public List<Person> Children { get; set; }
        [JsonIgnore]
        public bool AlreadyScored { get; set; }

        public decimal Income { get { return Holder.Salary += CoHolder.Salary; } private set { } }

        public int Score { get; set; }
    }
}
