# I18N - Localization

A seperate project containing all localization and resource bundles has been setup.  This is a project most other projects have a depdency on.  The ease of setting up common messages/error codes is significant.  Further can we easily expose correct error messages and other resources to the end-user through our API end-point.

## Refering to ErrorCodes

It now becomes easy to use these messages

```csharp
RuleFor(i => i.Language)
    .NotEmpty()
    .WithErrorCode(nameof(ErrorResources.LanguageNotEmpty));
```

