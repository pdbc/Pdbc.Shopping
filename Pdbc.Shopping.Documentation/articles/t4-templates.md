# T4 Templates

T4 templates provides the ability to generate code based on the classes available in your project.  
It if particularly usefull when you need some classes to follow another one. For example when Builder classes should follow domain/request/dto classes, but as well to enforce some conventions.

> Roslyn might replace the t4 templates in the future, but at this moment t4 templates are sufficient.

## Builder pattern

The builder pattern is a design choice on how object can be created, it provides better readability and extensability.

```csharp
var articles = new Article() {
    Name = "Milk",
    Brand = "Inza",
    Price = 1.2,
    Type = "Nutricion",
    ....
}

var articles = new ArticleBuilder()
  .WithName("Milk")
  .WithBrand("Inza")
  .WithPrice(1.2)
  .WithType("Nutricion");
```

Of course the construction of these builder classes can be tedious and that's where t4 templates excel.  Every change on the 'Article' class requires a change to the builder.  Every rename of a class/property needs to be reflected in the builder class.

## Various templates

### Utilities

The T4 utility file contains various functions to use full in the overall generations.  It contains project utiltities, classes utitlities and other ones.

#### Utilities-Project
Since we need to iterate over classes in the projects in our solution, we need some utility methods to find all these classes and filter on the specific classes we need.

* GetProjectByName: find a project by name
* GetAllProjectsRecursiveFromSolution: retrieves all project recursively (if you order you projects in solution folders, you need the recursive functionality.)
* GetCurrentProject: get the current project

#### Utilities-Classes
Once we have project we need to retrieve specific classes from it:

* GetClassesOf: Gets the classes of a project
* GetNamespaceClasses: Get classes from a specific namespace
* GetCqrsClasses: Get the classes related to CQRS  (Query/Command/...)
* GetApiContractClasses: Get classes related to API Contracts







