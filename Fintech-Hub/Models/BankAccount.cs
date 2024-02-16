using System.ComponentModel.DataAnnotations;

namespace Fintech_Hub.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a non-negative value.")]
        public decimal? Balance { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "IFSC Code should be 11 characters.")]
        public string? IfscCode { get; set; }

        [Required(ErrorMessage = "Account number is required.")]
        public string? Number { get; set; }

        public string? Status { get; set; }

        public string? Type { get; set; }
    }
}
