using FluentValidation;
using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.HelperValidators
{
    static class Extensions
    {
        public static IRuleBuilderOptions<TItem, TProperty> IsUnique<TItem, TProperty>(
            this IRuleBuilder<TItem, TProperty> ruleBuilder, IEnumerable<TItem> items, string idPropertyName)
            where TItem : class
        {
            return ruleBuilder.SetValidator(new UniqueValidator<TItem>(items, idPropertyName));
        }
    }
}
