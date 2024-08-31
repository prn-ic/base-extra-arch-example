using System.Linq.Expressions;

namespace BaseCoreExample.Core.Specifications
{
    public class NotSpecification<T>(Specification<T> specification) : Specification<T>
    {
        private readonly Specification<T> _specification = specification;

        public override Expression<Func<T, bool>> ToExpression() =>
            Expression.Lambda<Func<T, bool>>(
                Expression.Not(_specification.ToExpression().Body),
                _specification.ToExpression().Parameters.Single()
            );
    }
}
