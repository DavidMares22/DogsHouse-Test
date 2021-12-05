using DogApi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Utilities
{
    public class NameDogUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var text = value?.ToString()?? String.Empty;
            var _context = (ApiDbContext)validationContext.GetService(typeof(ApiDbContext));
            var entity = _context.Dogs.SingleOrDefault(e => e.Name == text);

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string name)
        {
            return $"Name {name} is already in use.";
        }
    }
}
