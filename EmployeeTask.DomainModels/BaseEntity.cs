using System; 
using System.ComponentModel.DataAnnotations; 

namespace EmployeeTask.DomainModels
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
