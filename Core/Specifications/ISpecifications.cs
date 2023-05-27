using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecifications<T>
    {
    // int m {get;}     
        Expression<Func<T,bool>> Criteria {get;}
        List<Expression<Func<T,object>>> Includes {get;}         
    }
}