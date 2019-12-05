namespace Domain.Dtos
{
    /// <summary>
    /// Customer with Id, FirstName, LastName, City and Phone fields
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// The id of customer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This first name of customer
        /// </summary>
        public string FirstName { get; set; }


        /// <summary>
        /// This last name of customer
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        /// This city of customer
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// This city of customer
        /// </summary>
        public string Country { get; set; }


        /// <summary>
        /// This phone of customer
        /// </summary>
        public string Phone { get; set; }
    }
}
