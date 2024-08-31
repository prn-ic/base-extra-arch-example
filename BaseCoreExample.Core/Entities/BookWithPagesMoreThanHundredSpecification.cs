using System.Linq.Expressions;
using BaseCoreExample.Core.Specifications;

namespace BaseCoreExample.Core.Entities
{
    public class BookWithPagesMoreThanHundredSpecification() : Specification<Book>
    {
        public override Expression<Func<Book, bool>> ToExpression()
        {
            return book => book.Pages >= 100;
        }
    }
}
