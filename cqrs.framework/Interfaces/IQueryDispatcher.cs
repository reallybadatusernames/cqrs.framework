namespace cqrs.framework.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TQueryResult> DispatchAsync<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery
            where TQueryResult : IQueryResult;
    }
}
