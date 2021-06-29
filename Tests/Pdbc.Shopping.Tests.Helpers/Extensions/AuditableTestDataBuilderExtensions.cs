using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdbc.Shopping.Common;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Tests.Helpers.Extensions
{
    public static class AuditableTestDataBuilderExtensions
    {
        public static void Set<TEntity>(this ObjectBuilder<TEntity> builder) where TEntity : AuditableIdentifiable
        {
            //TODO Complete this implementation to set all the audit fields generic
        }
    }
}
