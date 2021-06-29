using System;
using System.Collections.Generic;

namespace Pdbc.Shopping.Common.Validation
{
    public class ValidationBag : IValidationBag
    {
        public ValidationBag()
        {
            ErrorMessages = new List<ValidationMessage>();
        }
        public bool HasErrors()
        {
            return ErrorMessages.Count > 0;
        }

        public IList<ValidationMessage> ErrorMessages { get; set; }

        public void AddError(String key, String message)
        {
            AddError(new ValidationMessage() { Key = key, Message = message });

        }
        public void AddError(ValidationMessage validationMessage)
        {
            ErrorMessages.Add(validationMessage);

        }
    }
}