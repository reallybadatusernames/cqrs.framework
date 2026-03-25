# CQRS Example
This repository demonstrates a quick and lightweight CQRS pattern implemented in C#

It includes:
- A simple command and query dispatcher
- Example CreateUser command
- Example GetUserById query
- A console app showing how everything works

The goal is to demonstrate a minimal reference implementation that's easy to extend

## Architecture

| Concern | Interface | Description |
|---------|-----------|-------------|
| Commands  | `ICommand`, `ICommandHandler<T>` | Perform actions that change state. No return value. |
| Queries | `IQuery`, `IQueryHandler<TQuery, TResult>` | Retrieve data. Always return a result. |
| Dispatchers | `ICommandDispatcher`, `IQueryDispatcher` | Resolve and execute the appropriate handler.  |
