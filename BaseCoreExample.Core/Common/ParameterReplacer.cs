using System.Linq.Expressions;

namespace BaseCoreExample.Core.Common
{
    /// <summary>
    /// Данный класс нужен для того, чтобы 
    /// цепь из спецификаций имела единственный именной параметер,
    /// таков .NET, иначе берутся разные несвязные параметры,
    /// отчего выкидывает Exception
    /// </summary>
    public class ParameterReplacer(ParameterExpression parameter) : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter = parameter;

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(_parameter);
        }
    }
}
