using System.ComponentModel.DataAnnotations;

namespace PersonalInformationFormApp.Models
{

    public class Person : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public bool IsCurrentlyWorking { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsAcknowledged { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsCurrentlyWorking && string.IsNullOrEmpty(CompanyName))
            {
                yield return new ValidationResult(
                    "Company Name is required if currently working.",
                    new[] { nameof(CompanyName) });
            }
        }
    }
}
