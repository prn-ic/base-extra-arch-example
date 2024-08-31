using System.Linq.Expressions;

namespace BaseCoreExample.Core.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public AndSpecification<T> And(Specification<T> specification) =>
            new AndSpecification<T>(this, specification);

        public OrSpecification<T> Or(Specification<T> specification) =>
            new OrSpecification<T>(this, specification);

        public NotSpecification<T> Not() => new NotSpecification<T>(this);

        public bool IsSatisfiedBy(T item)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(item);
        }
    }
}
