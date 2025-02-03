using System.ComponentModel.DataAnnotations;

namespace JQ_prj1.Models
{
    public class BlogCommentModel
    {
        [Key]
        public int BlogCommentId { get; set; } // Primary Key
        public int BlogId { get; set; } // Foreign Key to Blog
        public int UserId { get; set; } // Foreign Key to User
        public string CommentDescription { get; set; } // NVARCHAR(MAX)
        public int Status { get; set; } // INT
        public DateTime CreatedDate { get; set; } // DATETIME
        public int IsActive { get; set; } // BIT

        // Navigation properties
       // public BlogModel Blog { get; set; }
        //public UserModel User { get; set; }
    }
}
