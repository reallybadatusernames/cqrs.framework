// See https://aka.ms/new-console-template for more information

using cqrs.framework.Dispatchers;
using cqrs.framework.Interfaces;
using cqrs.framework.Queries.Users;
using Microsoft.Extensions.DependencyInjection;

//Setup DI
var services = new ServiceCollection();

services.AddTransient<IQueryHandler<GetUserById, GetUserByIdResult>>();
services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

var provider = services.BuildServiceProvider();

//Get dispatcher
var queryDispatcher = provider.GetRequiredService<IQueryDispatcher>();

//Execute a query
var result = await queryDispatcher.DispatchAsync<GetUserById, GetUserByIdResult>(new GetUserById
{
    Id = 1
});

Console.WriteLine(result.FirstName);
