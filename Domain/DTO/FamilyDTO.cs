
using Domain.Enums;

namespace Domain.DTO
{
    public class FamilyDTO 
    {
        public Guid Id { get; set; }
        public decimal Income { get; set; }
        public int Score { get; set; }
        public Status Status { get; set; }
    }
}
