using CryptoPortfolio.Core.Attributes;
using CryptoPortfolio.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CryptoPortfolio.Core.Models.DTO
{
    public class BittrexTradeDto : ITradeDto
    {
        [Column(1)]
        [Required]
        public String OrderUuid { get; set; }

        [Column(2)]
        [Required]
        public string Exchange { get; set; }

        [Column(3)]
        [Required]
        public string Type { get; set; }

        [Column(4)]
        [Required]
        public decimal Quantity { get; set; }

        [Column(5)]
        [Required]
        public decimal Limit { get; set; }

        [Column(6)]
        [Required]
        public decimal Commission { get; set; }

        [Column(7)]
        [Required]
        public decimal Price { get; set; }

        [Column(8)]
        [Required]
        public DateTime Opened { get; set; }

        [Column(8)]
        [Required]
        public DateTime Closed { get; set; }
    }
}
