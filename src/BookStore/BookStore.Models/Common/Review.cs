using BookStore.Models.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models.Common
{
    [Table("Reviews", Schema = "common")]
    public class Review : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "The {0} must less than {1} characters")]
        public string Content { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Book")]
        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
