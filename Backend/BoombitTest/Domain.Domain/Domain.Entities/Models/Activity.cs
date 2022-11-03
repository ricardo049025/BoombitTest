using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    /// <summary>
    /// Class Activity that make references
    /// to the table Activity in the database
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Primary key of the table
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        /// <summary>
        /// Created day of the activity
        /// </summary>
        [Required]
        public DateTime CreatedDay { set; get; } = DateTime.Now.Date;

        [Required]
        [StringLength(40)]
        public string ActivityDescription { set; get; }

        [ForeignKey("UserId")]
        [Required]
        public int UserId { set; get; }
        public virtual User User { set; get; }
    }
}

