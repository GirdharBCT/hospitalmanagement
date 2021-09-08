using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hospitalmanagement.Entities
{
    public class Hospital{
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string addressLine1 { get; set; }
        [Required]
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        [Required]
        [MaxLength(10)]
        public string zipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        public List<User> Users { get; set; }
    }
}