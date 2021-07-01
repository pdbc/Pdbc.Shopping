# I18N - Localization

A seperate project containing all localization and resource bundles has been setup.  This is a project most other projects have a depdency on.  The ease of setting up common messages/error codes is significant.  
Further can we easily expose correct error messages and other resources to the end-user through our API end-point.

## Refering to ErrorCodes

Mark the Resource file to be processed by the 'PublicResXFileCodeGenerator' instead of the 'ResXFileCodeGenerator' custom tool, which allows publically available resource codes.
It now becomes easy to use these messages and refactorings automatically take place during renames.

```csharp
RuleFor(i => i.Language)
    .NotEmpty()
    .WithErrorCode(nameof(ErrorResources.LanguageNotEmpty));
```

## Retrieving the Resources

By providing extensions methods on the ResourceManager class we can then retrieve all the resources in a specific language.  This allows us to disclose this information (for example by an endpoint for API reference) or by exporting them as json to include in front-end applications.

```csharp
public static IDictionary<string, string> GetResources(this ResourceManager resourceManager, string language = null)
{
    // Add Error Resources
    return resourceManager.CreateCaseInsensitiveSpecificResourceData(language);
}

private static IDictionary<string, string> CreateCaseInsensitiveSpecificResourceData(this ResourceManager resourceManager,
            string language)
{
    return resourceManager.CreateSpecificResourceData(language, StringComparer.OrdinalIgnoreCase);
}

private static IDictionary<string, string> CreateSpecificResourceData(this ResourceManager resourceManager,
    string language,
    StringComparer comparer = null)
{
    if (resourceManager == null)
        return new Dictionary<string, string>(comparer);

    var languageShort = language.ToCultureInfo();
    var resourceSet = resourceManager.GetResourceSet(languageShort, true, false);

    var data = new Dictionary<string, string>(comparer);
    if (resourceSet != null)
    {
        data = resourceSet
            .Cast<DictionaryEntry>()
            .ToDictionary(entry => entry.Key.ToString(), entry => entry.Value.ToString());
    }

    var parentResourceData = resourceManager.GetResourceSet(new CultureInfo(""), true, true)
        .Cast<DictionaryEntry>()
        .ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());

    foreach (var entry in parentResourceData)
    {
        if (data.ContainsKey(entry.Key))
            continue;

        data.Add(entry.Key, entry.Value);
    }

    return new Dictionary<string, string>(data, comparer);
}
```