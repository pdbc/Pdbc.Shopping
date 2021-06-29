using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Domain.Model;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Domain
{
    [TestFixture]
    public class ArticlesTestFixture : BaseSpecification
    {
        [Test]
        public void Verify_equals_return_false_with_two_different_objects()
        {
            var item1 = new ArticleTestDataBuilder()
                .Build();
            var item2 = new ArticleTestDataBuilder()
                .Build();

            item1.Equals(item2).ShouldBeFalse();
        }

        [Test]
        public void Verify_equals_return_true_when_name_matches()
        {
            var item1 = new ArticleTestDataBuilder()
                .Build();
            var item2 = new ArticleTestDataBuilder()
                .WithName(item1.Name)
                .Build();

            item1.Equals(item2).ShouldBeTrue();
        }

        [Test]
        public void Verify_equals_return_false_name_matches_but_not_casing()
        {
            var item1 = new ArticleTestDataBuilder()
                .WithName("abc")
                .Build();
            var item2 = new ArticleTestDataBuilder()
                .WithName("ABC")
                .Build();

            item1.Equals(item2).ShouldBeFalse();
        }
    }
}
