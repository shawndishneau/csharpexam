using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam2.Models
{
    public class Idea
    {
        [Key]
        public int IdeaId { get; set; }

        [Required(ErrorMessage="You must leave a description")]
        [MinLength(5, ErrorMessage="A description must have a minimum 5 letters")]
        public string IdeaDescription { get; set; }

        // [Required(ErrorMessage="asdfasdfadsf")]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        // *************************************************************************************************
        public List<Association> PeopleLikingIdeas { get; set; }
        // *************************************************************************************************
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public class FutureDateAttribute : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
        // You first may want to unbox "value" here and cast to a DateTime variable!
            if ((DateTime) value < DateTime.Now) 
            {
                return new ValidationResult ("The date entered is not a future date.");
            }
            return ValidationResult.Success;
        }
    }
}