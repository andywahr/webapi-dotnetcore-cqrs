# webapi-dotnetcore-mediator-di-sample
Example of .Net Core WebAPI implemented with a simple Mediator pattern and shows examples of using Dependency Injection.  This is done to try avoid as much direct coupling as possible between classes, segregate code into smaller, more testable chunks.  


### [MediatR](https://github.com/jbogard/MediatR)
MediatR is a lightweight, simple implementation of a Mediator framework that makes it pretty straight forward to create Queries and Commands.  In the example we created 2 different Rest endpoints to demonstrate a GET and PUT.  Each endpoint has a backing service, taking in a Request object and returns a Response object, that implements:

    MediatR.IRequestHandler

Each method in the Web API Controller inherits from a BaseController that provides simple mechanims to return a standard wrapped return message, and each method has 3 basic section:

1.  Validate any incoming parameters
1.  Have the Mediator invoke the backing service
1.  Wrap the result properly

### Object Lifetime and Scoping example
One of the items that gets a bit tricky is how to register services and how that plays into a specific instances Lifecycle (aka when is a new instance created vs an existing returned and when is it cleaned up).  Once you download and start the web serivce running, call the Get All Values (/api/values) API twice and look at the value of the result.iocEntries in the result.  It's a collection of 2 objects that has a transient, scoped, and singleton value.  If you look at the return values from two calls to that REST endpoint (giving you a total of 4 entries in the iocEntries collection):

    * Transient will always be different
    * Scoped will be the same for each call, 
      * first call Scoped values will be the same
      * second call Scoped value will be the same but different than the first call
    * Singleton will be the same until the application is restarted


