using System;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Tests.Helpers.Domain.Model
{
    public class AddressTestDataBuilder : AddressBuilder
    {
        public AddressTestDataBuilder()
        {
            this.Street = UnitTestValueGenerator.GenerateText(128);
            this.Number = UnitTestValueGenerator.GenerateText(2, UnitTestValueGenerator.Numeric);
            this.City = UnitTestValueGenerator.GenerateText(16);

            // Auditable 
            this.CreatedBy = UnitTestValueGenerator.GenerateText(16);
            this.ModifiedBy = UnitTestValueGenerator.GenerateText(16);
            this.CreatedOn = DateTime.Now.AddDays(-5);
            this.ModifiedOn = DateTime.Now.AddDays(-2);
        }
    }
}