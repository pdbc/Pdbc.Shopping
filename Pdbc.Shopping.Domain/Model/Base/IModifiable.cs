using System;

namespace Pdbc.Shopping.Domain.Model
{
    public interface IModifiable
    {
        string ModifiedBy { get; set; }

        DateTimeOffset ModifiedOn { get; set; }
    }
}