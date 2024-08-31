using System.Linq.Expressions;
using BaseCoreExample.Core.Common;

namespace BaseCoreExample.Core.Specifications
{
    public class OrSpecification<T>(Specification<T> left, Specification<T> right) : Specification<T>
    {
        private readonly Specification<T> _left = left;
        private readonly Specification<T> _right = right;

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            var primaryParameterExpression = Expression.Parameter(typeof(T));
            var orExpression = Expression.Or(leftExpression.Body, rightExpression.Body);
            orExpression = (BinaryExpression)
                new ParameterReplacer(primaryParameterExpression).Visit(orExpression);

            return Expression.Lambda<Func<T, bool>>(orExpression, primaryParameterExpression);
        }
    }
}
