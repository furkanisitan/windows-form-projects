using FluentValidation;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Any())
                throw new ValidationException(result.Errors);
        }
    }
}
