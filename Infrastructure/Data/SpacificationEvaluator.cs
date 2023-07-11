using Core.Entities;
using Core.Spacefications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpacificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpacefication<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            query = spec.Includes.Aggregate(query,(current, include) => current.Include(include));
            return query;
        }
    }
}
