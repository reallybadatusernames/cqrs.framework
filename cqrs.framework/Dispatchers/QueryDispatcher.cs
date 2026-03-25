using cqrs.framework.Interfaces;

namespace cqrs.framework.Dispatchers
{
    /// <summary>
    /// The primary implementation of IQueryHandler and will accept an IQuery, 
    /// try to determine the appropriate handler, then call the HandleAsync method 
    /// of the handler to return an IQueryResult
    /// </summary>
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TQueryResult> DispatchAsync<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery
            where TQueryResult : IQueryResult
        {
            var handler = _serviceProvider
                .GetService(typeof(IQueryHandler<TQuery, TQueryResult>)) as IQueryHandler<TQuery, TQueryResult>;

            if (handler is null)
                throw new InvalidOperationException($"No handler is registered for query type {typeof(TQuery).Name}");

            return handler.HandleAsync(query);
        }
    }
}
