using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    /// <summary>
    /// Class user, it make references to the
    /// table User in the database
    /// </summary>
    public class User
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        /// <summary>
        /// Name of the user
        /// </summary>
        [Required]
        [StringLength(60)]
        public string Name { set; get; }
        [Required]
        [StringLength(60)]
        public string LastName { set; get; }
        /// <summary>
        /// Email of the user
        /// </summary>
        [Required]
        [StringLength(80)]
        public string Email { set; get; }
        /// <summary>
        /// Birthday of the user
        /// </summary>
        [Required]
        public DateTime Birthday { set; get; }
        /// <summary>
        /// phonenumber
        /// </summary>
        public Int64? PhoneNumber { set; get; }
        /// <summary>
        /// Need more information
        /// 1: Yes, 0: false 
        /// </summary>
        [Required]
        public bool NeedInformation { set; get; }
        /// <summary>
        /// Foreign key that make references
        /// to the country
        /// </summary>
        
        [Required]
        [ForeignKey("CountryId")]
        public int CountryId { set; get; }
        public virtual Country Country { set; get; }

        /// <summary>
        /// User's activities
        /// </summary>
        public virtual List<Activity> Activities { set; get; }
    }
}

