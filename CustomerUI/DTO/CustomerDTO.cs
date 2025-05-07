using System.ComponentModel.DataAnnotations;

namespace CustomerUI.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(9)]
        public string PhoneNumber { get; set; }
    }
}
