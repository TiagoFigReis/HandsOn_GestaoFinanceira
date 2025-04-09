using Application.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Application.Validators
{
    public class InputModelValidator
    {
        public static string[]? GetErrors<T>(T inputModel)
        {
            string[]? errors = null;

            if (inputModel is null)
                throw new BadRequestException("Input model is null!", ["Input model is null!"]);

            var context = new ValidationContext(inputModel, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            errors = results.Select(r => r.ErrorMessage).ToArray()!;

            var isValid = Validator.TryValidateObject(inputModel, context, results, true);
            if (!isValid)
            {
                errors = results.Select(r => r.ErrorMessage).ToArray()!;
            }

            return errors;
        }

        public static void Validate<T>(T inputModel)
        {
            var errors = GetErrors(inputModel);

            if (errors?.Length > 0)
                throw new BadRequestException("Input model is invalid!", errors);
        }
    }
}