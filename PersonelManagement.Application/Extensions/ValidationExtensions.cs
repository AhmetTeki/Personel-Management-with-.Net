using FluentValidation.Results;
using PersonelManagement.Application.Dtos;

namespace PersonelManagement.Application.Extensions
{
   public static class ValidationExtensions
    {
        public static List<ValidationError> ToMap(this List<ValidationFailure> errors)
        {
            List<ValidationError> errorList = new List<ValidationError>();
            
            foreach (ValidationFailure error in errors)
            {
                errorList.Add(new ValidationError
                (
                    error.PropertyName,
                    error.ErrorMessage

                ));
            }
            return errorList;
        }
    }
}
