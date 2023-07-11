using System.Linq.Expressions;

namespace Core.Spacefications
{
    public interface ISpacefication<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}
