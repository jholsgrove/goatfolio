using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Stocks.Client;

namespace GoatPortfolio.Models
{
    public class AssetDto
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EntryDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal EntryPrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ExitDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal ExitPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal ProfitLoss => (this.ExitPrice * this.Volume) - (this.EntryPrice * this.Volume);

        public decimal Value { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Symbol { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Volume { get; set; }

        public async Task Update(string apiKey)
        {
            using (var client = new AlphaVantageClient(apiKey))
            using (var stocksClient = client.Stocks())
            {
                var quote = await stocksClient.GetGlobalQuoteAsync(this.Symbol);
                this.ExitPrice = quote.Price;
            }
        }
    }
}