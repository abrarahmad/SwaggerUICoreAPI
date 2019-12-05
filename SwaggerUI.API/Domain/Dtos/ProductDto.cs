namespace Domain.Dtos
{
    public class ProductDto
    {

        public int Id { get; set; }

        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
    }
}
