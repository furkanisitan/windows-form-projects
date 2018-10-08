using FluentValidation.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.HelperValidators
{
    class UniqueValidator<T> : PropertyValidator
        where T : class
    {
        private readonly IEnumerable<T> _items;
        private readonly string _idPropertyName;

        public UniqueValidator(IEnumerable<T> items, string idPropertyName)
            : base("{PropertyName} daha önce kullanımış!")
        {
            _items = items;
            _idPropertyName = idPropertyName;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var idProperty = typeof(T).GetTypeInfo().GetProperty(_idPropertyName, BindingFlags.Public | BindingFlags.Instance);

            var editedItem = context.Instance as T;
            var editedItemId = idProperty?.GetValue(editedItem).ToString();

            var newValue = context.PropertyValue as string;
            var property = typeof(T).GetTypeInfo().GetProperty(context.PropertyName, BindingFlags.Public | BindingFlags.Instance);

            return _items.All(item =>
                string.Equals(editedItemId, idProperty?.GetValue(item).ToString()) ||
                !string.Equals(property?.GetValue(item).ToString(), newValue));
        }
    }
}
