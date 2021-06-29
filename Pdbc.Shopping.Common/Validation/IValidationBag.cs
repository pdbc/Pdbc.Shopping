using System;
using System.Collections.Generic;

namespace Pdbc.Shopping.Common.Validation
{
    public interface IValidationBag
    {
        Boolean HasErrors();
        IList<ValidationMessage> ErrorMessages { get; }

        void AddError(String key, String message);
    }
}