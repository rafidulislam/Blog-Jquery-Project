using System.ComponentModel.DataAnnotations;

namespace JQ_prj1.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; } // Primary Key
        public string Name { get; set; } // NVARCHAR(100)
        public string MobileNumber { get; set; } // VARCHAR(15)
        public string EmailAddress { get; set; } // VARCHAR(50)
        public DateTime CreatedDate { get; set; } // DATETIME
        public int IsActive { get; set; } // BIT
    }
}
