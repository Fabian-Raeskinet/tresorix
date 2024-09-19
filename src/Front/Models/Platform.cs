namespace Front.Models;

public class Platform
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double TotalWallet { get; set; }
    public double TotalProfit { get; set; }
    public double TotalInvestment { get; set; }
    public double PercentageProfit { get; set; }
    public List<Asset>? Assets { get; set; }
    public List<Transaction>? Transactions { get; set; }
}