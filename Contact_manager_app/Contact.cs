using System.ComponentModel.DataAnnotations;

namespace Contact_manager_app;

public class Contact
{
    [Required(ErrorMessage = "First name must be filled!")]
    [StringLength(20, ErrorMessage = "Length of the first name must be less than 20")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name must be filled!")]
    [StringLength(20, ErrorMessage = "Length of the last name must be less than 20")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "First name must be filled!")]
    [Phone(ErrorMessage = "Wrong phone format!")]
    public string PhoneNumber { get; set; }
    
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string EmailAddress { get; set; }
    
    public string HomeAddress { get; set; }
    public string OptionalNote { get; set; }
}