using System;

namespace Pdbc.Shopping.Domain.Model
{
    public interface ICreatable
    {
        string CreatedBy { get; set; }
        DateTimeOffset CreatedOn { get; set; }
    }
}