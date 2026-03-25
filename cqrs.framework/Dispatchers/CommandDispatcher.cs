using cqrs.framework.Interfaces;

namespace cqrs.framework.Dispatchers
{
    /// <summary>
    /// The primary implementation of ICommandDispatcher and will take and ICommand and call the 
    /// HandleAsync method of any registered CommandHandler for the command.
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;

            if (handler is null)
                throw new InvalidOperationException(
                    $"No handler registered for command type {typeof(TCommand).Name}");

            return handler.HandleAsync(command);
        }
    }
}
