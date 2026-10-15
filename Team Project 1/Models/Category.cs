using System.ComponentModel.DataAnnotations;

namespace Team_Project_1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
