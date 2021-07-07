using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Data.Auditing
{
    public class AuditRecordCreationInfo
    {
        public AuditRecordCreationInfo()
        {
            PropertyChanges = new List<PropertyChangesDataInfo>();
        }

        public IRequireAuditing Entity { get; set; }

        public EntityActionEnum Action { get; set; }


        public List<PropertyChangesDataInfo> PropertyChanges { get; set; }
        
        public EntityEntry<IEntity> Entry { get; set; }
    }
}