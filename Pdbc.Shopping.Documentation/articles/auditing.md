# Auditing

Lots of application require the notion of auditing.  Who created that object, who modified it.  Can we view a history of the changes to track-down an issue.  
Auditing can come in many forms of course.  The easiest is to track it down on your entities.  You can achieve this by implementing the following interfaces, this adds the necessary columns in you data model.

## Auditing - the easy way

```csharp
public interface ICreatable
{
    string CreatedBy { get; set; }
    DateTimeOffset CreatedOn { get; set; }
}

public interface IModifiable
{
    string ModifiedBy { get; set; }

    DateTimeOffset ModifiedOn { get; set; }
}
```

Filling up these values then lies in the way you persist changes to your entities.  In my case i'm using [Entity Framework Core](../data-entity-framework.md) to persist my changes, so the DbContext can help you here.  Override the SaveChanges and apply the auditing requirements here.  You can use the internal Entity Framework's ChangeTracker here to setup or change these values.

```csharp
public override int SaveChanges()
{
    ...
    HandleCreatableEntities();
    HandleModifiableEntities();

    return base.SaveChanges();
    ...
}

protected virtual void HandleCreatableEntities()
{
    foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
    {
        var creatable = entry.Entity as ICreatable;
        if (creatable != null)
        {
            creatable.CreatedBy = GetExecutingUserName();
            creatable.CreatedOn = DateTime.Now;

            var modifiable = entry.Entity as IModifiable;
            if (modifiable != null)
            {
                modifiable.ModifiedBy = creatable.CreatedBy;
                modifiable.ModifiedOn = creatable.CreatedOn;
            }
        }

        FillAuditRecordDescription(entry);
    }
}

protected virtual void HandleModifiableEntities()
{
    foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
    {
        var modifiable = entry.Entity as IModifiable;
        if (modifiable != null)
        {
            // Store ModifiedOn date for Optimistic Locking
            entry.Property("ModifiedOn").OriginalValue = modifiable.ModifiedOn;

            // Save values for Modification.
            modifiable.ModifiedBy = GetExecutingUserName();
            modifiable.ModifiedOn = DateTime.Now;
        }

        var creatable = entry.Entity as ICreatable;
        if (creatable != null)
        {
            // must be set for required validation, but will not be saved
            entry.Property(nameof(creatable.CreatedBy)).OriginalValue = "AsCreated";
            entry.Property(nameof(creatable.CreatedBy)).IsModified = false;
            entry.Property(nameof(creatable.CreatedOn)).IsModified = false;
        }

        FillAuditRecordDescription(entry);
    }
}
```

## Auditing - the complete way

The 'easy' way just tells you who created the object, when it was created and who modified it at what timestamp.  However, it does not tell what changes were made.
Including what were the actual changes can as well be achieved by adding a layer above the entity framework.  Entity framework needs to be aware that auditing is required.  This can be done by implementing this interface.

```csharp
public interface IRequireAuditing
{
    ....
}
```

During the SaveChanges phase we now can check this interface to store the changes that have been done, after the effective SaveChanges we can then save the audit records.  We do this after the SaveChanges action to have the Id available if it is database generated.

```csharp
public override int SaveChanges()
{
    .... 
    // CreatedBy/ModifiedBy
    HandleCreatableEntities();
    HandleModifiableEntities();

    // AuditRecords (lifecycle)
    auditRecords = GetAuditRecordsToCreate();

    var result = base.SaveChanges();

    SaveAuditRecords(auditRecords);

    return result;
}
```


```csharp
public override int SaveChanges()
{

}
```

