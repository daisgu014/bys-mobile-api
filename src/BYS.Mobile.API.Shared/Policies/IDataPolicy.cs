using LinqKit;
using System.Linq.Expressions;

namespace BYS.Mobile.API.Shared.Policies
{
    public interface IDataPolicy { }

    public interface IFilterPolicy<T> : IDataPolicy
    {
        Expression<Func<T, bool>> Predicate(Expression<Func<T, bool>> expression);
    }

    public interface IInsertPolicy<T> : IDataPolicy
    {
        void PrepareInsert(T entity);
    }

    public interface IUpdatePolicy<T> : IDataPolicy
    {
        void PrepareUpdate(T entity);
    }

    public abstract class BaseFilterPolicy<T> : IFilterPolicy<T>
    {
        public abstract Expression<Func<T, bool>> Predicate(Expression<Func<T, bool>> expression);

        protected Expression<Func<T, bool>> Predicate(ExpressionStarter<T> predicate, Expression<Func<T, bool>> expression)
        {
            return expression is null ? (ExpressionType.Constant.Equals(predicate.Body.NodeType) ? null : predicate) : predicate.And(expression);
        }
    }
}
