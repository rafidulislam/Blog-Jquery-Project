using System.ComponentModel.DataAnnotations;

namespace JQ_prj1.Models
{
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; } // Primary Key
        public string? Title { get; set; } // NVARCHAR(200)
        public string? Description { get; set; } // NVARCHAR(MAX)
        public int TotalView { get; set; } // INT
        public string? VideoPath { get; set; } // NVARCHAR(100)
        public DateTime CreatedDate { get; set; } // DATETIME
        public  int IsActive { get; set; } // BIT
    }
    public class  ResponceModel
    {
        public int ResponceCode { get; set; }
        public string ResponceMsz { get; set; }
        public bool IsSuccess { get; set; }
    }
}
