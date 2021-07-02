using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NUnit.Framework;
using Pdbc.Shopping.Tests.Helpers;

namespace Pdbc.Shopping.UnitTests.Core.Mapping
{
    public class RequestMappingsTestFixture : BaseSpecification
    {
        [Test]
        public void Test_RequestToCqrsMappings_is_valid()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<RequestToCqrsMappings>();
            });

            configuration.AssertConfigurationIsValid();
        }
    }
}
