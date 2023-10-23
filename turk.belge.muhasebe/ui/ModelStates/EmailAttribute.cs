using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ui.ModelStates
{
    public class EmailAttribute : Attribute, IModelValidator
    {
        bool isInValid = true;
        List<ModelValidationResult> result = new List<ModelValidationResult>();
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var value = context.Model.ToString();
            if (!value.Contains('@'))
            {
                result.Add(new ModelValidationResult("Email", "geçerli bir email adresi giriniz."));
                isInValid = true;
            }

            if (isInValid) return result;
            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}
