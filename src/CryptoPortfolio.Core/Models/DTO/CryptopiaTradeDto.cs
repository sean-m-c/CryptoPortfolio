using CryptoPortfolio.Core.Attributes;
using CryptoPortfolio.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Core.Models.DTO
{
    public class CryptopiaTradeDto : ITradeDto
    {
        [Column(1)]
        [Required]
        public int Id { get; set; }

        [Column(2)]
        [Required]
        public string Market { get; set; }

        [Column(3)]
        [Required]
        public string Type { get; set; }

        [Column(4)]
        [Required]
        public decimal Rate { get; set; }

        [Column(5)]
        [Required]
        public decimal Amount { get; set; }

        [Column(6)]
        [Required]
        public decimal Total { get; set; }

        [Column(7)]
        [Required]
        public decimal Fee { get; set; }

        [Column(8)]
        [Required]
        public DateTime Timestamp { get; set; }
    }
}
