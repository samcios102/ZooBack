using System.Threading.Tasks;

namespace Zoo.Application.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}