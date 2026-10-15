using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team_Project_1.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please include a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please include a last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please include a phone number.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please include an email.")]
        public string Email { get; set; } = string.Empty;

        public string? Organization { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category.")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;

        public DateTime DateAdded { get; set; }

        [NotMapped]
        public string Slug => $"{FirstName}-{LastName}".ToLowerInvariant().Replace(" ", "-");
    }
}
