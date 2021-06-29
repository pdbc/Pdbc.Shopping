using System;

namespace Pdbc.Shopping.Common.Validation
{
    public class ValidationMessage
    {
        public String Key { get; set; }
        public Exception Exception { get; set; }
        public String Message { get; set; }
    }
}
