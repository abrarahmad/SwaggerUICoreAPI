using System.ComponentModel.DataAnnotations;

namespace SwaggerUI.API.Models
{
    /// <summary>
    /// Supplier with Id, CompanyName, ContactName, ContactTitle,Country,City and Phone,Fax fields
    /// </summary>
    public class SupplierModel
    {
        /// <summary>
        /// The id of supplier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This first name of supplier
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }


        /// <summary>
        /// This last name of supplier
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ContactName { get; set; }

        /// <summary>
        /// This last name of supplier
        /// </summary>
        [MaxLength(40)]
        public string ContactTitle { get; set; }

        /// <summary>
        /// This city of supplier
        /// </summary>

        [MaxLength(40)]
        public string City { get; set; }

        /// <summary>
        /// This country of supplier
        /// </summary>
        [MaxLength(40)]
        public string Country { get; set; }


        /// <summary>
        /// This phone of supplier
        /// </summary>
        [MaxLength(40)]
        public string Phone { get; set; }

        /// <summary>
        /// This fax of supplier
        /// </summary>
        [MaxLength(30)]
        public string Fax { get; set; }


    }
}
