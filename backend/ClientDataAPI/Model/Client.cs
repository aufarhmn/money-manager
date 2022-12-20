namespace ClientDataAPI.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string? clientName { get; set; }
        public string? clientPass { get; set; }
        public double clientBalance { get; set; }
        public double clientExpense { get; set; }
    }
}
