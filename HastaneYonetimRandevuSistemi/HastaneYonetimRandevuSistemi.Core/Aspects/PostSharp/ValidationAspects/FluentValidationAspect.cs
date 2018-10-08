using FluentValidation;
using HastaneYonetimRandevuSistemi.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PostSharp.Aspects;
using System;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.Core.Aspects.PostSharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private readonly Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        // Bu aspectin uygulandığı metod gövdelerinden önce çalışır.
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var entities = args.Arguments.Where(x => x.GetType() == entityType);

            foreach (var entity in entities)
                ValidatorTool.FluentValidate(validator, entity);
        }
    }
}
