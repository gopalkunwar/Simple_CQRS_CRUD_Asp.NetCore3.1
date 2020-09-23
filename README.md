# Simple_CQRS_CRUD_Asp.NetCore3.1
## implement CQRS in a very basic CRUD application using the MediatR library
MediatR library is an open source implementation of mediator pattern for .NET Applications.

## CQS?

* CQS stands command query Separation. 
* Allows separate read and write operations. 
* Commands help us to write the database and the queries help us to read the database. 
* We need handlers for Command and Queries. 
* Mediator pattern allows us to implement Command/Queries and Handlers loosely coupled. 

In simple terms, first we need to define a request and the request describes the behavior of commands and queries. And if the request is created, then we need a handler to handle the request. 

Install MediatR.Extensions.Microsoft.DependencyInjection package.

## Add mediator Service in the startup class
            services.AddMediatR(typeof(List.Handler).Assembly);
we are passing the assembly reference in the mediator where all the handlers are located.
