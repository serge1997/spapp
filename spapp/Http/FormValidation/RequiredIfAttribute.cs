using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;
namespace spapp.Http.FormValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class RequiredIfAttribute : ValidationAttribute
    {

        public readonly string _propertyToCheck;

        public string PropertyToCheck => _propertyToCheck;

        public RequiredIfAttribute(string propritetyCheck)
        {
            this._propertyToCheck = propritetyCheck;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(this._propertyToCheck);

            if (property == null)
            {
                throw new ArgumentException($"{_propertyToCheck} not found");
            }

            var propertyValue = (bool)property.GetValue(validationContext.ObjectInstance)!;

            if (propertyValue == false && string.IsNullOrEmpty(value as string))
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} é obrigatório.");
            }
            return ValidationResult.Success!;
        }
    }
}
