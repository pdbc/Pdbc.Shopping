# Pdbc.Shopping

Pdbc.Shopping is a pet project of mine to try out various things. 
I tend to find more benefit when developing on a solution that has some weigth than simply setting up basic classes for your test purpose.  

This application is based on a shopping list, since this offers me a lot flexibility to incorporate items.

> On a personal note: I've chosen this domain because usually my wife goes to the store.  On these rare occasions when I need to pick the groceries, she has to 
> write a very detailed list of everything because I simply don't know every brand of product we require.  And as I've alreayd learned, not all brands the same :-)
> So this application might in the future actually be usefull for me.

## The Initial Domain Model

The domain model starts out really simple.  We have articles that have a name and brand.  Articles are sold in stores which have an address so I know where to find the store.
Finally there is a shopping list for a store which holds a list of articles we need to buy.

## Common classes

Every solution 'must' have some common classes that can be used freely throughout all the private projects.  Usually this is one of the very first projects I'll include in my solution.
In this case I've added an ObjectBuilder interface/base class into to this project to provide the ability to fluently construct objects in my solution.  
It provides better readability and allows to creation of TestObjectBuilders to create correctly filled in object in my tests.

For more info about how I use the builder pattern see [Test Data Builder page](Pdbc.Shopping.Documentation\articles\data-builders.md)
