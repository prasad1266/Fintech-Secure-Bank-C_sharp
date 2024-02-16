using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Fintech_Hub.Models
{

   
    public class BankAccountTransaction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public decimal? Amount { get; set; }

        public string? Narration { get; set; }

        [Required(ErrorMessage = "TransactionId is required.")]
        public string? TransactionId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? TransactionTime { get; set; }


        [Required(ErrorMessage = "Type is required.")]
        public string? Type { get; set; }


        public int? DestinationBankAccountId { get; set; }
    }
}
