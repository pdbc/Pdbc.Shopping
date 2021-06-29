using System;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Domain.Model
{
    public abstract class AuditableIdentifiable : Identifiable, ICreatable, IModifiable
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}