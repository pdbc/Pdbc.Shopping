# CQRS

CQRS stands for Command Query Responsibility Segregation, it can cover lots of ground, but basically is about seperating the commands you have in your application from the queries.  I believe in this pattern very strongly because it provides a basic structure to your code as well.  

Every action (can be a command can be a query) starts with a central data object that will go through a pipeline of actions, until ultimately the action completes and a result is returned.  Every step of the pipeline can halt the entire execution because of for instance validation failures or missing query values.

The pipeline feature can be written manually of course, but the open-source MediatR package provides this functionality as well.

## Queries & Commands

The CQRS pipeline resides on the fact that we have one input class (a Query or a Command) and one (or none) output class (ViewModel).  Since we want the same ease of testing here, the  [builders & test-data builders](../data-builder.md) will be an important part of here as well.

## Request Pipeline

The request pipeline starts with a Request which then gets translated (mapped) to Command/Query and gets executed.  After the execution a Result/ViewModel is returned which then gets mapped to Response.

## CRUD Actions and DTO-objects

Lots of business applications simply need to have some CRUD logic.  Most of the time you will have a list/overview screen that displays a list of items.  On this list you can select an item to edit or delete or as an overall action you should be able to add a new item.

### DTO-objects
Every action you require, requires a different DTO-object.  For instance creating and object should never accept and identifier, while editing an object requires you to specify the identifier.  Some properties even might be immutable, thus not available on the UpdateDTO.

Retrieving the detail value of an object will result in different properties than when you request the DTO-objec to fill your grid-view.


```csharp
public interface 
```




