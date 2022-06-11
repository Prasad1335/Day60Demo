using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Day60Demo.Models.Services.Validators
{
    public class PreventBadWords : ValidationAttribute
    {
        private readonly string[] _bannedKeywords = new[] { "mno", "abc", "xyz" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
                return ValidationResult.Success;
            
            var text = value as string;

            foreach (var bannedKeyword in _bannedKeywords)
            {
                if (text.Contains(bannedKeyword))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
