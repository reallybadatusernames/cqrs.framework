namespace cqrs.framework.Interfaces
{
    public interface IQueryHandler<in TQuery, TQueryResult>
        where TQuery : IQuery
        where TQueryResult : IQueryResult
    {
        Task<TQueryResult> HandleAsync(TQuery query);
    }
}
