using System;

namespace Pdbc.Shopping.DTO
{
    public interface ICreatableDto
    {
        string CreatedBy { get; set; }
        DateTimeOffset CreatedOn { get; set; }
    }
}