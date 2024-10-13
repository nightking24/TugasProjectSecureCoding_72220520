using System;
using System.ComponentModel.DataAnnotations;

namespace SampleSecureCoding.ViewModels;

public class RegistrationViewModel
{
    [Required]
    public string? Username { get; set;}

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(12, ErrorMessage = "The password must be at least 12 characters long.")]
     [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d!@#$%^&*(),.?""{}|<>]{12,}$", 
            ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, and one number.")]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "The Password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }
}
