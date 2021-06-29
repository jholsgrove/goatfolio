using System;
using System.ComponentModel.DataAnnotations;
namespace GoatPortfolio.Models
{
    public class Asset
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
        public decimal? ExitPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ProfitLoss { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Symbol { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Volume { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string User { get; set; }

        public AssetDto ToDto() => new AssetDto
        {
            Id = this.Id,
            EntryDate = this.EntryDate,
            EntryPrice = this.EntryPrice,
            ExitDate = this.ExitDate,
            ExitPrice = this.ExitPrice ?? 0,
            Symbol = this.Symbol,
            Volume = this.Volume

        };
    }
}