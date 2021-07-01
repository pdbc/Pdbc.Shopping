using System;
using System.Linq;
using System.Text;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.Tests.Helpers.Core.Validation
{
    public static class ValidationBagExtensions
    {
        public static void ExpectNoErrors(this ValidationBag entity)
        {
            entity.HasErrors().ShouldBeFalse();
        }

        public static ValidationBag ExpectAnError(this ValidationBag entity)
        {
            entity.HasErrors().ShouldBeTrue("At least on error was expected in the ValidationBag");
            return entity;
        }

        public static ValidationBag ExpectNumberOfErrors(this ValidationBag entity, int count)
        {
            entity.ErrorMessages.Count.ShouldBeEqualTo(count);
            return entity;
        }

        public static ValidationBag ExpectErrorWithCode(this ValidationBag entity, String code)
        {
            entity.ErrorMessages.FirstOrDefault(x => x.Key == code).ShouldNotBeNull();
            return entity;
        }

        public static ValidationBag ExpectNoErrorWithCode(this ValidationBag entity, String code)
        {
            entity.ErrorMessages.FirstOrDefault(x => x.Key == code).ShouldBeNull();
            return entity;
        }



        //public static String GetAllErrorMessages(this ValidationBag v)
        //{
        //    // If no errors, empty result
        //    if (!v.HasErrors())
        //    {
        //        return String.Empty;
        //    }

        //    var first = true;
        //    var sb = new StringBuilder();
        //    foreach (var m in v.ErrorMessages)
        //    {
        //        if (!first)
        //        {
        //            sb.Append(", ");
        //        }

        //        sb.Append(m.Key);
        //        first = false;
        //    }

        //    return sb.ToString();
        //}
    }
}