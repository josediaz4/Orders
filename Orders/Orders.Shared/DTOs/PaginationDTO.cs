namespace Orders.Shared.DTOs
{
    public class PaginationDTO
    {
        public int Id { get; set; }
        public int Pages { get; set; } = 1;
        public int RecordsNumber { get; set; } = 10;
    }
}
