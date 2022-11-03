using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    /// <summary>
    /// Class Country, it make references to the
    /// table country in the database
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Primary key of the country
        /// code regarding the ISO 3166-1
        /// </summary>
        [Key]
        public int? Id { set; get; }
        /// <summary>
        /// Name of the country
        /// </summary>
        [Required]
        [StringLength(120)]
        public string Name { set; get; }
        /// <summary>
        /// to Know if a country is active
        /// 1: active and 0: inactive
        /// </summary>
        [Required]
        public bool Active { set; get; }

        /// <summary>
        /// code of the country
        /// </summary>
        [Required]
        public string Code { set; get; }
        /// <summary>
        /// all the users that
        /// has the country
        /// </summary>
        public virtual List<User>? users { set; get; }
    }
}

