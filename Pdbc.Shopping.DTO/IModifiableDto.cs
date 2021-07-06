using System;

namespace Pdbc.Shopping.DTO
{
    public interface IModifiableDto
    {
        string ModifiedBy { get; set; }

        DateTimeOffset ModifiedOn { get; set; }
    }
}