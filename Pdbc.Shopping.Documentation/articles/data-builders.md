# Data-Builders

The builder pattern simplifies the creation of objects.  It provides a fluent interface for ease and readability.
Each builder adheres to the following interface.

```csharp
public interface IObjectBuilder<out T> where T : class
{
    /// <summary>
    /// Builds an object of type T
    /// </summary>
    /// <returns></returns>
    T Build();
}
```
 
An abstract implementation then provides an implicit conversion method which provides the ability to use pass in builder classes in methods where the concrete class is expected.


```csharp
public abstract class ObjectBuilder<T> : IObjectBuilder<T> where T : class
{
    /// <summary>
    /// Performs an implicit conversion from <see cref="ObjectBuilder{T}"/> to the Typed object
    /// </summary>
    /// <param name="builder">The test data builder.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator T(ObjectBuilder<T> builder)
    {
        return builder?.Build();
    }

    /// <summary>
    /// Builds this instance.
    /// </summary>
    /// <returns></returns>
    public abstract T Build();
}
```

Ultimately the concrete implementation provides and holds the variables used in the domain class and implements the build method to construct the object.  To avoid mismatches (when renames/refactorings are done) and writing this error-prone code manually.  [T4 templates](t4-templates.md) are a big help.


```csharp
public partial class ArticleBuilder : ObjectBuilder<Pdbc.Shopping.Domain.Model.Article>
{
    protected System.String Name { get; set; }		
    public ArticleBuilder WithName(System.String name)
    {
        this.Name = name;
	    return this;
    }	

    public override Article Build()
    {
        var item = (Article)Activator.CreateInstance(typeof(Article));    	
	    item.Name = Name;	    
        return item;
    }
       
}
```

Now we have a generated builder that follows any changes (adding/removing properties) you make in the domain class the next step is to setup a fully populated builder that is usuable in our tests.
This allows us to add properties on our domain model object, populate this in the pre-filled test-data-builder and all our tests will continue to work because a valid object will be provided.

```csharp
public class ArticleTestDataBuilder : ArticleBuilder
{
    public ArticleTestDataBuilder()
    {
        this.Name = UnitTestValueGenerator.GenerateText(128);
    }
}
```

You could then finally write your own AsXXX() method to build specific types of objects

```csharp
public ArticleTestDataBuilder AsDiscontinuedArticle()
{
    this.IsDiscontinued = true;
    this.Price = 0;
    this.Quantity = 0;
}
```
