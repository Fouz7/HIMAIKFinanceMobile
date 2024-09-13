namespace HimaikFinanceMobile.Models;

public class IncomeData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Nominal { get; set; }
    public DateTime TransferDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}