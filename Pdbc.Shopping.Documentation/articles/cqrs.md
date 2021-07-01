# CQRS

CQRS stands for Command Query Responsibility Segregation, it can cover lots of ground, but basically is about seperating the commands you have in your application from the queries.  I believe in this pattern very strongly because it provides a basic structure to your code as well.  

Every action (can be a command can be a query) starts with a central data object that will go through a pipeline of actions, until ultimately the action completes and a result is returned.  Every step of the pipeline can halt the entire execution because of for instance validation failures or missing query values.

The pipeline feature can be written manually of course, but the open-source MediatR package provides this functionality as well.

## Queries & Commands

The CQRS pipeline resides on the fact that we have one input class (a Query or a Command) and one (or none) output class (ViewModel).  Since we want the same ease of testing here, the  [builders & test-data builders](../data-builder.md) will be an important part of here as well.







