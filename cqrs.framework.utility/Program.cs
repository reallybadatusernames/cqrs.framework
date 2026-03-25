// See https://aka.ms/new-console-template for more information

using cqrs.framework.Commands.User;
using cqrs.framework.Dispatchers;
using cqrs.framework.Interfaces;
using cqrs.framework.Queries.Users;
using Microsoft.Extensions.DependencyInjection;

//Setup DI
var services = new ServiceCollection();

//Queries
services.AddTransient<IQueryHandler<GetUserById, GetUserByIdResult>, GetUserByIdHandler>();
services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

//Commands
services.AddTransient<ICommandHandler<CreateUser>, CreateUserHandler>();
services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

var provider = services.BuildServiceProvider();

//Get dispatchers
var queryDispatcher = provider.GetRequiredService<IQueryDispatcher>();
var commandDispatcher = provider.GetRequiredService<ICommandDispatcher>();

//Execute a command
await commandDispatcher.DispatchAsync<CreateUser>(new CreateUser
{
    FirstName = "First Name",
    LastName = "Last Name",
    Email = "example@gmail.com"
});

//Execute a query
var result = await queryDispatcher.DispatchAsync<GetUserById, GetUserByIdResult>(new GetUserById
{
    Id = 1
});

Console.WriteLine(result.FirstName);
Console.ReadLine();
