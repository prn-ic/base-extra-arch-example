using System.Linq.Expressions;
using BaseCoreExample.Core.Specifications;

namespace BaseCoreExample.Core.Entities
{
    public class EmptySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
