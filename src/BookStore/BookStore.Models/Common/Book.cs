using BookStore.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models.Common
{
    [Table("Books", Schema = "common")]
    public class Book : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "The {0} must less than {1} characters")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        
        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
