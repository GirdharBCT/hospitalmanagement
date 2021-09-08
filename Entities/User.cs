using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospitalmanagement.Entities
{
    public class User : BaseEntity{
        public int Id { get; set; }
        [MaxLength(50)]
        public string firstName { get; set; }
        [MaxLength(50)]
        public string lastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isDeleted { get; set; }
        [ForeignKey("FK_Hospital")]
        public int hospitalId { get; set; }
    }

    public class BaseEntity{ 
        public DateTime createdOn { get; set; }
        public DateTime modifiedOn { get; set; }    
    }
}