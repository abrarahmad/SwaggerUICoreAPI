using System.ComponentModel.DataAnnotations;

namespace SwaggerUI.API.Models
{
    /// <summary>
    /// Customer with Id, FirstName, LastName, City and Phone fields
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// The id of customer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This first name of customer
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }


        /// <summary>
        /// This last name of customer
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }


        /// <summary>
        /// This city of customer
        /// </summary>

        [MaxLength(40)]
        public string City { get; set; }

        /// <summary>
        /// This country of customer
        /// </summary>
        [MaxLength(40)]
        public string Country { get; set; }


        /// <summary>
        /// This phone of customer
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }
    }
}
