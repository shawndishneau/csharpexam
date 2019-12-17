using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }


        [Required(ErrorMessage="Please insert a first name")]
        [MinLength(3, ErrorMessage="Minimum length for a first name is 3 characters")]
        [RegularExpression(@"^[ a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Please insert a last name")]
        [MinLength(3, ErrorMessage="Minimum length for a last name is 3 characters")]
        [RegularExpression(@"^[ a-zA-Z]+$")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Please insert an alias")]
        [MinLength(3, ErrorMessage="Minimum length for an alias is 3 characters")]
        public string Alias { get; set; }

        [Required(ErrorMessage="Please insert an Email address")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,20}$", ErrorMessage = "Password must contain at least 1 number, 1 letter, 1 special character, and be at least 8 characters long")]    
        [Required(ErrorMessage="Please insert a password")]
        [MinLengthAttribute(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password { get; set; }

        [Required(ErrorMessage="Please confirm your password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        // **********************************************************************************************
        public List<Association> LikedIdeas { get; set; }
        public List<Idea> IdeasCreated { get; set; }
        // *************************************************************************************************

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }


    // This is a wrapper model
    public class LoginUser
    {
        [Required(ErrorMessage="Please provide a registered Email address")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage="Please provide a correct password")]
        public string LoginPassword { get; set; }
    }
}