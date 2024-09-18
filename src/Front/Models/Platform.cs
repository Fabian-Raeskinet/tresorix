namespace Front.Models;

public class Platform
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public double TotalWallet { get; set; }
    public double TotalProfit { get; set; }
    public double TotalInvestment { get; set; }
    public double PercentageProfit { get; set; }
    public required List<Asset> Assets { get; set; }
    public required List<Transaction> Transactions { get; set; }
}