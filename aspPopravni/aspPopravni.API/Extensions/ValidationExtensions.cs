using aspPopravni.API.DTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace aspPopravni.API.Extensions
{
    public static class ValidationExtensions
    {
        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
        {
            var errors = result.Errors.Select(x => new ValidationError
            {
                Error = x.ErrorMessage,
                Property = x.PropertyName
            });

            return new UnprocessableEntityObjectResult(errors);
        }
    }
}
