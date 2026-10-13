using System.ComponentModel.DataAnnotations;

namespace Team_Project_1.Models
{
    public class EditModel
    {
        [Required(ErrorMessage = "Please include a first name.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please include a last name.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please include a phone number.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Please include an email.")]
        public string? Email { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category.")]
        public int CategoryID { get; set; }

        public string? Organization { get; set; }

        public Contact UpdateContact()
        {
            return new Contact
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Email = Email,
                CategoryID = CategoryID,
                Organization = Organization,
                DateAdded = DateTime.Now
            };
        }
    }
}
